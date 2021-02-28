using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonProps : MonoBehaviour
{
    // Start is called before the first frame update

    public Block block;

    public LevelManager levelManager;

    public 
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent(typeof(LevelManager)) as LevelManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void blockSelected() {
        levelManager.selectBlock(block);
    }
}
