using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public bool pickedItem;        //Boolena if the player has an item or not
    

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody2D> ();

        //When the game starts there's no item on the player
        pickedItem = false;
    }

    void Update()
    {
        if(pickedItem) {
            //Makes the player move to the right
            Vector3 tempVect = new Vector3(1.0f, 0f, 0f);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.transform.position += tempVect;
        }
    }
}
