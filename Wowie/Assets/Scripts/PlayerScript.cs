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

    private Animator anim;

    public GameObject blockPicked;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody2D> ();

        levelManager = GameObject.Find("LevelManager").GetComponent(typeof(LevelManager)) as LevelManager;
        anim = GetComponent<Animator>();

        //levelManager LevelManger = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        //When the game starts there's no item on the player
        pickedItem = false;
        anim.SetBool("moving", false);
        anim.SetInteger("Character", 0);

        //var block = Instantiate(blockPrefab, new Vector3(transform.position.x + 2f, transform.position.y - 2f, 0f), Quaternion.identity);
        //block.transform.parent = gameObject.transform;
    }

    void Update()
    {
        anim.SetBool("moving", pickedItem);
        if(pickedItem) {
            //Makes the player move to the right
            Vector3 tempVect = new Vector3(1.0f, 0f, 0f);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.transform.position += tempVect;
        }
        if(Input.GetKeyDown("space")) {
            //TODO Call the placeBLock Function on the Level Manager
            //levelManager.GetComponent<LevelManager>().placeBlock(0, 0, 0);
            levelManager.placeBlock(levelManager.nextBlock, 0, levelManager.nextBlock);
            Debug.Log("Spawning Block");
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {        
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        //levelManager.setRavina(col.gameObject);
        if(col.CompareTag("kill")) {
            Destroy(gameObject, 3);
        }
        levelManager.colission(col.gameObject);
    }
}
