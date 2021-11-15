using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAtEnd : MonoBehaviour
{

    void Start() {
        //StartCoroutine(ShowEndScreen());
    }

    public IEnumerator ShowEndScreen() {
        
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

        //TODO show thanks for playing text 
    }
}
