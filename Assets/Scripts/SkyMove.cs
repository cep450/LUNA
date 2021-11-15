using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{

    float rate = 0.23f;
    //float max = -1f;

    public bool skyforever;
    float skymin = -130;
    float skymoveup = 130 + 364;

    // Update is called once per frame
    void Update()
    {
        //if(transform.position.y > max) {
            transform.Translate(Vector3.down * (rate * Time.deltaTime));
        //}
        if(skyforever && transform.position.y < skymin) {
            transform.Translate(Vector3.up * skymoveup);
        }
    }
}
