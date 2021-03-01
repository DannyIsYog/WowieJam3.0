using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//ONLY supports conditions for 1D placement
public class LevelManager : MonoBehaviour
{
    public List<Block> blocks;

    private List<Block> blocksCopy;
    //define level size
    public int level = 0;
    private int x;
    private int y=1;
    //end define level size
    
    public TextMeshProUGUI TutorialText;
    /* Block Stuff */
    private Block[,] matrix;
    private GameObject[,] matrixInstanced;

    private Block dummy;

    public int nextBlock = 0;

    /*Ravina Stuff */
    public GameObject ravina;
    private GameObject ravinaBlockSpawn;
    private GameObject ravinaPlayerSpawn;

    /* Prefabs */
    public GameObject PlayerPrefab; //Prefab used to spawn the player

    public GameObject Player;   //reference to the current player

    public GameObject BlockPreview = null;

    /* UI */
    public GameObject BlockPrefab; //Prefab used to spawn blocks on the UI
    public List<GameObject> button_list = new List<GameObject>();

    public Canvas canvas;

    private GameObject pov;
    public GameObject camera;

    public float cameraSpeed = 1f;

    /*FIXME: REMOVE FROM PRODUCTION*/
    [InspectorButton("OnButtonClicked")]
    public bool AddBlock;

    [InspectorButton("OnButtonClicked2")]
    public bool RemoveAll;

    private void OnButtonClicked() {
        placeBlock(nextBlock, 0,nextBlock);
    }
    private void OnButtonClicked2() {
        removeBlock();
        nextBlock=0;
    }


    // Start is called before the first frame update
    void Start(){
        setRavina(ravina);
        loadNewLevel();

        dummy = new Block(Block.BlockType.Useless);
        playerSpawn();
        setInventory();
    }

    public void loadNewLevel() {
        blocks = LevelInport.levels[level];
        blocksCopy = new List<Block>(blocks);
        this.x = blocks.Count;

        matrix = new Block[x,y];
        matrixInstanced = new GameObject[x, y];
        for(int i = 0; i < x; i++) {
            for(int k = 0; k < y; k++) {
                matrixInstanced[i, k] = null;
                matrix[i, k] = null;
            }
        }
        nextBlock = 0;
        if(pov) {
            //camera.transform.position = pov.transform.position;
            //camera.transform.position = Vector3.Lerp(camera.transform.position, pov.transform.position, cameraSpeed * Time.deltaTime);
            InvokeRepeating("moveCamera", 0.1f, 0.017f);
        }
        changeTutorialText();
    }

    void moveCamera() {
        camera.transform.position = Vector3.Lerp(camera.transform.position, pov.transform.position, cameraSpeed * Time.deltaTime);
        cameraSpeed += 0.002f;
        if(cameraSpeed >= 100) {
            CancelInvoke();
            cameraSpeed = 10;
        }
    }

    public void restartLevel() {
        removeBlock();
        loadNewLevel();
        setInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /* Blocks Functions */
    public void removeBlock() {
        for(int i = 0; i < this.x; i++) {
            if(matrix[i, 0] == null)
                return;
            matrix[i, 0] = null;
            Destroy(matrixInstanced[i, 0]);
            matrixInstanced[i, 0] = null;
        }
    }

    public void changeTutorialText() {
        switch(level) {
            case 0:
                TutorialText.text = "Select one block and press <space> to place it.\nThe objective is to reach the next mountain.";
                break;
            case 1:
                TutorialText.text = "Blocks can have special effects on your player.\nYou can press <R> to restart the level.";
                break;
            case 2:
                TutorialText.text = "\t\t\t  Magnets can only connect with 			            oposing poles.(<R> to restart)\n	                      Good Luck!";
                break;
            case 3:
                TutorialText.text = "Tutorial 4";
                break;
            default:
                break;
        }
    }

    public bool placeBlock(int x, int y, int index, bool preview=false) {

        //Ve se o bloco ja está colocado
        if(isInMatrix(blocks[index]))
            return false;

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

        GameObject blockToSpawn = Instantiate(BlockPrefab, new Vector3(0, 0, 0), new Quaternion());
        Animator anime = blockToSpawn.GetComponent<Animator>();
        anime.SetInteger("BlockType", (int)blocks[index].blk);
        anime.SetInteger("magnetism", (int)blocks[index].ori);
        blockToSpawn.name = blocks[index].blk.ToString() + nextBlock.ToString();
        blockToSpawn.GetComponent<BlockManager>().blk = blocks[index];
        SpriteRenderer tmp = blockToSpawn.GetComponent<SpriteRenderer>();
        tmp.sprite = blocks[index].sprite;
        tmp.flipX = blocks[index].xFlip;
        blockToSpawn.transform.position = new Vector3(ravinaBlockSpawn.transform.position.x + ravinaBlockSpawn.transform.localScale.x + nextBlock * 4.02f/*tmp.bounds.size.x/*4*/ + blockToSpawn.transform.localScale.x + 1, ravinaBlockSpawn.transform.position.y + ravinaBlockSpawn.transform.localScale.y - (tmp.bounds.size.y/2), 0f);
        
        if(false)
            if(!preview) {
                Debug.LogWarning(blocks[index].blk.ToString() + " " + blocks[index].ori.ToString() + ":" + nextBlock.ToString() + " flip:" + tmp.flipX + "\npos: " + blockToSpawn.transform.position);
                Debug.Log(ravinaBlockSpawn.transform.position.x);
                Debug.Log(ravinaBlockSpawn.transform.localScale.x);//fim do colider da base da ravina
                Debug.Log(nextBlock);
                Debug.Log(tmp.bounds.size.x);
                Debug.Log(blockToSpawn.transform.localScale.x);
                Debug.Log(ravinaBlockSpawn.transform.position.y);
                Debug.Log(ravinaBlockSpawn.transform.localScale.y);
                Debug.Log(tmp.bounds.size.y);
            }
            

        if(blocks[index].jump) {
            blockToSpawn.transform.localScale = new Vector3(blockToSpawn.transform.localScale.x, blockToSpawn.transform.localScale.y * 1.5f, blockToSpawn.transform.localScale.z);
            blockToSpawn.transform.position = new Vector3(ravinaBlockSpawn.transform.position.x + ravinaBlockSpawn.transform.localScale.x + nextBlock * 4.02f/*tmp.bounds.size.x/*4*/ + blockToSpawn.transform.localScale.x + 1, ravinaBlockSpawn.transform.position.y + ravinaBlockSpawn.transform.localScale.y + (1*tmp.bounds.size.y / 9), 0f);
            BoxCollider2D box = blockToSpawn.GetComponent<BoxCollider2D>();
            CircleCollider2D cir = blockToSpawn.GetComponent<CircleCollider2D>();
            box.offset = new Vector2(0,-1.5f);
            box.size = new Vector2(4, 1.5f);
            cir.offset = new Vector2(0, -1f);
            cir.radius = 1f;
        }
        if(preview) {
            blockToSpawn.GetComponent<BoxCollider2D>().enabled = false;
            blockToSpawn.GetComponent<CircleCollider2D>().enabled = false;
            //makes the blocks semi invisible
            blockToSpawn.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, 0.5f);
            BlockPreview = blockToSpawn;
        } else {
            matrix[x, y] = blocks[index];
            blocksCopy.Remove(blocks[index]);
            nextBlock++;
            if(BlockPreview) {
                Destroy(BlockPreview);
                BlockPreview = null;
            }
        }
        
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


    /* Ravina Functions */
    public void setRavina(GameObject obj) {
        bool skip = obj != ravina;
        ravina = obj;
        ravinaBlockSpawn = obj.transform.Find("Platform").gameObject;
        ravinaPlayerSpawn = obj.transform.Find("PlayerSpawn").gameObject;
        pov = obj.transform.Find("CameraTarget").gameObject;
        if(skip) {
            level++;
            loadNewLevel();
            Transform plat = ravina.transform.Find("ChestPlatform");
            if(plat) {
                plat.gameObject.SetActive(true);
            }
            ravina.transform.Find("Chest").gameObject.SetActive(true);
        }
    }

    /* Player Functions */
    public void playerSpawn() {
        if( BlockPreview) {
            Destroy(BlockPreview);
            BlockPreview = null;
        }

        if(Player) Player.GetComponent<PlayerScript>().die = true;
        Player = Instantiate(PlayerPrefab, ravinaPlayerSpawn.transform, false);
        Player.GetComponent<PlayerScript>().jumpMultiplier = 1.2f;
        setInventory();
    }

    public void colission(GameObject obj) {
        if(obj.CompareTag("Ravina")) {
            setRavina(obj);
        }
        if(obj.CompareTag("kill")) {
            playerSpawn();
        }
    }

    /* UI Inventory Functions */

    public void setInventory() {
        int block_i = 0;
        int button_i = 0;

        foreach(GameObject b in button_list) {
            b.SetActive(false);
            b.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        foreach(Block blk in blocks) {
            if(!blocksCopy.Contains(blk)) {
                block_i++;
                continue;
            }
            button_list[button_i].GetComponent<Image>().sprite = blk.sprite;
            //flips the image sprite if it needs to be
            if(blk.xFlip) {
                RectTransform tmp = button_list[button_i].GetComponent<RectTransform>();
                button_list[button_i].GetComponent<RectTransform>().localScale = new Vector3(-1,1, 1);

            }
            button_list[button_i].GetComponent<ButtonProps>().index = block_i;
            button_list[button_i].SetActive(true);

            block_i++;
            button_i++;    
        }
        canvas.gameObject.SetActive(true);
    }

    public void selectBlock(int index) {
        if(Player.GetComponent<PlayerScript>().onTheGround) {
            Player.GetComponent<PlayerScript>().newPickedItem(index);
            canvas.gameObject.SetActive(false);
        }
    }

}
