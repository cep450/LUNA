using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{

    float rate = 0.1f;
    float max = -1f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > max) {
            transform.Translate(Vector3.down * (rate * Time.deltaTime));
        }
    }
}
