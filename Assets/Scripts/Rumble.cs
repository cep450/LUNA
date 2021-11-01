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


    Vector3 initialXYZ;

    // Start is called before the first frame update
    void Start()
    {
        initialXYZ = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = initialXYZ.x + (xscale * Mathf.PerlinNoise(Time.time * speedmult, 0));
        float y = initialXYZ.y + (yscale * Mathf.PerlinNoise(0, Time.time * speedmult));
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
