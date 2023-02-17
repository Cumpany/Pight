using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockButton : MonoBehaviour
{
    [SerializeField]
    public TMP_Text text;

    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPlus()
    {
        Door.GetComponent<AudioSource>().PlayOneShot(Door.GetComponent<PadlockScript>().Switch);
        if (int.TryParse(text.text, out int num))
        {
            num++;
            if (num > 9)
            {
                num = 0;
            }
            text.text = num.ToString();
        }
    }

    public void ClickMinus()
    {
        Door.GetComponent<AudioSource>().PlayOneShot(Door.GetComponent<PadlockScript>().Switch);
        if (int.TryParse(text.text, out int num))
        {
            num--;
            if (num < 0)
            {
                num = 9;
            }
            text.text = num.ToString();
        }
    }
}
