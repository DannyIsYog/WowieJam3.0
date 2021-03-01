using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Block blk;
	public Texture2D[] tex;
	public Texture2D[] magnets;
	public Texture2D[] speedup;
	public AudioSource wiEmitter;

	private void Start() {
		wiEmitter = GetComponent<AudioSource>();
		wiEmitter.volume = PlayerPrefs.GetFloat("SoundEffectsPref");
	}

	public Sprite getSprite() {
		if(blk.blk == Block.BlockType.SpeedUp)
			return Sprite.Create(speedup[(int)blk.ori], new Rect(0.0f, 0.0f, speedup[(int)blk.ori].width, speedup[(int)blk.ori].height), new Vector2(0.5f, 0.5f), 100.0f);
		if(blk.blk==Block.BlockType.Magnet)
			return Sprite.Create(magnets[(int)blk.ori], new Rect(0.0f, 0.0f, magnets[(int)blk.ori].width, magnets[(int)blk.ori].height), new Vector2(0.5f, 0.5f), 100.0f);
		return Sprite.Create(tex[(int)blk.blk], new Rect(0.0f, 0.0f, tex[(int)blk.blk].width, tex[(int)blk.blk].height), new Vector2(0.5f, 0.5f), 100.0f);
	}
}