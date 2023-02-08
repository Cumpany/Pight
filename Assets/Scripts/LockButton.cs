using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockButton : MonoBehaviour
{
    [SerializeField]
    public TMP_Text text;
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
