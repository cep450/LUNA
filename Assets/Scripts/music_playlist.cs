using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_playlist : MonoBehaviour
{
    // Start is called before the first frame
    public AudioClip[] radioclips;
    public AudioClip static_noise;
    private AudioSource radio;
    private int i;
    private int j;
 
    void Start()
    {
        i = 0;
        j = 0;
        radio = GetComponent<AudioSource>();
        Debug.Log(radioclips.Length);
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider.gameObject.name == "Radio_Button_Next")
            {
              
                radio.clip = static_noise;
                radio.Play(0);
                StartCoroutine(music_change());
                j = 1;
            }
            if (hit.collider.gameObject.name == "Radio_Button_Previous")
            {

                radio.clip = static_noise;
                radio.Play(0);
                StartCoroutine(music_change());
                j = -1;

            }
        }
    }
    IEnumerator music_change()
    {
        yield return new WaitForSeconds(1.5f);
        i = i + j;
        if (i<0)
        {
            i = radioclips.Length-1;

        }
        if (i > radioclips.Length-1)
        {
            i = 0;

        }
        radio.clip = radioclips[i];
        radio.Play(0);
    }
}
