using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Control;
    public GameObject Main;

    public void GoBack()
    {
        Control.SetActive(false);
        Main.SetActive(true);
    }

    public void Controls()
    {
        Control.SetActive(true);
        Main.SetActive(false);
    }
}
