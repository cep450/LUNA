using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.UI;

public class Text_active_at_line : MonoBehaviour
{
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;
    public bool requireButtonPress;
    public bool toBeTriggered;
    private bool waitForPress;

    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        theTextBox.ReloadScript(theText);
        theTextBox.currentLine = startLine;
        theTextBox.endAtLine = endLine;
        theTextBox.EnableTextBox();

        //stop rat chasing


        if (destroyWhenActivated)
        {
            Debug.Log("Destroying");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
     


    }
    public void TaskOnClick()
    {
      
                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();

                //stop rat chasing


                if (destroyWhenActivated)
                {
                    Debug.Log("Destroying");
                    Destroy(gameObject);
                }
      }

            // if(requireButtonPress){
            //     waitForPress = true;
            //     return;
            // }
        
    




}
