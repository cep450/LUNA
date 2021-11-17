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

    public TextAsset[] fakechoice;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;
    public bool requireButtonPress;
    public bool toBeTriggered;
    private bool waitForPress;

    public TextAsset thx4playing;
    public FadeInAtEnd endCutscene;
  

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
            if (radio_system.song_stay_same) 
            {

                if (current_text_file == 1 && 
                    (radio_system.current_playlist == 1 || radio_system.current_playlist == 4 ||
                    radio_system.current_playlist == 10 || radio_system.current_playlist == 13))
                {
                  

                    theText = Text2;
                    endLine = 18;
                    Reload();
                    current_text_file = 2;
                    TextBoxManager.text_end = false;
                    radio_system.song_stay_same = false;
                    

                }
                else if (current_text_file == 2 && 
                    (radio_system.current_playlist == 5 || radio_system.current_playlist == 6 ||
                    radio_system.current_playlist == 15 || radio_system.current_playlist == 2 ||
                    radio_system.current_playlist == 11))
                {


                    endLine = 17;
                    theText = Text3;
                    Reload();
                    current_text_file = 3;
                    TextBoxManager.text_end = false;
                    radio_system.song_stay_same = false;

                }
                else if (current_text_file == 3 &&
                    (radio_system.current_playlist == 1 || radio_system.current_playlist == 3 ||
                    radio_system.current_playlist == 4 || radio_system.current_playlist == 13))
                {


                    endLine = 7;
                    theText = Text4;
                    Reload();
                    current_text_file = 4;
                    TextBoxManager.text_end = false;
                    radio_system.song_stay_same = false;

                }
                
                else if(current_text_file < 4 && theText != fakechoice[radio_system.current_playlist])
                {
                    radio_system.song_stay_same = false;
                    fake_choice(radio_system.current_playlist);

                    Debug.Log(radio_system.song_stay_same);

                }

              
            }

            //ending- when #4 ends- 
                if(current_text_file == 4) {
                    Debug.Log(theTextBox.currentLine + "box");
                }
               if (current_text_file == 4 && theTextBox.currentLine >= 5)
                {

                    Debug.Log("got here");

                    //start the ending coroutine if it isn't running already 
                    if (!endCutscene.hasStarted)
                    {
                        StartCoroutine(endCutscene.ShowEndScreen());
                    }

                    //when the coroutine is done 
                    //play the "thanks for playing"
                    if (endCutscene.hasEnded)
                    {
                        endLine = 1;
                        theText = thx4playing;
                        Reload();
                        current_text_file = 5;
                        TextBoxManager.text_end = false;
                        radio_system.song_stay_same = false;
                    }


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
       
        Debug.Log("reload");
    
            
      }
   
    void fake_choice(int song_order) {
        theText = fakechoice[song_order];
        endLine = 0;
        Reload();
        TextBoxManager.text_end = false;

    }
            // if(requireButtonPress){
            //     waitForPress = true;
            //     return;
            // }
        
    




}
