using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum objectSide
{
    left,
    right
}

public class Fork : MonoBehaviour {

    public Animator fork;
    public AnimationClip spinLeft;
    public AnimationClip spinRight;
    public Collider myCollider;
    public bool gotHit;
    public GameObject TopObject;

    

    public objectSide forkSide;

    private void OnTriggerEnter(Collider other)
    {
        if (forkSide == objectSide.left)
        {
            fork.Play("ForkLeft");
            gotHit = true;
        }

        else
        {
            fork.Play("ForkRight");
            gotHit = true;
        }
        other.gameObject.GetComponentInParent<CharacterMovement>().GotHit();
        Destroy(myCollider);
    }

}
