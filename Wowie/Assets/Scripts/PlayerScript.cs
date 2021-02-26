using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public bool pickedItem;        //Boolena if the player has an item or not
    
    public GameObject blockPrefab;       //GameObject that will be used to instatiate the block

    public GameObject levelManager;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody2D> ();

        //When the game starts there's no item on the player
        pickedItem = false;

        //var block = Instantiate(blockPrefab, new Vector3(transform.position.x + 2f, transform.position.y - 2f, 0f), Quaternion.identity);
        //block.transform.parent = gameObject.transform;

        //
    }

    void Update()
    {
        if(pickedItem) {
            //Makes the player move to the right
            Vector3 tempVect = new Vector3(1.0f, 0f, 0f);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.transform.position += tempVect;
        }
        levelManager.GetComponent<LevelManager>().placeBlock(0, 0, 0);
    }
}
