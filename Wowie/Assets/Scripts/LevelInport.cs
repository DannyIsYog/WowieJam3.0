﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInport : MonoBehaviour{
    public static List<List<Block>> levels;
    static LevelInport(){
        levels = new List<List<Block>>();
        List<Block> level0 = new List<Block>();

        level0.Add(new Block(Block.BlockType.Useless));
        levels.Add(level0);

        List<Block> level1 = new List<Block>();
        level1.Add(new Block(Block.BlockType.Useless));
        level1.Add(new Block(Block.BlockType.SpeedUp));
        levels.Add(level1);

        List<Block> level2 = new List<Block>();
        level2.Add(new Block(Block.BlockType.Useless));
        level2.Add(new Block(Block.BlockType.SpeedUp));
        level2.Add(new Block(Block.BlockType.Jump));
        levels.Add(level2);
    }       
        
        /*
            [new Block(Block.BlockType.Useless), new Block(Block.BlockType.SpeedUp)],
            [new Block(Block.BlockType.Useless), new Block(Block.BlockType.SpeedUp), new Block(Block.BlockType.Jump)] }
        */
}