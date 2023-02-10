using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameObject Player;

    string Tag;

    public GameObject Prompt;

    bool PickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Tag = gameObject.tag;
        Prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 2 && !PickedUp)
        {
            Prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Tag == "Key")
                {
                    Prompt.SetActive(false);
                    Player.GetComponent<PlayerController>().HasKey = true;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Prompt.SetActive(false);
        }
    }
}
