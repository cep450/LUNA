using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitchToVelocity : MonoBehaviour
{

    AudioSource audioSource;

    public CarControls car;

    float pitchmult = 0.09f;
    //float veloffset = 0f;
   // float pitchlinear = 0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        //audioSource.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.pitch = (car.getVelocity() + veloffset) * pitchmult + pitchlinear;
        audioSource.pitch = car.getVelocity() * pitchmult;
        Debug.Log(audioSource.pitch);
    }
}
