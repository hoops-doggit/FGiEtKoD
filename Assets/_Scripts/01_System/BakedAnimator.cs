using UnityEngine;

//[ExecuteInEditMode()]
public class BakedAnimator : MonoBehaviour {
	
	public Sprite[] m_Sprites;


	public int FramesPerSecond = 8;
	public float Speed = 1.0f;
    private float sprite;
    private float spriteCounter;
    public CharacterMovement cm;

    public Sprite[] pink;
    public Sprite[] blue;
    public Sprite[] green;
    public Sprite[] orange;
    public Sprite[] yellow;


    SpriteRenderer spriteRenderer;

	
	void OnEnable()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void ChangeColor(string colour){
        switch (colour){
            case "pink":
                m_Sprites = pink;
                break;
            case "blue":
                m_Sprites = blue;
                break;
            case "green":
                m_Sprites = green;
                break;
            case "orange":
                m_Sprites = orange;
                break;
            case "yellow":
                m_Sprites = yellow;
                break;
            default:
                m_Sprites = pink;
                break;
        }


    }

	void Update() {
		if (!spriteRenderer || m_Sprites.Length == 0)
			return;
		
		float t = (float)Time.time * (int)FramesPerSecond * Speed;
		var s = m_Sprites[(int)Mathf.Repeat(t, m_Sprites.Length)];
		spriteRenderer.sprite = s;

        //For sending to the character to tell which foot is placed
        sprite = (int)Mathf.Repeat(t, m_Sprites.Length);

        if (sprite != spriteCounter)
        {
            cm.currentWalkFrame = sprite;
            spriteCounter = sprite;
        }
    }

    


}