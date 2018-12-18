using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class PepperShaker : MonoBehaviour {

	public bool gotHit;
	public float speed;
	public bool animating = false;
	private Animator anim;
	private DoodleAnimator ppAnim;
	public GameObject pepperShaker;
	public GameObject pepperPowder;
	private GameObject _pepperPowderClone;
	public Vector3 powderPos;
    private ColourEffect_Propogation _cep;
    private Collider col;
	// Use this for initialization

	private void Start(){
		anim = pepperShaker.GetComponent<Animator> ();
		ppAnim = pepperPowder.GetComponent<DoodleAnimator> ();
        _cep = GetComponent<ColourEffect_Propogation>();
        col = GetComponent<BoxCollider>();
	}


	private void OnTriggerEnter(Collider other)
	{
        Destroy(col);
		if (other.gameObject.tag == "player" && _cep.colourEffectText == "pink") {
			pepperPowder.SetActive (true);
			DoPowder();
			gotHit = true;
			animating = true;
			//anim.Play ("PepperJump");
			anim.SetTrigger("jump");
			other.gameObject.GetComponentInParent<CharacterMovement> ().GotHit();
			//Debug.Log ("pepper hit player");
		}

        if (other.gameObject.tag == "player" && _cep.colourEffectText != "pink")
        {
            pepperPowder.SetActive(true);
            DoPowder();
            gotHit = true;
            animating = true;
            //anim.Play ("PepperJump");
            anim.SetTrigger("jump");
            other.gameObject.GetComponentInParent<CharacterMovement>().GotHitColoured(_cep.colourEffectText);
        }

	}

	public void DoPowder(){
		StartCoroutine ("PlayPowder");
	}

	IEnumerator PlayPowder(){
		DoodleAnimator ppAnim = pepperPowder.GetComponent<DoodleAnimator>();
		yield return ppAnim.PlayAndPauseAt();
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (gotHit) {
			gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
		}
	}
}
