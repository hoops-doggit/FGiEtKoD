using UnityEngine;

//[ExecuteInEditMode()]
public class BakedAnimator : MonoBehaviour {
	
	public Sprite[] m_Sprites;
	public int FramesPerSecond = 8;
	public float Speed = 1.0f;
    private float sprite;
    private float spriteCounter;
    public CharacterMovement cm;



    SpriteRenderer spriteRenderer;

	
	void OnEnable()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update() {
		if (!spriteRenderer || m_Sprites.Length == 0)
			return;
		
		float t = (float)Time.time * (int)FramesPerSecond * Speed;
		var s = m_Sprites[(int)Mathf.Repeat(t, m_Sprites.Length)];
		spriteRenderer.sprite = s;

        //For sending to the character to tell which foot is placed
        float sprite = (int)Mathf.Repeat(t, m_Sprites.Length);

        if (sprite != spriteCounter)
        {
            cm.currentWalkFrame = sprite;
            spriteCounter = sprite;
        }
    }

    


}