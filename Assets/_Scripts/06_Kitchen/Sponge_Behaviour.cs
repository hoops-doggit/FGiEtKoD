using UnityEngine;

public class Sponge_Behaviour : MonoBehaviour {

    [SerializeField]
	private Animator anim;
    [SerializeField]
    private Animator anim2;


    void OnCollisionEnter(Collision col){
        anim.SetTrigger("hit");
        anim2.SetTrigger("hit");
    }
}
