using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procgen : MonoBehaviour
{



    public Sprite squareexamplesprite;

    public Sprite spr_speedsign;
    public Sprite spr_birds;
    public Sprite spr_tree;
    public Sprite spr_brokencar;


    List<ProcgenPieceGenerator> generators = new List<ProcgenPieceGenerator>();


    public GameObject spritePrefab;


    //VELOCITY IS GOING TO BE THE VELOCITY OF THE CAR
    //USE getVelocity() FROM CARCONTROLS 
    public CarControls car;
    //will move all children by this and cull any who have passed the limit
    //or even, move itself by this and set itself back to 0 every so often (moving children accordingly) 
    float cullLimit = -50f;
    float zerozeroLimit = -1000f;


    // Start is called before the first frame update
    void Start()
    {

        //set up all the prefab pieces. 
        //constructor1(Sprite s, float initx, float inity, float initz, float genapart, Procgen p)
        //ProcgenPieceGenerator squareexample = new ProcgenPieceGenerator(squareexamplesprite, 5, 0, 50, 10, this);
        //generators.Add(squareexample);

        /*
        public Sprite spr_speedsign;
    public Sprite spr_birds;
    public Sprite spr_tree;
    public Sprite spr_brokencar;
        */

        ProcgenPieceGenerator speedsign = new ProcgenPieceGenerator(spr_speedsign, 7, 0, 0, 25, this);
        speedsign.genapartwiggle = 10;
        generators.Add(speedsign);

        ProcgenPieceGenerator birds = new ProcgenPieceGenerator(spr_birds, 0, 10, 100, 50, this);
        birds.genapartwiggle = 20;
        generators.Add(birds);

        ProcgenPieceGenerator brokencar = new ProcgenPieceGenerator(spr_brokencar, 15, 0, 50, 100, this);
        brokencar.genapartwiggle = 50;
        generators.Add(brokencar);

        speedsign.generate = true;
        birds.generate = true;
        brokencar.generate = true;
        

        //and, for the purposes of this demo, start generating the square. 
        //squareexample.generate = true;

        //an alternative method- control what's generating by adding or removing from the list.
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


        //CALL ALL THE GENERATORS UPDATE FUNCTIONS 
        foreach(ProcgenPieceGenerator generator in generators) {
            generator.ProcUpdate();
        }

    }

//basically the inside of a "for each child..." loop, since we can do this in the check if past limit loop to save it from looping twice 
    void tryCullChild(int i) {
        if(transform.GetChild(i).position.z < cullLimit) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}


