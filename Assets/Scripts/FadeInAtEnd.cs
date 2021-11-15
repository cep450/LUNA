using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAtEnd : MonoBehaviour
{

    public bool hasStarted = false;
    public bool hasEnded = false;

    public IEnumerator ShowEndScreen() {

        hasStarted = true;

        //some delay- other text wouldve just appeared i think 
        //pause/hold 
        for(float i = 0; i < 4; i += Time.deltaTime) {
            yield return null;
        }
        
        //fade to end screen 
        for (float f = 0f; f <= 1; f += Time.deltaTime * 0.4f){
            Color sprcolor = GetComponent<SpriteRenderer>().color;
            sprcolor.a = f;
            GetComponent<SpriteRenderer>().color = sprcolor;
            yield return null;
        }

        //pause/hold 
        for(float i = 0; i < 4; i += Time.deltaTime) {
            yield return null;
        }

        //cut to black 
        GetComponent<SpriteRenderer>().color = Color.black;

        for(float i = 0; i < 1; i += Time.deltaTime) {
            yield return null;
        }

        //tell other script to show thanks for playing text 
        hasEnded = true;
    }
}
