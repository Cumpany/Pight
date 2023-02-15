using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public List<GameObject> Tanks = new List<GameObject>();

    bool IsOn = false;

    GameObject Player;

    GameObject Parent;

    BoxCollider BoxCollider;

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
        //if (Physics.ComputePenetration(BoxCollider, BoxCollider.transform.position, BoxCollider.transform.rotation, Player.GetComponent<CapsuleCollider>, Player.GetComponent<CapsuleCollider>().transform.position, Player.GetComponent<CapsuleCollider>().transform.rotation, )
        //if(Parent.name == "Lever")
        //{
        //    Debug.Log(Vector3.Distance(Player.transform.position, transform.position) + Parent.name);
        //}
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            Debug.Log(Parent.name);
            IsOn = !IsOn;
            foreach (GameObject tank in Tanks)
            {
                tank.SetActive(!tank.activeSelf);
            }
        }
        if (IsOn)
        {
            Parent.transform.rotation = Quaternion.Euler(0, -90, 180);
        }
        else
        {
            Parent.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        InRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        InRange = false;
    }
}
