using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Door;
    public Animator anim;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    anim.SetBool("DoorOpen", true);
        //}
        
    }
}
