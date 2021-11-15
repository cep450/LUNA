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

    float velocity = 18f;

    float acceleration = 2f;
    float deceleration = 2f;

    float maxvelocity = 35f;
    float baseline = 23f;
    float minvelocity = 5f;

    float lerp = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if(Input.GetKey(KeyCode.W)) {
            //W, forward, accelerate
            if(velocity < maxvelocity) {
                velocity += acceleration * Time.deltaTime;
            }

        } else if(Input.GetKey(KeyCode.S)) {
            //S, back, break 
            if(velocity > minvelocity) {
                velocity -= deceleration * Time.deltaTime;
            }

        } else {
            //not pressing either 
            //decay if going fast 
            if(velocity > baseline) {
                velocity = Mathf.Lerp(velocity, baseline, lerp);
            }
        }


    }

    public float getVelocity() {
        return velocity;
    }
}
