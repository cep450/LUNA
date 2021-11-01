using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class radio_system : MonoBehaviour
{
    // Start is called before the first frame update
    public static float frequency=100.0f;
    public TextMeshPro textmeshpro;
   // public AudioClip[] radioclips;
   // public AudioClip static_noise;
  //  private AudioSource radio;
    public AudioMixer masterMixer;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        textmeshpro.text = frequency+"FM";
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frequency = frequency - 0.1f;
            SetSound(frequency-100.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            frequency = frequency + 0.1f;
            SetSound(frequency - 100.0f);
        }

       
    }
    public void SetSound(float soundLevel)
    {
        masterMixer.SetFloat("SFX_VOL", soundLevel);
    }
}
