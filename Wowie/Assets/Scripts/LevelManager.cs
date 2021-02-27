using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ONLY supports conditions for 1D placement
public class LevelManager : MonoBehaviour
{
    public List<Block> blocks;
    //define level size
    public int level = 3;
    public int x = 4;
    public int y = 1;
    //end define level size
    public Block[,] matrix;
    public GameObject[,] matrixInstanced;

    public GameObject ravina;
    public GameObject ravinaBlockSpawn;

    public GameObject ravinaPlayerSpawn;

    public int nextBlock = 0;

    public Block dummy;

    public GameObject PlayerPrefab;

    /*FIXME: REMOVE FROM PRODUCTION*/
    [InspectorButton("OnButtonClicked")]
    public bool AddBlock;

    [InspectorButton("OnButtonClicked2")]
    public bool RemoveAll;

    private void OnButtonClicked() {
        placeBlock(nextBlock, 0,nextBlock);
        nextBlock++;
    }
    private void OnButtonClicked2() {
        removeBlock();
        nextBlock=0;
    }


    // Start is called before the first frame update
    void Start(){
        blocks = LevelInport.levels[level];
        this.x = blocks.Count;
        //GameObject[] tmp = GameObject.FindGameObjectsWithTag("gameBlock");
        //blocks = new Block[tmp.Length];
        //for(int i = 0; i < tmp.Length; i++)
        //    blocks[i] = getBlock(tmp[i]);

        matrix = new Block[x,y];
        matrixInstanced = new GameObject[x, y];
        for(int i = 0; i < x; i++)
            for(int k = 0; k < y; k++) {
                matrixInstanced[i, k] = null;
                matrix[i, k] = null;
            }
        dummy = new Block(Block.BlockType.Useless);
        playerSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeBlock() {
        for(int i = 0; i < this.x; i++) {
            if(matrix[i, 0] == null)
                return;
            matrix[i, 0] = null;
            Destroy(matrixInstanced[i, 0]);
            matrixInstanced[i, 0] = null;
        }
    }

    public bool placeBlock(int x, int y, int index) {

        /*Debug.Log(blocks);
        Debug.Log(index);
        Debug.Log(blocks[index]);
        Debug.Log(blocks[index].blk.ToString());*/

        //Ve se o bloco ja está colocado
        if(isInMatrix(blocks[index]))
            return false;

       // Debug.Log(1);

        //ve se o local onde quer colocar está vazio
        if(matrix[x, y] != null)
            return false;

        //verifica se estiver na primeira posiçao se está na primeira linha
        if(x == 0 && y != 0)
            return false;

        //verifica se o bloco está dentro da matrix
        if(!(x <= this.x && x >= 0))
            return false;

        if(x == 0) {
            if(isIncompatibile(blocks[index], dummy)) {
                return false;
            }
        } else {
            if(matrix[x - 1, y] == null) {
                return false;
            }
            if(isIncompatibile(blocks[index], matrix[x - 1, y])) {
                return false;
            }
        }

        matrix[x, y] = blocks[index];
        GameObject blockToSpawn = new GameObject();
        blockToSpawn.transform.position = new Vector3(ravinaBlockSpawn.transform.position.x + ravinaBlockSpawn.transform.localScale.x + nextBlock * 4 + blockToSpawn.transform.localScale.x, y, 0f);
        blockToSpawn.name = blocks[index].blk.ToString();
        blockToSpawn.AddComponent<BlockManager>();
        blockToSpawn.GetComponent<BlockManager>().blk = blocks[index];
        blockToSpawn.AddComponent<SpriteRenderer>();
        blockToSpawn.GetComponent<SpriteRenderer>().sprite = blocks[index].sprite;
        blockToSpawn.GetComponent<SpriteRenderer>().flipX = blocks[index].xFlip;
        blockToSpawn.AddComponent<BoxCollider2D>();

        matrixInstanced[x, y] = blockToSpawn;

        return true;
    }

    Block getBlock(GameObject obj) {
        return (obj.GetComponent<BlockManager>()).blk;
    }

    bool isInMatrix(Block obj) {
        for(int i = 0; i < x; i++)
            for(int k = 0; k < y; k++)
                if(matrix[i, k] == obj)
                    return true;
        return false;
    }


    /*
     * Checks if blocks can be places next to eachother
     * Returns true if incompatible
     * TODO: MAGNETS
     */
    bool isIncompatibile(Block a, Block b) {
        //VERIFICA SE O BLOCO A ESTA NA BLACKLIST DE B
        foreach(Block.MagnetOrientation ori in b.blacklist) {
            if(ori == a.ori) {
                return true;
            }
        }
        return false;
    }

    public void setRavina(GameObject obj) {
        ravina = obj;
        ravinaBlockSpawn = obj.transform.Find("Platform").gameObject;
        ravinaPlayerSpawn = obj.transform.Find("PlayerSpawn").gameObject;
        //todo: ao chegar a ravina passar de nivel
    }

    public void playerSpawn() {
        Instantiate(PlayerPrefab, ravinaPlayerSpawn.transform, false);
    }

    public void colission(GameObject obj) {
        if(obj.CompareTag("Ravina")) {
            setRavina(obj);
        }
        if(obj.CompareTag("kill")) {
            playerSpawn();
        }
    }


}
