using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcgenPieceGenerator : MonoBehaviour
{

    public bool generate = false;

    Procgen procgen;

/*
    Sprite sprite1;			//beginning in sequence 
    Sprite sprite2 = null; 		//middle in sequence 
    Sprite sprite3 = null; 		//end in sequence 
*/

    //TODO
    //List<Sprite> sprites = new List<Sprite>();

    public Sprite sprite;

    public float initxbaseline;
    public float initxwiggle = 0f;

    public float initybaseline; 
    public float initywiggle = 0f; 

    public float initzbaseline;
    public float initzwiggle = 0f;


    public float genapartbaseline;
    public float genapartwiggle = 0f; 
    public float counter = 0f; 	    //keeps track of how far we've travelled since last generation, allows for continual generation 


    public int clumpsizemin = 1;		//in sequence, min length 
    public int clumpsizemax = 1;		//in sequence, max length 

    public float clumpwigglex;		    //in sequence, distance apart x 
    public float clumpwiggley;		    //in sequence, distance apart y
    public float clumpwigglez;		    //in sequence, distance apart z

    
    public bool isSequence = false;


    //these are basically constructors, it's just not good to use constructors with monobehaviors or something 

    //most basic piece. just one sprite generated at a fixed position at a fixed interval. 
    //everything not sent here is set as a default or unused above. 
    //so other constructors just override default values. 
    public void init(Sprite s, float initx, float inity, float initz, float genapart, Procgen p) {
        sprite = s;
        initxbaseline = initx;
        initybaseline = inity;
        initzbaseline = initz;
        genapartbaseline = genapart;
        procgen = p;
    }

    //TODO constructors for other things, as needed 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //only generate if turned on 
        //generation is turned on and off externally 
        if(generate) {
            if(counter <= 0f) {
                //generate something new 

                //set when the next thing to generate is going to happen 
                counter = Random.Range(genapartbaseline - genapartwiggle, genapartbaseline + genapartwiggle);

                //generate our baseline 
                float basex = Random.Range(initxbaseline - initxwiggle, initxbaseline + initxwiggle);
                float basey = Random.Range(initybaseline - initywiggle, initybaseline + initywiggle);
                float basez = Random.Range(initzbaseline - initzwiggle, initzbaseline + initzwiggle);

                //are we generating a clump, sequence or single?
                if(clumpsizemax > 1) {

                    //ok, generating more than 1, how many to generate?
                    int count = Random.Range(clumpsizemin, clumpsizemax);

                    if(isSequence) {
                        generateSequence(basex, basey, basez, count);
                    } else {
                        generateClump(basex, basey, basez, count);
                    }

                } else {
                    //only generating a single 
                    generateSingle(basex, basey, basez);
                }

            } else {
                //not generating anything, timer counting down 
                //log how far we've travelled to the counter 
                counter -= procgen.car.getVelocity() * Time.deltaTime;
            }
        }
    }

    //generate a clump around a given baseline x, y, z
    private void generateClump(float x, float y, float z, int count) {
        
        for(int i = 0; i < count; i++) {
            float singlex = Random.Range(x - clumpwigglex, x + clumpwigglex);
            float singley = Random.Range(y - clumpwiggley, y + clumpwiggley);
            float singlez = Random.Range(z - clumpwigglez, z + clumpwigglez);
            generateSingle(singlex, singley, singlez);
        }
    }

    //generate a sequence starting at a baseline x, y, z
    private void generateSequence(float x, float y, float z, int count) {
        
        for(int i = 0; i < count; i++) {

            //TODO also need to choose which sprite. beginning middle end 

            float singlex = x + (clumpwigglex * i);
            float singley = y + (clumpwiggley * i);
            float singlez = z + (clumpwigglez * i);
            generateSingle(singlex, singley, singlez);
        }
    }

    //generate a single sprite at an x, y, z coordinate 
    private void generateSingle(float x, float y, float z) {
        
        //instantiate procgen.spritePrefab at xyz 
        GameObject obj = Instantiate(procgen.spritePrefab, new Vector3(x, y, z), Quaternion.identity);
        
        //set the sprite
        //TODO if more than 1 sprite, pick randomly
        obj.GetComponent<SpriteRenderer>().sprite = sprite;
        
        //TODO atually... make a list of sprites, make a constructor where you can input however many sprites you want and it adds them to the list- arbitrry number of arguments 
        //or an add method or something 
        
    }

}
