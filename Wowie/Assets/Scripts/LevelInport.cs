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

        levels.Add(new List<Block>());//level3

        List<Block> level = new List<Block>();
        levels.Add(level);
        level.Add(new Block(Block.BlockType.SpeedUp));
        level.Add(new Block(Block.BlockType.Jump));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuNeg));
        level.Add(new Block(Block.BlockType.SpeedUp, Block.MagnetOrientation.PosNeg));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeu));


        level = new List<Block>();
        levels.Add(level);
        level.Add(new Block(Block.BlockType.SpeedUp));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeg));
        level.Add(new Block(Block.BlockType.Jump));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeu));
        level.Add(new Block(Block.BlockType.Useless));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuNeg));
        


        level = new List<Block>();
        levels.Add(level);
        level.Add(new Block(Block.BlockType.SpeedUp));
        level.Add(new Block(Block.BlockType.Jump));
        level.Add(new Block(Block.BlockType.Useless));
        level.Add(new Block(Block.BlockType.SpeedUp));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuNeg));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegPos));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeu));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegNeu));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuPos));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeg));

        level = new List<Block>();
        levels.Add(level);
        level.Add(new Block(Block.BlockType.SpeedUp));
        level.Add(new Block(Block.BlockType.Jump));
        level.Add(new Block(Block.BlockType.Useless));
        level.Add(new Block(Block.BlockType.SpeedUp));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuNeg));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegPos));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeu));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NegNeu));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.NeuPos));
        level.Add(new Block(Block.BlockType.Magnet, Block.MagnetOrientation.PosNeg));


        levels.Add(new List<Block>());//level8
    }       
}
