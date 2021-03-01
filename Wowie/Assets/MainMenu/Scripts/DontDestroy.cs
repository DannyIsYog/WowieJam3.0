using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainMenuMusic");
        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }
            

        DontDestroyOnLoad(this.gameObject);
    }
}
