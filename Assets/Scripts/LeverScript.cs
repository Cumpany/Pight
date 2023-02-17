using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public List<GameObject> Tanks = new List<GameObject>();

    bool IsOn = false;

    GameObject Player;

    GameObject Parent;

    public GameObject Prompt;

    BoxCollider BoxCollider;

    public AudioClip LeverSound;

    bool InRange = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Parent = transform.parent.gameObject;
        BoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) > 3.5f)
        {
            Prompt.SetActive(false);
        }
        
        //if (Input.GetKeyDown(KeyCode.E) && InRange)
        //{
        //    Debug.Log(Parent.name);
        //    IsOn = !IsOn;
        //    foreach (GameObject tank in Tanks)
        //    {
        //        tank.SetActive(!tank.activeSelf);
        //    }
        //}
        
        //raycast from player
        //RaycastHit hit;
        //if (Physics.Raycast(Player.transform.position, Player.transform.forward, out hit, 10))
        //{
        //    if (hit.collider.gameObject == gameObject)
        //    {
        //        Prompt.SetActive(true);
        //        //if player presses E
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            //toggle the lever
        //            IsOn = !IsOn;
        //            //toggle the tanks
        //            foreach (GameObject tank in Tanks)
        //            {
        //                tank.SetActive(!tank.activeSelf);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Prompt.SetActive(false);
        //    }
        //}


        if (IsOn)
        {
            Parent.transform.rotation = Quaternion.Euler(0, -90, 180);
        }
        else
        {
            Parent.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    InRange = true;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    InRange = false;
    //}

    public void InSight()
    {
        Prompt.SetActive(true);
        //if player presses E
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<AudioSource>().PlayOneShot(LeverSound);
            //toggle the lever
            IsOn = !IsOn;
            //toggle the tanks
            foreach (GameObject tank in Tanks)
            {
                tank.SetActive(!tank.activeSelf);
            }
        }
    }

    public void NotInSight()
    {
        Prompt.SetActive(false);
    }
}
