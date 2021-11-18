using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procgen : MonoBehaviour
{



    public Sprite squareexamplesprite;

    public Sprite spr_speedsign;
    public Sprite spr_birds;
    public Sprite spr_tree1;
    public Sprite spr_tree2;
    public Sprite spr_guardrail;
    public AnimationClip birdsanim;


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

        ProcgenPieceGenerator speedsign = new ProcgenPieceGenerator(spr_speedsign, 11.5f, -4.1f, 500, 325, this);
        speedsign.genapartwiggle = 50;
        generators.Add(speedsign);

        ProcgenPieceGenerator birds = new ProcgenPieceGenerator(spr_birds, 0, 30, 500, 100, this);
        birds.genapartwiggle = 20;
        birds.initxwiggle = 100;
        birds.initywiggle = 10;
        birds.genapartwiggle = 40;
        birds.scale = 2;
        birds.isAnimation = true;
        birds.animation = birdsanim;
        generators.Add(birds);

        ProcgenPieceGenerator trees = new ProcgenPieceGenerator(spr_tree1, 60, -4.1f, 500, 200, this);
        trees.clumpsizemax = 8;
        trees.clumpsizemin = 1;
        trees.clumpwigglex = 15;
        trees.clumpwiggley = 0;
        trees.clumpwigglez = 15;
        trees.initxwiggle = 30;
        trees.sprites.Add(spr_tree2);
        trees.genapartwiggle = 100;
        trees.dim = true;

        generators.Add(trees);

        ProcgenPieceGenerator treesLeft = new ProcgenPieceGenerator(spr_tree1, trees.initxbaseline, trees.initybaseline, trees.initzbaseline, trees.genapartbaseline, this);
        treesLeft.clumpsizemax = 8;
        treesLeft.clumpsizemin = 1;
        treesLeft.clumpwigglex = 15;
        treesLeft.clumpwiggley = 0;
        treesLeft.clumpwigglez = 15;
        treesLeft.initxwiggle = 30;
        treesLeft.initxbaseline = -trees.initxbaseline - 2.5f;
        treesLeft.sprites.Add(spr_tree2);
        treesLeft.genapartwiggle = 100;
        treesLeft.dim = true; 
        treesLeft.flipsprite = true;
        
        generators.Add(treesLeft);

        ProcgenPieceGenerator guardrail = new ProcgenPieceGenerator(spr_guardrail, 10, -4.1f, 400, 50, this);
        guardrail.genapartwiggle = 20;
        generators.Add(guardrail);

        speedsign.generate = true;
        birds.generate = true;
        trees.generate = true;
        guardrail.generate = false;
        

        //an alternative method- control what's generating by adding or removing from the list.
    }

    // Update is called once per frame
    void Update()
    {

        //for each child (generated object)...
        for(int i = 0; i < transform.childCount; i++) {

            //move the child by velocity 
            transform.GetChild(i).Translate(Vector3.back * car.getVelocity() * Time.deltaTime);

            //if any move past the limit, cull them 
            tryCullChild(i);
        }
        
        //move self by velocity 
        //transform.Translate(Vector3.back * car.getVelocity() * Time.deltaTime);
        
        //move children by velocity 

/*
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
        }*/



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


