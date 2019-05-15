using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_LightningSecondarySpawn : MonoBehaviour {

    [SerializeField]
    private GameObject secondarySpark1;
    [SerializeField]
    private GameObject secondarySpark2;
    public Transform parent;
   

    public void DoSecondarySpark()
    {
        secondarySpark1.SetActive(true);
        secondarySpark2.SetActive(true);
        StartCoroutine("TIME");
    }

    private IEnumerator TIME()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
