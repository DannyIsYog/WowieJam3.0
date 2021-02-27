using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ONLY supports conditions for 1D placement
public class LevelManager : MonoBehaviour
{
    public List<Block> blocks;
    //define level size
    public int level = 2;
    public int x = 4;
    public int y = 1;
    //end define level size
    public Block[,] matrix;

    private int nextBlock = 0;

    /*FIXME: REMOVE FROM PRODUCTION*/
    [InspectorButton("OnButtonClicked")]
    public bool AddBlock;

    private void OnButtonClicked() {
        Debug.Log("Clicked!");
        placeBlock(nextBlock, 0,nextBlock);
        nextBlock++;
    }


    // Start is called before the first frame update
    void Start(){
        blocks = LevelInport.levels[level];
        //GameObject[] tmp = GameObject.FindGameObjectsWithTag("gameBlock");
        //blocks = new Block[tmp.Length];
        //for(int i = 0; i < tmp.Length; i++)
        //    blocks[i] = getBlock(tmp[i]);
        
        matrix = new Block[x,y];
        for(int i = 0; i < x; i++)
            for(int k = 0; k < y; k++)
                matrix[i,k] = null;
        
        /*foreach(Block blk in blocks) {
            Debug.Log(blk.blk);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool placeBlock(int x, int y, int index) {
        
        //Ve se o bloco ja está colocado
        if(isInMatrix(blocks[index]))
            return false;

        //ve se o local onde quer colocar está vazio
        if(matrix[x, y] != null)
            return false;

        //verifica se estiver na primeira posiçao se está na primeira linha
        if(x == 0 && y != 0)
            return false;

        //verifica se o bloco n está solto
        if(!(x <= this.x && y <= this.y && ((x > 0 && matrix[x - 1, y] != null) || (y > 0 && matrix[x, y - 1] != null))))
            if(x != 0 && checkBlacklist(x, y, blocks[index]))
                return false;

        matrix[x, y] = blocks[index];
        /*TODO: CHAMAR CENA Q METE BLOCO NO MUNDO*/
        Instantiate(null, new Vector3(x, y, 0f), Quaternion.identity);
        return true;
    }

    Block getBlock(GameObject obj) {
        //if(obj.CompareTag("gameBlock"))
            return obj.GetComponent<Block>();
        //return null;
    }

    bool isInMatrix(Block obj) {
        for(int i = 0; i < x; i++)
            for(int k = 0; k < y; k++)
                if(matrix[i, k] == obj)
                    return true;
        return false;
    }

    /*1D ONLY*/
    bool checkBlacklist(int x, int y, Block blk) {
        if(matrix[x - 1, y] != null)
            return isIncompatibile(blk, matrix[x - 1, y]);
        /*if(matrix[x, y - 1] != null)
            if(isIncompatibile(blk, matrix[x, y - 1]))
                return false;*/
        
        return false;
    }

    /*
     * Checks if blocks can be places next to eachother
     * Returns true if incompatible
     * TODO: MAGNETS
     */
    bool isIncompatibile(Block a, Block b, bool rec=true) {
        for(int i = 0; i < a.blacklist.Length; i++)
            if(a.blacklist[i] == b.blk)
                return true;
        if(rec)
            return isIncompatibile(b, a, false);
        return false;
    }
}
