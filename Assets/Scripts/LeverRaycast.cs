using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            if (hit.collider.gameObject.tag == "Lever")
            {
                hit.collider.gameObject.GetComponent<LeverScript>().InSight();
            }

            
            if (hit.collider.gameObject.tag == "Locker")
            {
                hit.collider.gameObject.GetComponentInParent<LockerScript>().InSight();
            }

            if (hit.collider.gameObject.tag == "Paper")
            {
                Debug.Log("papre");
                hit.collider.gameObject.GetComponentInParent<PaperScript>().InSight();
            }
        }
    }
}
