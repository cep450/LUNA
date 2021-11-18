using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcgenPieceGenerator
{

    public bool generate = true;

    Procgen procgen;

    //first is beginning in sequence, then random middles, then last is end
    public List<Sprite> sprites = new List<Sprite>();

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

    public bool flipsprite = false;

    
    public bool isSequence = false;

    public float scale = 1;

    public bool isAnimation = false;
    public AnimationClip animation;

    public bool dim = false;


    //these are basically constructors, it's just not good to use constructors with monobehaviors or something 
    //TODO nvm making this not a monobehavior it can just be a class. could bring back constructors if i wanted! 

    //most basic piece. just one sprite generated at a fixed position at a fixed interval. 
    //everything not sent here is set as a default or unused above. 
    //so other constructors just override default values. 
    public ProcgenPieceGenerator(Sprite s, float initx, float inity, float initz, float genapart, Procgen p) {
        sprites.Add(s);
        initxbaseline = initx;
        initybaseline = inity;
        initzbaseline = initz;
        genapartbaseline = genapart;
        procgen = p;
    }

    //TODO constructors for other things, as needed 


    // (this gets called by) Update once per frame
    public void ProcUpdate()
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
                    //pick a sprite 
                    int spriteindex = (int)(Random.Range(0, sprites.Count));
                    generateSingle(basex, basey, basez, spriteindex);
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
            int spriteindex = (int)(Random.Range(0, sprites.Count));
            generateSingle(singlex, singley, singlez, spriteindex);
        }
    }

    //generate a sequence starting at a baseline x, y, z
    private void generateSequence(float x, float y, float z, int count) {
        
        int spriteindex;
        float singlex;
        float singley;
        float singlez;

        ////beginning 
        spriteindex = 0;
        singlex = x;
        singley = y;
        singlez = z;
        generateSingle(singlex, singley, singlez, spriteindex);

        ///middle
        for(int i = 1; i < count - 1; i++) {

            singlex = x + (clumpwigglex * i);
            singley = y + (clumpwiggley * i);
            singlez = z + (clumpwigglez * i);

            //random sprite from middle 
            spriteindex = (int)(Random.Range(1, sprites.Count - 1));

            generateSingle(singlex, singley, singlez, spriteindex);
        }
        ////end 
        spriteindex = sprites.Count - 1;
        singlex = x + (clumpwigglex * count);
        singley = y + (clumpwiggley * count);
        singlez = z + (clumpwigglez * count);
        generateSingle(singlex, singley, singlez, spriteindex);
    }

    //generate a single sprite at an x, y, z coordinate 
    private void generateSingle(float x, float y, float z, int spriteindex) {
        
        //instantiate procgen.spritePrefab at xyz 
        GameObject obj = Object.Instantiate(procgen.spritePrefab, new Vector3(x, y, z), Quaternion.identity);
        

        //set the sprite
        if(isAnimation) {
            obj.GetComponent<Animation>().clip = animation;
        } else {
            obj.GetComponent<Animation>().enabled = false;
            SpriteRenderer sprRenderer = obj.GetComponent<SpriteRenderer>();
            sprRenderer.sprite = sprites[spriteindex];

            //flip if needed 
            if(flipsprite) {
                sprRenderer.flipX = true;
            }

            //dim if needed(gets darker further from road, by changing the sprite color towards black)
            if(dim) {
                float dimval = (255 - (Mathf.Clamp(Mathf.Abs(x) * 2f - 25, 0, 255))) / 255; //0-255 from road inverted, ``\
                sprRenderer.color = new Color(dimval, dimval, dimval, 1);

                
            }
        }
        
        

        obj.transform.localScale = obj.transform.localScale * scale;

        //set the parent 
        obj.transform.SetParent(procgen.transform);
        
    }

}
