using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour
{

/*

stuff like making the car go faster or slower
THIS CLASS IS NEEDED CAUSE THE PROCGEN READS ITS VELOCITY VARIABLE TO MOVE
can also control audio related to the car's speed 


*/

    float velocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getVelocity() {
        return velocity;
    }
}
