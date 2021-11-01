using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procgen : MonoBehaviour
{



    public Sprite squareexample;
    ProcgenPieceGenerator squareexamplegen;



    public GameObject spritePrefab;


    //VELOCITY IS GOING TO BE THE VELOCITY OF THE CAR
    //USE getVelocity() FROM CARCONTROLS 
    public CarControls car;
    //will move all children by this and cull any who have passed the limit
    //or even, move itself by this and set itself back to 0 every so often (moving children accordingly) 
    float cullLimit = 10f;
    float zerozeroLimit = -1000f;


    // Start is called before the first frame update
    void Start()
    {

        //set up all the prefab pieces. 
        squareexamplegen = new ProcgenPieceGenerator();
        //squareexamplegen.init();

        

        //and, for the purposes of this demo, start generating the square. 
        //////////squareexamplegen.generate = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //move self by velocity 
        transform.Translate(Vector3.back * car.getVelocity() * Time.deltaTime);

        //check if past limit, move back to 0,0 if so 
        if(transform.position.z < zerozeroLimit) {
            transform.Translate(Vector3.back * zerozeroLimit);
            //update childrens' locations to return them to their original positions
            for(int i = 0; i < transform.childCount; i++) {
                if(!transform.GetChild(i).Equals(transform)) {
                    transform.GetChild(i).Translate(Vector3.back * zerozeroLimit);
                    tryCullChild(i);
                }
            }
        } else {
            //cull any children past limit 
            for(int i = 0; i < transform.childCount; i++) {
                tryCullChild(i);
            }
        }
    }

//basically the inside of a "for each child..." loop, since we can do this in the check if past limit loop to save it from looping twice 
    void tryCullChild(int i) {
        if(transform.GetChild(i).position.z > cullLimit) {
            Destroy(transform.GetChild(i));
        }
    }
}


