using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class radio_system : MonoBehaviour
{
    // Start is called before the first frame update
    public static float frequency = 10.0f;
    public TextMeshPro textmeshpro;
    public AudioClip[] radioclips;
    // public AudioClip static_noise;
    private AudioSource radio;
    public AudioMixer masterMixer;
    private int current_song;
    void Start()
    {
        radio = GetComponent<AudioSource>();
        Debug.Log(radioclips.Length);
        current_song = 0;
        set_volume(frequency);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (frequency < 0)
        {
            frequency = (radioclips.Length - 1) * 10 + 5;

        }
        if (frequency > (radioclips.Length - 1) * 10 + 5)
        {
            frequency = 0;

        }
        textmeshpro.text = frequency + "FM";
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frequency = frequency - 0.1f;
            set_volume(frequency);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            frequency = frequency + 0.1f;
            set_volume(frequency);
        }
        if (Mathf.RoundToInt(frequency / 10) != current_song)
        {
            change_music_play(Mathf.RoundToInt(frequency / 10));

        }

    }
    public void SetSound(float soundLevel)
    {

        masterMixer.SetFloat("SFX_VOL", 4 * soundLevel - 30);
    }
    public void SetMainSound(float soundLevel)
    {

        masterMixer.SetFloat("Main_VOL", -5 * soundLevel);
    }
    void change_music_play(int frequency)
    {
        Debug.Log(frequency);
        radio.clip = radioclips[frequency];
        radio.Play(0);
        current_song = frequency;
    }

    void set_volume(float frequency)
    {
        SetSound(Mathf.Abs(frequency % 10 - 5));
        SetMainSound(Mathf.Abs(frequency % 10 - 5));
    }
}



