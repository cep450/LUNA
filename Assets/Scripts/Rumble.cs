using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour
{

    //Some rumble via perlin noise (smoother than random.)
    //Attach to a gameobject to make it move that way. 
    //since this saves and modifies the initial position, gameobject shouldnt otherwise move... 

    public float xscale;
    public float yscale;
    public float speedmult;

    public float multiplier;


    Vector3 initialXYZ;

    float halfscalex;
    float halfscaley;

    // Start is called before the first frame update
    void Start()
    {
        initialXYZ = transform.position;
        halfscalex = xscale / 2f;
        halfscaley = yscale / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = initialXYZ.x + ((xscale * Mathf.PerlinNoise(Time.time * speedmult, 0)) - halfscalex) * multiplier;
        float y = initialXYZ.y + ((yscale * Mathf.PerlinNoise(0, Time.time * speedmult)) - halfscaley) * multiplier;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
