using UnityEngine;
using System.Collections.Generic;

public class Clothes_BakedAnimator : MonoBehaviour {
	
    public List<Sprite> m_Sprites;


	public int FramesPerSecond = 8;
	public float Speed = 1.0f;
    private float sprite;
    private float spriteCounter;
    private SpriteRenderer spriteRenderer;
    public string topClothesName;
    public string bottomClothesName;

	void OnEnable()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}


	void Update()
    {
		if (!spriteRenderer || m_Sprites.Count == 0)
			return;
		
		float t = (float)Time.time * (int)FramesPerSecond * Speed;
        var s = m_Sprites[(int)Mathf.Repeat(t, m_Sprites.Count)];
		spriteRenderer.sprite = s;

        //For sending to the character to tell which foot is placed
        //sprite = (int)Mathf.Repeat(t, m_Sprites.Length);

        //if (sprite != spriteCounter)
        //{
        //    cm.currentWalkFrame = sprite;
        //    spriteCounter = sprite;
        //}
    }

    


}