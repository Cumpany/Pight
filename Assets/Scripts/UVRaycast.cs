using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVRaycast : MonoBehaviour
{
    public Material UvMat;
    public Material InvisMat;

    private Dictionary<GameObject, float> Objects = new Dictionary<GameObject, float>();

    private List<Vector3> RayCastDirections = new();

    void Start()
    {
        float angle = gameObject.GetComponent<Light>().spotAngle;
        // generate cone of raycast directions based on spotlight angle
        // for (int j = 0; j < 5; j++)
        // {
        //     for (int i = 0; i < 360; i += 5)
        //     {
        //         float x = Mathf.Sin(i * Mathf.Deg2Rad) * (angle / (180 * j));
        //         float y = Mathf.Cos(i * Mathf.Deg2Rad) * (angle / (180 * j));
        //         RayCastDirections.Add(new Vector3(x, y, 0));
        //     }
        // }
        // RayCastDirections = GenerateCastDirections(angle);
        bool offset = false;
        for (float i = 0; i < angle; i += 5)
        {
            RayCastDirections.AddRange(GenerateCastDirections(i, offset));
            offset = !offset;
        }
    }
    private List<Vector3> GenerateCastDirections(float angle, bool offset = false)
    {
        // List<Vector3> directions = new List<Vector3>();
        // for (int i = 0; i < 360; i += 5)
        // {
        //     float x = Mathf.Sin(i * Mathf.Deg2Rad) * (angle / 180);
        //     float y = Mathf.Cos(i * Mathf.Deg2Rad) * (angle / 180);
        //     directions.Add(new Vector3(x, y, 0));
        // }
        // return directions;
        List<Vector3> directions = new List<Vector3>();
        float offsetAngle = offset ? 0.5f * Mathf.Deg2Rad : 0;
        for (int i = 0; i < 360; i += 5)
        {
            float x = Mathf.Sin(i * Mathf.Deg2Rad + offsetAngle) * (angle / 180);
            float y = Mathf.Cos(i * Mathf.Deg2Rad + offsetAngle) * (angle / 180);
            directions.Add(new Vector3(x, y, 0));
        }
        return directions;
    }
    void Update()
    {
        //raycast from uv light position
        RaycastHit hit;
        //draw raycast in scene view
        foreach (var direction in RayCastDirections)
        {
            Debug.DrawRay(transform.position, (transform.forward + transform.TransformDirection(direction)) * 50, Color.red);
            if (Physics.Raycast(transform.position, transform.forward + transform.TransformDirection(direction), out hit, 50))
            {

                //Debug.Log("hit");
                //Debug.Log(hit.transform.gameObject.name);
                //Debug.Log(hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "UV")
                {
                    //Debug.Log("UV");
                    hit.transform.gameObject.GetComponent<SpriteRenderer>().material = UvMat;
                    Objects[hit.transform.gameObject] = 0.1f;
                }
            }
        }
        foreach (var obj in Objects)
        {
            Objects[obj.Key] = Objects[obj.Key] - Time.deltaTime;
            if (obj.Value <= 0)
            {
                obj.Key.GetComponent<Renderer>().material = InvisMat;
            }
        }
    }
    void OnDisable()
    {
        foreach (var obj in Objects)
        {
            obj.Key.GetComponent<Renderer>().material = InvisMat;
        }
    }
}
public static class ConeCastExtension
{
    public static RaycastHit[] ConeCastAll(Physics physics, Vector3 origin, float maxRadius, Vector3 direction, float maxDistance, float coneAngle)
    {
        RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin - new Vector3(0, 0, maxRadius), maxRadius, direction, maxDistance);
        List<RaycastHit> coneCastHitList = new List<RaycastHit>();

        if (sphereCastHits.Length > 0)
        {
            for (int i = 0; i < sphereCastHits.Length; i++)
            {
                sphereCastHits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
                Vector3 hitPoint = sphereCastHits[i].point;
                Vector3 directionToHit = hitPoint - origin;
                float angleToHit = Vector3.Angle(direction, directionToHit);

                if (angleToHit < coneAngle)
                {
                    coneCastHitList.Add(sphereCastHits[i]);
                }
            }
        }

        RaycastHit[] coneCastHits = new RaycastHit[coneCastHitList.Count];
        coneCastHits = coneCastHitList.ToArray();

        return coneCastHits;
    }
}
