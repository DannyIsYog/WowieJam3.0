using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block: MonoBehaviour {

	public BlockType blk;
	public BlockType[] blacklist;
	public double speed=1.0;
	public bool isMagnetic=false;
	public bool isAtractive=false;
	public bool jump=false;

	public enum BlockType {
		SpeedUp,
		SpeedDown,
		Magnet,
		Jump,
		Useless,

		CustomBlock
	}

	private enum MagnetOrientation {
		NS,SN
	}

	public Block(BlockType blk) {
		this.blk = blk;
		switch(blk) {
			case BlockType.SpeedUp:
				speed = 1.2;
				break;
			case BlockType.SpeedDown:
				speed = 0.8;
				break;
			case BlockType.Magnet:
				isAtractive = true;
				break;
			case BlockType.Jump:
				jump = true;
				break;
			case BlockType.Useless:
				break;
			default:
				Debug.LogError("You should NEVER read this string");
				break;
		}
	}
	public Block(BlockType blk, double speed, bool jump, bool isMagnetic, bool isAtractive) {
		this.blk = blk;
		this.speed = speed;
		this.jump = jump;
		this.isMagnetic = isMagnetic;
		this.isAtractive = isAtractive;	
	}

}