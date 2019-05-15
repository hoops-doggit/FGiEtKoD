using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Collider : MonoBehaviour {

    public GameObject lightning;
    private GameObject lightningClone;
    public float colliderWidth;
    private float colliderRadius;
    public Collider[] allObjectsInsideCollider;


    private void OnEnable()
    {
        colliderRadius = colliderWidth /= 2;
        ScanForItems(GetComponent<Collider>());
    }


    private void ScanForItems(Collider item)
    {
        Vector3 center = new Vector3(0, 0, gameObject.transform.position.z) ;

        allObjectsInsideCollider =  Physics.OverlapBox(center, new Vector3(colliderRadius, colliderRadius, colliderRadius));
        foreach (Collider x in allObjectsInsideCollider)
        {
            LemonPower(x, x.transform.position);
        }        
    }

    public void LemonPower(Collider x, Vector3 pos)
    {
        lightningClone = Instantiate(lightning, pos, Quaternion.identity, null);
    }

    public void GetObjectsInCol(GameObject thing)
    {
        if(thing.tag == "jellybean")
        {
            //turn jelly yellow
        }

        else if(thing.tag == "pepper")
        {
            //make it smoke or destroyed// clense it of colour?
        }
    }
    
}
