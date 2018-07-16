using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public GameObject charContainer;
    public GameObject character;
    public Transform playerGoalPos;
    private Vector3 characterPos;
    public float hsp;
    public float vsp;
    public float grav;
    public float jumpspeed;
    public float jumpHeight;
    public float runSpeed;


    public float LeftPos;
    public float CentrePos;
    public float RightPos;

    private float _positionDifference;
    public bool _groundContact;

    public void MoveLeft()
    {
        playerGoalPos.transform.position = new Vector3(Mathf.Clamp(playerGoalPos.transform.position.x - _positionDifference, LeftPos, RightPos), playerGoalPos.transform.position.y, playerGoalPos.transform.position.z);
    }

    public void MoveRight()
    {
        playerGoalPos.transform.position = new Vector3(Mathf.Clamp(playerGoalPos.transform.position.x + _positionDifference, LeftPos, RightPos), playerGoalPos.transform.position.y, playerGoalPos.transform.position.z);
    }

    public void Jump()
    {
        if (_groundContact)
        {

            _groundContact = false;
            vsp = jumpspeed;
            
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("thing");
        if (col.gameObject.tag == "ground")
        {
            _groundContact = true;
            vsp = 0;
        }
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            _groundContact = false;
        }
    }

    // Use this for initialization
    void Start () {
        _positionDifference = RightPos;
        _groundContact = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        _groundContact = character.GetComponent<CharacterCollisions>().groundContact;

        if (_groundContact && vsp < 0.0f)
        {
            vsp = 0;
        }

        if (!_groundContact && vsp > -jumpHeight)
        {
            vsp -= grav;
        }

        float step = hsp * Time.deltaTime;

        characterPos = new Vector3(Mathf.MoveTowards(character.transform.position.x, playerGoalPos.position.x, step), character.transform.position.y + vsp, character.transform.position.z);

        character.transform.position = characterPos;

        charContainer.transform.position = new Vector3(charContainer.transform.position.x, charContainer.transform.position.y, charContainer.transform.position.z + runSpeed);
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }
}
