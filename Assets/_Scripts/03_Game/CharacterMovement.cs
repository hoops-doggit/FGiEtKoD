using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class CharacterMovement : MonoBehaviour {

    public static CharacterMovement cm;

    public GameObject charContainer;
    public GameObject character;
    public Transform playerGoalPos;
    private Vector3 characterPos;
    [Header("Movement")]
    public float hsp;
    private float hspInitial;
    public float vsp;
    [Header("Gravity")]
    public float grav;
    public float oldGrav;
    public float fastGrav;
    public float timeBefore2XGrav;
    public float gravMulitplier;
    public bool gravCoRoutineOn;
    public float jumpspeed;
    private float jumpspeedInitial;
    //public float jumpHeight;
    [Header("OtherMovement")]
    public bool pushedBack;
    public float pushedBackMoveSpeed;
    public float fastPushedBackMoveSpeed;
    public float pushedBackJumpSpeed;
    //public float pushedBackJumpHeight;
    public float pushedBackAcc;
    private float pushedBackInitial;
	public float moveSpeed;
    public float maxSpeed;
    public float runSpeed;
	public float slowSpeed;
    public float fastSpeed;
    public float standingStartSpeed;
    public float doorSlowSpeed;
	public float accSpeed;
    public float accSlowSpeed;
    public float accInitial;
    public bool slowed;
    public float blueSlowSpeed;
	public float slowedDuration;
    public float blueSlowedDuration;
    public float blueSlowedAcc;
    public bool fast;
    public float fastDuration;
    public float swimSpeed;
    public float waterRunSpeed;

    public float endSceneMoveSpeed;
    public float endSceneSlowDown;
    public bool endScene;

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

    [Header("FX")]
    public GameObject burst;
    public GameObject clothesBurst;
    public ParticleSystem snowFlake;
    public ParticleSystem speedStreaks;

    [Header("clothesPile")]
    public ParticleSystem dust;
    public ParticleSystem clothesParticle01;
    public ParticleSystem clothesParticle02;
    public ParticleSystem clothesParticle03;
    public float timeToJumpAfterHittingClothesPile;
    public float timeTillClothesBurstStarts;
    public Light clothesLight;
    public float clothesLightIncrease;
    public float clothesLightMax;
    public float timeToTurnOffLight;
    private bool gotClothes;

    public Animator jumpScaler;
    public Animator runScaler;

    public Material standardMat;
    public Material shadowCasting;
    public GameObject charSpriteOBJ;

   

    //variables for modifying fast behaviour
    private float fastAccSpeedModifier = 1.1f;
    private float FastHspModifier = 1.2f;
    private float fastJumpSpeedModifier = 1.5f;

    private float fastAcc;
    private float fastHsp;
    private float fastJumpSpeed;



    private void Awake()
    {

        if (cm == null)
        {
            cm = this;
        }

        else if (cm != this)
        {
            Destroy(gameObject);
        }

        dust.Pause();
        clothesParticle01.Pause();
        clothesParticle02.Pause();
        clothesParticle03.Pause();
        snowFlake.Pause();
        speedStreaks.Pause();
        clothesLight.enabled = true;

        //charSpriteOBJ.GetComponent<ShadowCastingSprite>().enabled = false;
        //charSpriteOBJ.GetComponent<SpriteRenderer>().material = standardMat;
    }

    // Use this for initialization
    void Start()
    {
        _positionDifference = RightPos;
        //_groundContact = true;
        pushedBackInitial = pushedBackAcc;

        maxSpeed = runSpeed;
        oldGrav = grav;

        fastAcc = accSpeed * fastAccSpeedModifier;
        fastHsp =  hsp * FastHspModifier;
        fastJumpSpeed = jumpspeed * fastJumpSpeedModifier;
        accInitial = accSpeed;
        hspInitial = hsp;
        jumpspeedInitial = jumpspeed;

    }

    public void MoveLeft()
    {
        Sound_GBSfx.instance.MoveLeft();
        playerGoalPos.transform.position = new Vector3(Mathf.Clamp(playerGoalPos.transform.position.x - _positionDifference, LeftPos, RightPos), playerGoalPos.transform.position.y, playerGoalPos.transform.position.z);
    }

    public void MoveRight()
    {
        Sound_GBSfx.instance.MoveRight();
        playerGoalPos.transform.position = new Vector3(Mathf.Clamp(playerGoalPos.transform.position.x + _positionDifference, LeftPos, RightPos), playerGoalPos.transform.position.y, playerGoalPos.transform.position.z);
    }

    public void Jump()
    {
		if (trueGroundContact)
        {
            _groundContact = false;
            vsp = jumpspeed;
            jumpScaler.ResetTrigger("Jump");
            jumpScaler.SetTrigger("Jump");
            runScaler.ResetTrigger("Run");
            runScaler.SetTrigger("Jump");
            Sound_GBSfx.instance.JumpSFX();
        }        
    }


    public void Pushback()
    {
        //resets pushedBackAcc?
        Character_HitTracker.instance.AddHit();
        Sound_GBSfx.instance.GenericHit();
        pushedBackAcc = pushedBackInitial;
        trueGroundContact = false;
        _groundContact = false;
        vsp = pushedBackJumpSpeed;
        pushedBack = true;
        if (!fast)
        {
            moveSpeed = pushedBackMoveSpeed;
        }

        else if (fast){
            moveSpeed = fastPushedBackMoveSpeed;
        }
    }


	public void PlayBurst ()
	{
		StopCoroutine ("PlayBurstCR");
		StartCoroutine ("PlayBurstCR");
	}

	public void GotHit(){
		StopCoroutine ("GotHitCoroutine");
		StartCoroutine ("GotHitCoroutine");
	}

    public void GotHitColoured(string colour)
    {
        if (colour == "pink")
        {
            StartCoroutine("GotHitCoroutine");
        }

        else if (colour == "green")
        {
            StopCoroutine("GotHitColouredCoroutine");
            StartCoroutine("GotHitColouredCoroutine");
        }

        else if (colour == "blue")
        {
            StartCoroutine("SlowCoroutine");
        }

        else if (colour != "pink" || colour != "green" || colour != "blue") 
        {
            StartCoroutine("GotHitCoroutine");
        }
    }

    public void HitDoor()
    {
        StartCoroutine("HitDoorCoroutine");
        clothesLight.enabled = false;
        //charSpriteOBJ.GetComponent<SpriteRenderer>().material = shadowCasting;
        //charSpriteOBJ.GetComponent<ShadowCastingSprite>().enabled = true;
    }

    public IEnumerator HitDoorCoroutine()
    {
        slowed = true;
        moveSpeed = slowSpeed * 3;
        yield return new WaitForSeconds(slowedDuration / 2);
        slowed = false;
        //slowSpeed = slowSpeed / 3;
        StopCoroutine("HitDoorCoroutine");
    }

    //runs only when you hit a blue pepper
    public IEnumerator SlowCoroutine()
    {
        //play ice fx
        snowFlake.Play();
        Debug.Log("playing blue slow");
        float initialSlowSpeed = slowSpeed;
        float initialAccSpeed = accSpeed;
        slowed = true;
        moveSpeed = blueSlowSpeed;
        accSpeed = blueSlowedAcc;
        yield return new WaitForSeconds(blueSlowedDuration);
        slowed = false;
        slowSpeed = initialSlowSpeed;
        accSpeed = initialAccSpeed;
        Debug.Log("Stopping blue slow");
        StopCoroutine("SlowCoroutine");
    }

    public IEnumerator GotHitCoroutine()
    {
        Character_HitTracker.instance.AddHit();
        if (!fast)
        {
            slowed = true;
            moveSpeed = slowSpeed;
            accSpeed = accSlowSpeed;
        }

        if (fast)
        {
            slowed = true;
            moveSpeed = slowSpeed * 2;
        }
        yield return new WaitForSeconds(slowedDuration);
        Debug.Log("I got hit");
        slowed = false;
        accSpeed = accInitial;
        StopCoroutine("GotHitCoroutine");
    }

    public IEnumerator GotHitColouredCoroutine()
    {
        speedStreaks.Play();
        Character_HitTracker.instance.AddHit();
        FastInitial();
        yield return new WaitForSeconds(fastDuration);
        speedStreaks.Stop();
        Debug.Log("this");
        FastEnd();

        //StopCoroutine("GotHitColouredCoroutine");
    }

    public void HitTomato()
    {
        tomatoed = true;
        tomatoTime = 0;
    }

    public void HitKnife(){

    }

    public void HitClothesPile()
    {
        dust.Play();
        clothesParticle01.Play();
        clothesParticle02.Play();
        clothesParticle03.Play();
        StartCoroutine("JumpAfterGettingNewClothes");
    }

    public void EndScene(){
        print("starting character slowdown");
        endScene = true;
    }

    public void EndScene_EndOfCatWalk(){
        moveSpeed = 0;
        endSceneSlowDown = 0;

    }
    public IEnumerator JumpAfterGettingNewClothes()
    {
        yield return new WaitForSeconds(timeToJumpAfterHittingClothesPile);
        JumpOutOfClothesPile();
        yield return new WaitForSeconds(timeTillClothesBurstStarts);
        StartCoroutine("PlayClothesBurstCR");
        //yield return new WaitForSeconds(timeToTurnOffLight);
        //congratsLight.enabled = false;
    }

    public void JumpOutOfClothesPile()
    {
        if (trueGroundContact)
        {
            _groundContact = false;
            vsp = jumpspeed * 1.5f;
            jumpScaler.ResetTrigger("Jump");
            jumpScaler.SetTrigger("Jump");
            runScaler.ResetTrigger("Run");
            runScaler.SetTrigger("Jump");
        }       
    }    

    private void FastInitial()
    {
        //Fast_CameraControll.instance.GoingFast();
        fast = true;
        maxSpeed = fastSpeed;
        accSpeed = fastAcc;
        hsp = fastHsp;
        grav = fastGrav;
        jumpspeed = fastJumpSpeed;
    }

    private void FastEnd()
    {
        Debug.Log("that");
        //Fast_CameraControll.instance.NormalSpeed();
        fast = false;
        maxSpeed = runSpeed;
        accSpeed = accInitial;
        hsp = hspInitial;
        grav = oldGrav;
        jumpspeed = jumpspeedInitial;
    }

    public IEnumerator PlayBurstCR() {
        //Debug.Log("playing burst");
		burst.SetActive (true);
		DoodleAnimator animator = burst.GetComponent<DoodleAnimator>();
		yield return animator.PlayAndPauseAt(0, -1);
        animator.Stop();
		burst.SetActive (false);
		StopCoroutine ("PlayBurstCR");
	}

    public IEnumerator PlayClothesBurstCR()
    {
        Debug.Log("playing clothes burst");
        clothesBurst.SetActive(true);
        clothesLight.enabled = true;
        DoodleAnimator animator = clothesBurst.GetComponent<DoodleAnimator>();
        yield return new WaitForSeconds(0.2f);
        yield return animator.PlayAndPauseAt(0, -1);
        //yield return animator.PlayAndPauseAt(0, -1);
        //yield return animator.PlayAndPauseAt(0, -1);
        //yield return animator.PlayAndPauseAt(0, -1);
        //yield return animator.PlayAndPauseAt(0, -1);
        animator.Stop();
        //clothesLight.enabled = false;
        clothesBurst.SetActive(false);
        timeBefore2XGrav = timeBefore2XGrav / 3.5f;
        StopCoroutine("PlayClothesBurstCR");
    }

    public IEnumerator GravityTime()
    {
        vsp = 0;
        grav = 0;
        gravCoRoutineOn = true;
        if (!fast)
        {
            yield return new WaitForSeconds(timeBefore2XGrav);
            grav = oldGrav * gravMulitplier;
            StopCoroutine("GravityTime");
        }
        if (fast)
        {
            yield return new WaitForSeconds(timeBefore2XGrav * 2);
            grav = fastGrav * gravMulitplier;
            StopCoroutine("GravityTime");
        }
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

    public void UpdateGroundStats()
    {
        _groundContact = character.GetComponent<CharacterCollisions>().groundContact;
        _groundCount = character.GetComponent<CharacterCollisions>().groundCount;
    }


    // Update is called once per frame
    void FixedUpdate () {

  //      _groundContact = character.GetComponent<CharacterCollisions>().groundContact;
		//_groundCount = character.GetComponent<CharacterCollisions>().groundCount;

		if (_groundCount <= 0) {
			trueGroundContact = false;
		} 

		else if (_groundCount > 0) {
			trueGroundContact = true;
            jumpScaler.speed = 1;//this just makes character rigid
            if (!fast)
            {
                grav = oldGrav;
            }
		}

        #region normal vspeed and gravity behaviour
        if (trueGroundContact && !pushedBack && vsp < 0.0f)
        {
            vsp = 0;
            gravCoRoutineOn = false;
        }

		if (!trueGroundContact)
        {
            vsp -= grav;

            if (vsp < 0 && !gravCoRoutineOn)
            {
                StartCoroutine("GravityTime");
            }
        }

        #endregion

        #region pushed back speed and gravity behaviour
        if (trueGroundContact && pushedBack && vsp <= 0.0f)
        {
            vsp = 0;
            moveSpeed += pushedBackAcc;
            pushedBackAcc *= accSpeed;
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
        if (moveSpeed != maxSpeed && !slowed && !pushedBack && !endScene) {
			
			if (moveSpeed <= 0) {
				moveSpeed = standingStartSpeed;
			}

            if (!fast)
            {
                moveSpeed *= accSpeed;
            }

            if (fast)
            {
                moveSpeed *= (accSpeed * 2);
            }
		}


        if (moveSpeed > maxSpeed && !endScene && !fast) {
            moveSpeed = maxSpeed;
		}

        if (moveSpeed > maxSpeed && fast)
        {
            moveSpeed = maxSpeed;
        }

        if (endScene){
            if(moveSpeed > endSceneMoveSpeed){
                moveSpeed = moveSpeed * endSceneSlowDown;
            }
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

        if (_groundCount <= 0)
        {
            trueGroundContact = false;
        }

        else if (_groundCount > 0)
        {
            trueGroundContact = true;
            jumpScaler.speed = 1;//this just makes character rigid
            if (!fast)
            {
                grav = oldGrav;
            }
        }

        //if (gotClothes)
        //{
        //    clothesLight.enabled = true;
        //    if (clothesLight.intensity < clothesLightMax)
        //    {
        //        clothesLight.intensity = clothesLight.intensity + clothesLightIncrease;
        //    }
        //}

        //if (!gotClothes && clothesLight.intensity > 0)
        //{
        //    clothesLight.intensity = clothesLight.intensity - (clothesLightIncrease * 3);
        //    if (clothesLight.intensity < 0)
        //    {
        //        clothesLight.enabled = false;
        //    }
        //}
    }
}
