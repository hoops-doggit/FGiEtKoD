using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_Behaviour : MonoBehaviour {

    [SerializeField]
    private int thingsDestroyed;
    [SerializeField]
    private float orangeLifeSpanSeconds;
    //public int maxThingsHit;
    public ParticleSystem destroyedFX;
    public ParticleSystem orangeDestroyedFX;
    public Transform orangeDeathParticlesPosition;
    
    
    
	// Use this for initialization
	void Start () {
        //thingsDestroyed = 0;
        StartCoroutine("OrangeLife");
	}

    //this runs when the orange destroys something
    public void DoTheThing(GameObject collisionObject)
    {
        if (collisionObject != gameObject)
        {
            Debug.Log("Orange destroyed" + collisionObject.name);
            ParticleSystem particles = Instantiate(destroyedFX, collisionObject.transform);
            particles.transform.parent = null;
            particles.transform.localScale = Vector3.one;
            Destroy(collisionObject.gameObject);
            if(collisionObject.transform.parent != null && collisionObject.transform.parent.tag != "UnDestroyable")
            {
                Destroy(collisionObject.transform.parent.gameObject);
            }
            //thingsDestroyed++;
            //CheckNumberOfDestroyedThings();
        }
    }

    //this runs when the orange gets to the end of it's lifespan
    private void DestroyOrange()
    {
        StopAllCoroutines();
        ParticleSystem orangeDeath = Instantiate(orangeDestroyedFX, orangeDeathParticlesPosition);
        orangeDeath.transform.parent = null;
        Destroy(gameObject);
    }

    //private void CheckNumberOfDestroyedThings()
    //{
    //    if (thingsDestroyed >= maxThingsHit)
    //    {
    //        DestroyOrange();
    //    }
    //}

    private IEnumerator OrangeLife()
    {
        yield return new WaitForSeconds(orangeLifeSpanSeconds);
        DestroyOrange();
        StopAllCoroutines();
    }
}
