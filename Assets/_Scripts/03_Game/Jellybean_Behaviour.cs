using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class Jellybean_Behaviour : MonoBehaviour {

    public float rotaionSpeed;
    public Vector3 rotate;
    public GameObject parent;
    public float sizeIncrease;
	public float scaleMax;
    public bool special = false;
    private int multiplier = 5;
    private bool gotTouched;
    [SerializeField]
    private RealBakedAnimator rba;

    public void Start()
    {
        if (special)
        {
            ChangeToSpecial();
        }
    }
    public void ChangeToSpecial()
    {
        special = true;
        rba.ChangeColor("yellow");
    }


    private void OnTriggerEnter(Collider other)
	{
        //other.gameObject.GetComponentInParent<CharacterMovement>().PlayBurst();
        if (other.gameObject.tag == "player")
        {
            CharacterMovement.cm.PlayBurst();
            if (!special)
            {
                other.gameObject.GetComponent<CharacterCollisions>().jelliesCollected++;
            }
            else if (special)
            {
                other.gameObject.GetComponent<CharacterCollisions>().jelliesCollected += multiplier;
            }
            parent.GetComponent<JellyBean_Death>().PlayAnimation();
            Character_HitTracker.instance.AddJelly();
            Sound_GBSfx.instance.JellyPickup();
        }
	}
		
}
