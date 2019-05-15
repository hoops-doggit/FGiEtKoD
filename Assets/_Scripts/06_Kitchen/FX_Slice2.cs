using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class FX_Slice2 : MonoBehaviour {

    private DoodleAnimator da;
    private GameObject go;

    private void OnEnable()
    {
        da = GetComponent<DoodleAnimator>();
        go = gameObject;
        go.transform.eulerAngles = new Vector3(0, 0, Random.Range(-10f, 10));
        StartCoroutine("PlayAndDeleteGameObject");


    }

    IEnumerator PlayAndDeleteGameObject()
    {
        yield return da.PlayAndPauseAt(0, -1);
        yield return new WaitForSeconds(0.1f);
        Destroy(go.transform.parent.gameObject);
    }
}
