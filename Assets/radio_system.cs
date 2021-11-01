using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class radio_system : MonoBehaviour
{
    // Start is called before the first frame update
    public static float frequency=10.0f;
    public TextMeshPro textmeshpro;
   public AudioClip[] radioclips;
   // public AudioClip static_noise;
    private AudioSource radio;
    public AudioMixer masterMixer;
    void Start()
    {
        radio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (frequency<0)
        {
            frequency = radioclips.Length * 10;

        }
        if (frequency > radioclips.Length * 10)
        {
            frequency = 0;

        }
        textmeshpro.text = frequency+"FM";
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frequency = frequency - 0.1f;
            SetSound(Mathf.Abs(frequency % 10 - 5));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            frequency = frequency + 0.1f;
            SetSound(Mathf.Abs(frequency % 10-5));
        }
        if (frequency%10<=5)
        {
            change_music_play(Mathf.RoundToInt(frequency / 10));
        }
       
    }
    public void SetSound(float soundLevel)
    {
        Debug.Log(soundLevel);
        masterMixer.SetFloat("SFX_VOL", soundLevel);
    }
    void change_music_play(int frequency)
    {
        radio.clip = radioclips[frequency];
        radio.Play(0);
    }
}
