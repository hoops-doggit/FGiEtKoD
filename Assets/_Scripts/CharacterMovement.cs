using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

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
	public float moveSpeed;
    public float runSpeed;
	public float slowSpeed;
	public float accSpeed;
	public bool slowed;
	public float slowedDuration;


    public float LeftPos;
    public float CentrePos;
    public float RightPos;

    private float _positionDifference;
    public bool _groundContact;
	public int _groundCount;
	public bool trueGroundContact;

	public GameObject burst;

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
		if (trueGroundContact)
        {

            _groundContact = false;
            vsp = jumpspeed;
            
        }
    }

	/*
    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("thing");
        if (col.gameObject.tag == "ground")
        {
            _groundContact = true;
			_groundCount++;
            vsp = 0;
        }

		if (col.gameObject.tag == "jellybean") {
			PlayBurst();
		}
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            _groundContact = false;
			//_groundCount--;
        }
    }

*/

	public void PlayBurst ()
	{
		StopCoroutine ("PlaySequence");
		StartCoroutine ("PlaySequence");
	}

	public void GotHit(){
		StopCoroutine ("GotHitCorourine");
		StartCoroutine ("GotHitCoroutine");
	}

	public IEnumerator GotHitCoroutine(){
		slowed = true;
		moveSpeed = slowSpeed;
		Debug.Log ("things are things if they have things");
		yield return new WaitForSeconds (slowedDuration);
		slowed = false;
		StopCoroutine( "GotHitCoroutine" );
	}

	public IEnumerator PlaySequence() {
		burst.SetActive (true);
		DoodleAnimator animator = burst.GetComponent<DoodleAnimator>();
		yield return animator.PlayAndPauseAt(0,-1);
		animator.Stop();
		burst.SetActive (false);
		StopCoroutine ("PlaySequence");

	}



    // Use this for initialization
    void Start () {
        _positionDifference = RightPos;
        //_groundContact = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        _groundContact = character.GetComponent<CharacterCollisions>().groundContact;
		_groundCount = character.GetComponent<CharacterCollisions>().groundCount;

		if (_groundCount <= 0) {
			trueGroundContact = false;
		} 

		else if (_groundCount > 0) {
			trueGroundContact = true;
		}

		if (trueGroundContact && vsp < 0.0f)
        {
            vsp = 0;
        }

		if (!trueGroundContact && vsp > -jumpHeight)
        {
            vsp -= grav;
        }

        float step = hsp * Time.deltaTime;

        characterPos = new Vector3(Mathf.MoveTowards(character.transform.position.x, playerGoalPos.position.x, step), character.transform.position.y + vsp, character.transform.position.z);

        character.transform.position = characterPos;

		//speed up
		if (moveSpeed < runSpeed && !slowed) {
			
			if (moveSpeed <= 0) {
				moveSpeed = 0.03f;
			}

			moveSpeed = moveSpeed * accSpeed;
		}

		if (moveSpeed > runSpeed) {
			moveSpeed = runSpeed;
		}
			
			

		charContainer.transform.position = new Vector3(charContainer.transform.position.x, charContainer.transform.position.y, charContainer.transform.position.z + moveSpeed);
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
