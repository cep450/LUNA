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
    //public TextMeshPro textmeshpro;
    public AudioClip[] radioclips;
    public GameObject indicator;
    // public AudioClip static_noise;
    private AudioSource radio;
    public AudioMixer masterMixer;
    public GameObject dial;
   // public GameObject dial_2;
    public Camera orth_cam;
    private int current_song;
    float Current_mos_x = 0.0f;
    public static int current_playlist;
    void Start()
    {
        radio = GetComponent<AudioSource>();
        Debug.Log(radioclips.Length);
        current_song = 0;
        set_volume(frequency);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = orth_cam.ScreenToWorldPoint(Input.mousePosition);
       
        if (mouse_click_detector.radio_change_on)
        {

            indicator.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                if (mousePos.x>Current_mos_x)
                {
                    frequency = frequency + 0.3f * Time.deltaTime;
                    set_volume(frequency);
                    Current_mos_x = mousePos.x;
                    dial.transform.Rotate(0,0,-1.5f * Time.deltaTime,Space.Self);
                  //  dial_2.transform.Rotate(0, 0, -1.2f, Space.Self);
                }
                if (mousePos.x < Current_mos_x)
                {
                    frequency = frequency -0.3f * Time.deltaTime;
                    set_volume(frequency);
                    Current_mos_x = mousePos.x;
                    dial.transform.Rotate(0, 0, 1.5f * Time.deltaTime, Space.Self);
                   // dial_2.transform.Rotate(0, 0, 1.2f, Space.Self);
                }

            }
        }
        else {
            indicator.SetActive(false);
        }

       // Debug.Log(0.55f + ((1.78f - 0.55f) * frequency / ((radioclips.Length - 1) * 10 + 5)));
        indicator.transform.position = new Vector3(0.55f+((1.85f-0.55f)*frequency/( (radioclips.Length - 1) * 10 + 5)), indicator.transform.position.y,indicator.transform.position.z);
        if (frequency < 0)
        {
            frequency = 0;

        }
        if (frequency > (radioclips.Length - 1) * 10 + 5)
        {
            frequency = (radioclips.Length - 1) * 10 + 5;

        }

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            frequency = frequency - 0.1f;
            set_volume(frequency);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            frequency = frequency + 0.1f;
            set_volume(frequency);
        }*/
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
        current_playlist = frequency;
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



