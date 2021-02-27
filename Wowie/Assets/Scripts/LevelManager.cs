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

    public GameObject ravina;
    public GameObject ravinaBlockSpawn;

    public GameObject ravinaPlayerSpawn;

    public int nextBlock = 0;

    public Block dummy;

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
        dummy = new Block(Block.BlockType.Useless);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool removeBlock(int x, int y) {
        if(matrix[x, y] == null)
            return false;

        return false;
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

       // Debug.Log(1);

        //verifica se estiver na primeira posiçao se está na primeira linha
        if(x == 0 && y != 0)
            return false;

        //Debug.Log(1);

        //verifica se o bloco está dentro da matrix
        if(!(x <= this.x && x >= 0))
            return false;

        //Debug.Log(1);
        if(x == 0) {
            if(isIncompatibile(blocks[index], dummy)) {
                Debug.Log(1);
                return false;
            }
        } else {
            if(matrix[x - 1, y] == null) {
                Debug.Log(2);
                return false;
            }
            if(isIncompatibile(blocks[index], matrix[x - 1, y])) {
                Debug.Log(3);
                return false;
            }
        }
        Debug.Log(4);

        matrix[x, y] = blocks[index];



        /*TODO: CHAMAR CENA Q METE BLOCO NO MUNDO*/

        //para experimentar faz play; vai ao LevelManagee e está la um butao "Add Block"
        //isso vai adicionar um block
        //n está implementado escolher o "seginte"
        //e o load do sprite está pior q mau
        //I wish you the best of luck
        //os Sprite sºao "loaded" no Block
        //no codigo abaixo esses blocos sºao loaded para o BlockManager q é adicionado ao novo game object
        //n percebi como usar o instanciate...
        //pls muda o load das texturas no Block...
        //Good night :zzz:
        //P.S.: no idea how to use the Prefab in this scenario, I'm building the GameObject from scratch ;)


        GameObject blockToSpawn = new GameObject();
        blockToSpawn.transform.position = new Vector3(ravinaBlockSpawn.transform.position.x + ravinaBlockSpawn.transform.localScale.x + nextBlock * 4 + blockToSpawn.transform.localScale.x, y, 0f);
        blockToSpawn.name = blocks[index].blk.ToString();
        blockToSpawn.AddComponent<BlockManager>();
        blockToSpawn.GetComponent<BlockManager>().blk = blocks[index];
        blockToSpawn.AddComponent<SpriteRenderer>();
        blockToSpawn.GetComponent<SpriteRenderer>().sprite = blocks[index].sprite;
        blockToSpawn.AddComponent<BoxCollider2D>();




        //Instantiate(blockToSpawn, new Vector3(nextBlock * 2, y, 0f), Quaternion.identity);
        return true;
    }

    Block getBlock(GameObject obj) {
        //if(obj.CompareTag("gameBlock"))
            return (obj.GetComponent<BlockManager>()).blk;
        //return null;
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
        ravinaBlockSpawn = obj.transform.Find("PlatformTest").gameObject;
    }
}
