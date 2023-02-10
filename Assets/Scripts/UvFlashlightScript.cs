using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvFlashlightScript : MonoBehaviour
{
    public GameObject Spotlight;
    public int MouseButton = 0;

    public GameObject Light;

    GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton) && Player.GetComponent<PlayerController>().HasUvFlashlight)
        {
            Spotlight.SetActive(!Spotlight.activeSelf);
            Light.SetActive(false);
        }
    }
}
