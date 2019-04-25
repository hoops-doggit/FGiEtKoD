using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class TomatoSplat : MonoBehaviour {

    [SerializeField]
    private GameObject splat;
	private GameObject splatClone;
    public GameObject guts;
    [SerializeField]
    private Transform parent;
    //commented out to try to minimise. It still exists as a self contained var
    //private GameObject gutsClone;
    private Collider myBoxCollider;

    private void OnEnable()
    {
        myBoxCollider = GetComponent<BoxCollider>();
        splat = _GM.instance.GetComponent<Tomato_SplatHolder>().splat;
    }

    private void Start()
    {
        splat = _GM.instance.GetComponent<Tomato_SplatHolder>().splat;
    }

    void OnTriggerEnter(Collider other)
	{
		other.GetComponentInParent<CharacterMovement> ().GotHit();
        other.GetComponentInParent<CharacterMovement>().HitTomato();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
		DoSplat();
        myBoxCollider.enabled = false;
        
	}

    public void DoSplat() {
		StartCoroutine(PlaySequence());

        Vector3 gutsPos = new Vector3(transform.position.x, parent.position.y + 0.01f, transform.position.z + 1.5f);
        var gutsClone = Instantiate(guts, gutsPos, Quaternion.Euler(90f,0f,0f));

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
