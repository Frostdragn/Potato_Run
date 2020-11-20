using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject bombCheck = GameObject.Find("potato_man_1");
        PotatoMan potatoScript = bombCheck.GetComponent<PotatoMan>();

        if (potatoScript.bombCollected == false) 
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
