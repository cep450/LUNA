using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public CarControls car;
    float limit = -50;
    float moveby = 260; 

    // Update is called once per frame
    void Update()
    {
        /*
        for(int i = transform.childCount - 1; i >= 0; i--) {
            Transform child = transform.GetChild(i);
            child.position += Vector3.back * car.getVelocity();
            if(child.position.z < limit) {
                child.position += Vector3.forward * moveby;
            }
        }
        */

        foreach(Transform child in transform) {
            child.position += Vector3.back * car.getVelocity();
            if(child.position.z < limit) {
                child.position += Vector3.forward * moveby;
            }
        }
    }
}
