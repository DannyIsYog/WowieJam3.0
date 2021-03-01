using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInport{
    public static List<List<Block>> levels;
    static LevelInport(){
        levels = new List<List<Block>>();
        List<Block> level0 = new List<Block>();
        level0.Add(new Block(Block.BlockType.Useless));
        level0.Add(new Block(Block.BlockType.Useless));
        levels.Add(level0);

        List<Block> level1 = new List<Block>();
        level1.Add(new Block(Block.BlockType.Jump));
        level1.Add(new Block(Block.BlockType.SpeedDown));
        level1.Add(new Block(Block.BlockType.Useless));
        levels.Add(level1);

        List<Block> level2 = new List<Block>();
        level2.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuNeg));
        level2.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegPos));
        level2.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeu));
        level2.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegNeu));
        level2.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuPos));
        level2.Add(new Block(Block.BlockType.SpeedDown));
        level2.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeg));
        levels.Add(level2);
        /*
        List<Block> level3 = new List<Block>();
        level3.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuPos));
        level3.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegNeu));
        level3.Add(new Block(Block.BlockType.SpeedDown));
        level3.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuPos));
        level3.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegPos));
        level3.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegNeu));
        level3.Add(new Block(Block.BlockType.Useless));
        level3.Add(new Block(Block.BlockType.Jump));
        levels.Add(level3);

        List<Block> level4 = new List<Block>();
        level4.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegNeg));
        level4.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosPos));
        level4.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuNeg));
        levels.Add(level4);

        List<Block> level5 = new List<Block>();
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        level5.Add(new Block(Block.BlockType.SpeedUp));
        levels.Add(level5);
        */
    }       
}
