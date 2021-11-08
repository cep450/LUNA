using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_click_detector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject radio;
    public Sprite radio_normal;
    public Sprite radio_hover;
    public static bool radio_change_on;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition );
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))

        {
            if (hit.transform.name == "radio")
            {
                radio.GetComponent<SpriteRenderer>().sprite = radio_hover;
                radio_change_on = true;
            }
        }
        else
        {
            radio.GetComponent<SpriteRenderer>().sprite = radio_normal;
           // Debug.Log("Nothing hit");
            radio_change_on = false;
        }
    
    }
    }

