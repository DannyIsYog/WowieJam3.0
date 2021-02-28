using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public bool pickedItem;        //Boolean if the player has an item or not
    
    public GameObject blockPrefab; //GameObject that will be used to instatiate the block

    public LevelManager levelManager;//Reference to the Level Manager 

    private AudioSource wiEmitter;

    public AudioClip []wi;
    public AudioClip []we;

    private Animator anim;

    public int blockPicked = -1;

    public bool die = false;
    public bool onTheGround = false;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody2D> ();

        levelManager = GameObject.Find("LevelManager").GetComponent(typeof(LevelManager)) as LevelManager;
        anim = GetComponent<Animator>();

        wiEmitter = GetComponent<AudioSource>();
        

        //levelManager LevelManger = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        //When the game starts there's no item on the player
        pickedItem = false;
        anim.SetBool("moving", false);

        anim.SetInteger("Character", PlayerPrefs.GetInt("selectedCharater"));

        //var block = Instantiate(blockPrefab, new Vector3(transform.position.x + 2f, transform.position.y - 2f, 0f), Quaternion.identity);
        //block.transform.parent = gameObject.transform;
    }

    void Update()
    {
        anim.SetBool("moving", pickedItem);
        if(pickedItem && onTheGround) {
            //Makes the player move to the right
            Vector3 tempVect = new Vector3(1.0f, 0f, 0f);
            transform.Translate(tempVect * Time.deltaTime * speed);
            
        }
        if(Input.GetKeyDown("space") && !die && blockPicked != -1) {
            levelManager.placeBlock(levelManager.nextBlock, 0, blockPicked);
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Restarting Level");
            levelManager.restartLevel();
        }

    }

    void getProperties(Collider2D col) {
        Block blk = col.GetComponent<BlockManager>().blk;
        this.speed = this.speed * (float) blk.speed;

        if(blk.jump) {
            rb.AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
            col.GetComponent<Animator>().SetTrigger("Jump");
            wiEmitter.clip = wi[(int)Random.Range(0,wi.Length)];
            wiEmitter.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {        
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        //levelManager.setRavina(col.gameObject);
        if(col.CompareTag("kill")) {
            wiEmitter.clip = we[(int)Random.Range(0, we.Length)];
            wiEmitter.Play();
            Destroy(gameObject, 3);
        }
        else if(col.CompareTag("gameBlock")) {
            getProperties(col);
        } else if(col.CompareTag("RavinaGround")) {
            onTheGround = true;
        }
        levelManager.colission(col.gameObject);
    }

    public void newPickedItem(int index) {
        blockPicked = index;
        pickedItem = true;
        levelManager.placeBlock(levelManager.nextBlock, 0, blockPicked, true);
    }
}
