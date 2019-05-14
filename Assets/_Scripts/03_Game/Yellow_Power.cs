using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Power : MonoBehaviour {

    public GameObject lightning;
    private GameObject lightningClone;
    private Collider col;
    public List<GameObject> go = new List<GameObject>();
    public float lightningZOffset;
   
    public void LemonPower()
    {
        Vector3 position = col.gameObject.transform.position;
        col.gameObject.transform.position = new Vector3(0, position.y, position.z + lightningZOffset);
        col.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        go.Add(other.gameObject);
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
