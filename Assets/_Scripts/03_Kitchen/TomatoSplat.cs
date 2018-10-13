using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class TomatoSplat : MonoBehaviour {

	public GameObject splat;
	private GameObject splatClone;
    public GameObject guts;
    private GameObject gutsClone;


    void OnTriggerEnter(Collider other)
	{
		other.GetComponentInParent<CharacterMovement> ().GotHit();
        other.GetComponentInParent<CharacterMovement>().HitTomato();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
		DoSplat();       
	}

    public void DoSplat() {
		StartCoroutine(PlaySequence());
        Vector3 gutsPos = new Vector3(transform.position.x, transform.position.y - 3.499f, transform.position.z + 1.5f);
        gutsClone = Instantiate(guts, gutsPos, Quaternion.Euler(90f,0f,0f));

    }

	IEnumerator PlaySplat() {
        splatClone = Instantiate(splat);
        DoodleAnimator animator = splatClone.GetComponent<DoodleAnimator>();
		yield return animator.PlayAndPauseAt();
        //nothing below this works
        Debug.Log("about to destry tomato");
		animator.Stop();
		Destroy (splatClone);
		Destroy (gameObject);
		StopCoroutine ("PlaySplat");
	}

    public IEnumerator PlaySequence()
    {
        splat.SetActive(true);
        DoodleAnimator animator = splat.GetComponent<DoodleAnimator>();
        yield return animator.PlayAndPauseAt(0, -1);
        //nothing below this works
        animator.Stop();
        splat.SetActive(false);
        StopCoroutine("PlaySequence");
    }



}
