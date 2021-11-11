using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.UI;

public class Text_active_at_line : MonoBehaviour
{
    private TextAsset theText;
    public TextAsset Text1;
    public TextAsset Text2;
    public TextAsset Text3;
    public TextAsset Text4;
    public int startLine;
    public int endLine;
    private int current_text_file = 1;
    public GameObject button;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;
    public bool requireButtonPress;
    public bool toBeTriggered;
    private bool waitForPress;

    void Start()
    {
        theText = Text1;
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
        if (TextBoxManager.text_end==true)
        {
          
            button.SetActive(false);
            if (current_text_file == 1 && radio_system.current_playlist == 0)
            {
        
               
                    theText = Text2;
                endLine = 17;
                Reload();
                    current_text_file = 2;
                    
                TextBoxManager.text_end = false;

            }
            if (current_text_file == 2 && radio_system.current_playlist == 4)
            {


                endLine = 16;
                theText = Text3;
                    Reload();
                    current_text_file = 3;
                TextBoxManager.text_end = false;
             
            }
            if (current_text_file == 3 && radio_system.current_playlist == 6)
            {


                endLine = 7;
                theText = Text4;
                Reload();
                current_text_file = 4;
                TextBoxManager.text_end = false;

            }

        }
    }
    public void Reload()
    {
      
                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = startLine;
                theTextBox.endAtLine = endLine;
                theTextBox.EnableTextBox();
        button.SetActive(true);
        //stop rat chasing
        Debug.Log("reload");
        button.SetActive(true);
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
