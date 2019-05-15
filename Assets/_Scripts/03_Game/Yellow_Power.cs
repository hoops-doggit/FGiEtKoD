using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Power : MonoBehaviour {

    public GameObject lightning;
    private GameObject lightningClone;
    public List<GameObject> go = new List<GameObject>();
   


    public void LemonPower(Vector3 pos)
    {
        lightningClone = Instantiate(lightning, pos, Quaternion.identity, null);
    }

    private void OnTriggerEnter(Collider other)
    {
        LemonPower(other.transform.position);
        Debug.Log("did yellow power thing");
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
