using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class Jellybean_Behaviour : MonoBehaviour {

    public float rotaionSpeed;
    public Vector3 rotate;
    public GameObject parent;
	public GameObject jellybean;
	public GameObject burst;
    public float sizeIncrease;
    public float scaleMax;
	public bool playingAnimation;

	public DoodleAnimationFile burstAnimation;
	[Header("Settings")]
	public bool m_PlayOnStart = false;
	public bool m_Loop = false;


    private bool gotTouched;

    private void OnTriggerEnter(Collider other)
	{
		gotTouched = true;
		StopAllCoroutines ();
		StartCoroutine ("PlaySequence");
	}


	IEnumerator PlaySequence() {
		burst.SetActive (true);
		DoodleAnimator animator = burst.GetComponent<DoodleAnimator>();
		jellybean.SetActive (false);
		yield return animator.PlayAndPauseAt(0,-1);

		animator.Stop();
		Destroy (parent);

	}

	public void Play() {
		StopAllCoroutines();
		StartCoroutine(PlaySequence());
	}




    // Update is called once per frame
    void Update () {
        //parent.transform.Rotate(rotate, rotaionSpeed);





        if (gotTouched)
        {
            //parent.transform.localScale = new Vector3(parent.transform.localScale.x + sizeIncrease, parent.transform.localScale.y + sizeIncrease, parent.transform.localScale.z + sizeIncrease);


            if (parent.transform.localScale.x > scaleMax)
            {
				//(jellybean);
            }
        }
	}
}
