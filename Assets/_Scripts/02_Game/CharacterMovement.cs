using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class CharacterMovement : MonoBehaviour {

    public GameObject charContainer;
    public GameObject character;
    public Transform playerGoalPos;
    private Vector3 characterPos;
    [Header("Movement")]
    public float hsp;
    public float vsp;
    public float grav;
    public float jumpspeed;
    public float jumpHeight;
    public bool pushedBack;
    public float pushedBackMoveSpeed;
    public float pushedBackJumpSpeed;
    public float pushedBackJumpHeight;
    public float pushedBackAcc;
    private float pushedBackInitial;
	public float moveSpeed;
    public float runSpeed;
	public float slowSpeed;
	public float accSpeed;
    public float accInitial;
    public bool slowed;
	public float slowedDuration;
    [Header("lane positions")]
    public float LeftPos;
    public float CentrePos;
    public float RightPos;

    private float _positionDifference;
    public bool _groundContact;
	public int _groundCount;
	public bool trueGroundContact;

    [Header("tomato")]
    public GameObject tomatoFootprint;
    private GameObject tomatoFootprintClone;
    public Transform leftFootprintSpawnLocation;
    public Transform rightFootprintSpawnLocation;
    public bool tomatoed;
    private int tomatoTime = 0;
    public int maxTomatoTime;
    private float lastWalkFrame;
    public float currentWalkFrame;

    public GameObject burst;

    [Header("clothesPile")]
    public ParticleSystem dust;
    public ParticleSystem clothesParticle01;
    public ParticleSystem clothesParticle02;
    public ParticleSystem clothesParticle03;

    private void Awake()
    {
        dust.Pause();
        clothesParticle01.Pause();
        clothesParticle02.Pause();
        clothesParticle03.Pause();
    }

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

    public void Pushback()
    {
        pushedBackAcc = pushedBackInitial;
        trueGroundContact = false;
        _groundContact = false;
        vsp = pushedBackJumpSpeed;
        pushedBack = true;
        moveSpeed = pushedBackMoveSpeed;
    }


	public void PlayBurst ()
	{
		StopCoroutine ("PlaySequence");
		StartCoroutine ("PlaySequence");
	}

	public void GotHit(){
		StopCoroutine ("GotHitCorourine");
		StartCoroutine ("GotHitCoroutine");
	}

    public void HitTomato()
    {
        tomatoed = true;
        tomatoTime = 0;
    }

    public void HitClothesPile()
    {
        dust.Play();
        clothesParticle01.Play();
        clothesParticle02.Play();
        clothesParticle03.Play();
        if (trueGroundContact)
        {
            _groundContact = false;
            vsp = jumpspeed;
        }
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

        pushedBackInitial = pushedBackAcc;
    }
           
    void GenerateTomatoSplat(string side)
    {
        if (side == "left")
        {
            tomatoFootprintClone = Instantiate(tomatoFootprint, leftFootprintSpawnLocation.position, leftFootprintSpawnLocation.rotation);
            //tomatoFootprintClone.transform.SetParent(transform,false);
        }
        if (side == "right")
        {
            tomatoFootprintClone = Instantiate(tomatoFootprint, rightFootprintSpawnLocation.position, rightFootprintSpawnLocation.rotation);
        }
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

        #region normal vspeed and gravity behaviour
        if (trueGroundContact && !pushedBack && vsp < 0.0f)
        {
            vsp = 0;
        }

		if (!trueGroundContact)
        {
            vsp -= grav;
        }
        #endregion

        #region pushed back speed and gravity behaviour
        if (trueGroundContact && pushedBack && vsp <= 0.0f)
        {
            vsp = 0;
            moveSpeed = moveSpeed + pushedBackAcc;
            pushedBackAcc = pushedBackAcc * accSpeed;
        }

        if (trueGroundContact && pushedBack && moveSpeed > 0)
        {
            pushedBack = false;
        }
        #endregion



        float step = hsp * Time.deltaTime;

        characterPos = new Vector3(Mathf.MoveTowards(character.transform.position.x, playerGoalPos.position.x, step), character.transform.position.y + vsp, character.transform.position.z);

        character.transform.position = characterPos;

		//speed up
		if (moveSpeed < runSpeed && !slowed && !pushedBack) {
			
			if (moveSpeed <= 0) {
				moveSpeed = accInitial;
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

        if (tomatoed == true)
        {
            tomatoTime++;
            if (trueGroundContact == true)
            {
                if (currentWalkFrame != lastWalkFrame)
                {
                    if (currentWalkFrame == 0)
                    {
                        GenerateTomatoSplat("left");
                    }

                    if (currentWalkFrame == 1)
                    {
                        GenerateTomatoSplat("right");
                    }

                    lastWalkFrame = currentWalkFrame;
                }
            }
            if (tomatoTime > maxTomatoTime)
            {
                tomatoTime = 0;
                tomatoed = false;
            }
        }
    }
}
