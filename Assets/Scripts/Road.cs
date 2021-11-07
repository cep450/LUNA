using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public CarControls car;
    float limit = -50;
    float moveby = 200; 

    // Update is called once per frame
    void Update()
    {

        //foreach(Transform child in transform) {
            transform.position += Vector3.back * car.getVelocity() * Time.deltaTime;
            if(transform.position.z < limit) {
                transform.position += Vector3.forward * moveby;
            }
        //}
    }
}
