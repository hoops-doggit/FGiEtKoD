using UnityEngine;

//[ExecuteInEditMode()]
public class RealBakedAnimator : MonoBehaviour {
	
	public Sprite[] m_Sprites;


	public int FramesPerSecond = 8;
	public float Speed = 1.0f;
    private float sprite;
    private float spriteCounter;
    //public CharacterMovement cm;

    public Sprite[] pink;
    public Sprite[] blue;
    public Sprite[] green;
    public Sprite[] orange;
    public Sprite[] yellow;

    //used to tell objects what to do when gb collides with them
    public string currentColour = "pink";


    private SpriteRenderer spriteRenderer;

	
	void OnEnable()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void ChangeColor(string colour){
        switch (colour){
            case "pink":
                m_Sprites = pink;
                currentColour = "pink";
                break;
            case "blue":
                m_Sprites = blue;
                currentColour = "blue";
                break;
            case "green":
                m_Sprites = green;
                currentColour = "green";
                break;
            case "orange":
                m_Sprites = orange;
                currentColour = "orange";
                break;
            case "yellow":
                m_Sprites = yellow;
                currentColour = "yellow";
                break;
            default:
                m_Sprites = pink;
                currentColour = "pink";
                break;
        }


    }

	void Update() {
		if (!spriteRenderer || m_Sprites.Length == 0)
			return;
		
		float t = (float)Time.time * (int)FramesPerSecond * Speed;
		var s = m_Sprites[(int)Mathf.Repeat(t, m_Sprites.Length)];
		spriteRenderer.sprite = s;
    }

    


}