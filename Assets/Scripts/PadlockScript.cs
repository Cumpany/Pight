using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockScript : MonoBehaviour
{
    GameObject Player;
    
    public Animator anim;
    
    public GameObject Canvas;
    public GameObject Prompt;
    
    public GameObject Num1;
    public GameObject Num2;
    public GameObject Num3;
    public GameObject Num4;

    public int Code1;
    public int Code2;
    public int Code3;
    public int Code4;

    bool Opened = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Canvas.SetActive(false);
        Prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(Player.transform.position, transform.position));
        if (Vector3.Distance(Player.transform.position, transform.position) < 2 && !Opened)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }

            if (Canvas.activeSelf == false)
            {
                Prompt.SetActive(true);
            }
            else
            {
                Prompt.SetActive(false);
            }
        }
        else
        {
            Prompt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Num1.GetComponent<LockButton>().text.text == Code1.ToString() && Num2.GetComponent<LockButton>().text.text == Code2.ToString() && Num3.GetComponent<LockButton>().text.text == Code3.ToString() && Num4.GetComponent<LockButton>().text.text == Code4.ToString())
        {
            Opened = true;
            anim.SetBool("DoorOpen", true);
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
