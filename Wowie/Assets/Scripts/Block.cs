﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Block {

	public BlockType blk;
	public MagnetOrientation ori;
	public Sprite sprite;
	public List<MagnetOrientation> blacklist;
	public bool xFlip;
	public double speed=1.0;
	public bool isMagnetic=false;
	public bool isAtractive=false;
	public bool jump=false;
	public static Texture2D ola;

	public enum BlockType {
		SpeedUp=0,
		SpeedDown=1,
		Magnet=2,
		Jump=3,
		Useless=4,
		chest=5,

		CustomBlock
	}
	public enum MagnetOrientation {
		PosNeg, NegPos, PosNeu, NeuPos, NegNeu, NeuNeg, NeuNeu, NegNeg, PosPos
	}

	public Block(BlockType blk, MagnetOrientation ori=MagnetOrientation.NeuNeu) {
		this.blk = blk;
		
		//byte[] //FileData;
		this.ori = ori;

		blacklist = new List<MagnetOrientation>();

		xFlip = false;

		this.blacklist.Add(MagnetOrientation.NegPos);
		this.blacklist.Add(MagnetOrientation.NegNeu);
		this.blacklist.Add(MagnetOrientation.NegNeg);
		this.blacklist.Add(MagnetOrientation.PosNeu);
		this.blacklist.Add(MagnetOrientation.PosNeg);
		this.blacklist.Add(MagnetOrientation.PosPos);
		switch(ori) {
			case MagnetOrientation.PosNeg:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_posneg.png");
				this.blacklist.Clear();
				this.blacklist.Add(MagnetOrientation.NeuNeu);
				this.blacklist.Add(MagnetOrientation.NeuPos);
				this.blacklist.Add(MagnetOrientation.NeuNeg);
				this.blacklist.Add(MagnetOrientation.NegNeu);
				this.blacklist.Add(MagnetOrientation.NegPos);
				this.blacklist.Add(MagnetOrientation.NegNeg);
				break;
			case MagnetOrientation.NegPos:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_posneg.png");
				this.blacklist.Clear();
				this.blacklist.Add(MagnetOrientation.NeuNeu);
				this.blacklist.Add(MagnetOrientation.NeuNeg);
				this.blacklist.Add(MagnetOrientation.NeuPos);
				this.blacklist.Add(MagnetOrientation.PosNeu);
				this.blacklist.Add(MagnetOrientation.PosNeg);
				this.blacklist.Add(MagnetOrientation.PosPos);
				xFlip = true;
				break;
			case MagnetOrientation.PosNeu:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_pos.png");
				break;
			case MagnetOrientation.NeuPos:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_pos.png");
				this.blacklist.Clear();
				this.blacklist.Add(MagnetOrientation.NeuNeu);
				this.blacklist.Add(MagnetOrientation.NeuNeg);
				this.blacklist.Add(MagnetOrientation.NeuPos);
				this.blacklist.Add(MagnetOrientation.PosNeu);
				this.blacklist.Add(MagnetOrientation.PosNeg);
				this.blacklist.Add(MagnetOrientation.PosPos);
				xFlip = true;
				break;
			case MagnetOrientation.NegNeu:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_neg.png");
				xFlip = true;
				break;
			case MagnetOrientation.NeuNeg:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_neg.png");
				this.blacklist.Clear();
				this.blacklist.Add(MagnetOrientation.NeuNeu);
				this.blacklist.Add(MagnetOrientation.NeuNeg);
				this.blacklist.Add(MagnetOrientation.NeuPos);
				this.blacklist.Add(MagnetOrientation.NegPos);
				this.blacklist.Add(MagnetOrientation.NegNeu);
				this.blacklist.Add(MagnetOrientation.NegNeg);
				break;
			case MagnetOrientation.NegNeg:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_negneg.png");
				this.blacklist.Clear();
				this.blacklist.Add(MagnetOrientation.NeuNeu);
				this.blacklist.Add(MagnetOrientation.NeuNeg);
				this.blacklist.Add(MagnetOrientation.NeuPos);
				this.blacklist.Add(MagnetOrientation.NegPos);
				this.blacklist.Add(MagnetOrientation.NegNeu);
				this.blacklist.Add(MagnetOrientation.NegNeg);
				break;
			case MagnetOrientation.PosPos:
				//FileData = File.ReadAllBytes("Assets/Textures/iman_pospos.png");
				this.blacklist.Clear();
				this.blacklist.Add(MagnetOrientation.NeuNeu);
				this.blacklist.Add(MagnetOrientation.NeuNeg);
				this.blacklist.Add(MagnetOrientation.NeuPos);
				this.blacklist.Add(MagnetOrientation.PosNeu);
				this.blacklist.Add(MagnetOrientation.PosNeg);
				this.blacklist.Add(MagnetOrientation.PosPos);
				break;
			default:
				//FileData = File.ReadAllBytes("Assets/Textures/basic.png");
				break;
		}
		switch(blk) {
			case BlockType.SpeedUp:
				speed = 1.8;
				switch(ori) {
					case MagnetOrientation.PosNeg:
						//FileData = File.ReadAllBytes("Assets/Textures/speedup_posneg.png");
						break;
					case MagnetOrientation.NegPos:
						//FileData = File.ReadAllBytes("Assets/Textures/speedup_negpos.png");
						break;
					default:
						//FileData = File.ReadAllBytes("Assets/Textures/speedup.png");
						break;
				}
				xFlip = false;
				break;
			case BlockType.chest:
				//FileData = File.ReadAllBytes("Assets/Textures/chest.png");
				break;
			case BlockType.SpeedDown:
				speed = 0.5;
				//FileData = File.ReadAllBytes("Assets/Textures/speedup.png");
				xFlip = true;
				break;
			case BlockType.Magnet:
				isAtractive = true;
				break;
			case BlockType.Jump:
				jump = true;
				//FileData = File.ReadAllBytes("Assets/Anim/bloks/jump4.png");
				break;
			case BlockType.Useless:
				//FileData = File.ReadAllBytes("Assets/Textures/basic.png");
				break;
			default:
				Debug.LogError("You should NEVER read this string");
				//FileData = File.ReadAllBytes("Assets/Textures/basic.png");
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