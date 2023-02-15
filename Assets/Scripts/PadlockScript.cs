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
    int Num1Int;
    int Num2Int;
    int Num3Int;
    int Num4Int;

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
        //convert string to int
        Num1Int = int.Parse(Num1.GetComponent<LockButton>().text.text);
        Num2Int = int.Parse(Num2.GetComponent<LockButton>().text.text);
        Num3Int = int.Parse(Num3.GetComponent<LockButton>().text.text);
        Num4Int = int.Parse(Num4.GetComponent<LockButton>().text.text);
        //Debug.Log(Vector3.Distance(Player.transform.position, transform.position));
        if (Vector3.Distance(Player.transform.position, transform.position) < 2 && !Opened)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<PlayerController>().canMove = false;
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
            Player.GetComponent<PlayerController>().canMove = true;
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Num1Int == Code1 && Num2Int == Code2 && Num3Int == Code3 && Num4Int == Code4)
        {
            Opened = true;
            anim.SetBool("DoorOpen", true);
            Canvas.SetActive(false);
            Player.GetComponent<PlayerController>().canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
