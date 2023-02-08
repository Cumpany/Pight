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
        float radius = gameObject.GetComponent<Light>().range;
        float step = 1f;
        for (float i = -angle / 2; i < angle / 2; i += step)
        {
            RayCastDirections.Add(new Vector3(Mathf.Sin(i * Mathf.Deg2Rad), 0, Mathf.Cos(i * Mathf.Deg2Rad)).normalized);
        }
    }
    void Update()
    {
        //raycast from uv light position
        RaycastHit hit;
        //draw raycast in scene view
        foreach (var direction in RayCastDirections)
        {
            Debug.DrawRay(transform.position, (transform.forward + direction)*100, Color.red);

            if (Physics.Raycast(transform.position, transform.forward + direction, out hit, 100))
            {
                
                //Debug.Log("hit");
                //Debug.Log(hit.transform.gameObject.name);
                //Debug.Log(hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "UV")
                {
                    //Debug.Log("UV");
                    hit.transform.gameObject.GetComponent<Renderer>().material = UvMat;
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
}
