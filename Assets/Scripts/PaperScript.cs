using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Prompt;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) > 0.1f)
        {
            Prompt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<PlayerController>().canMove = true;
        }
    }

    public void InSight()
    {
        Prompt.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Canvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<PlayerController>().canMove = false;
        }
    }
}
