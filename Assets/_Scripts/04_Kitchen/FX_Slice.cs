using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class FX_Slice : MonoBehaviour {


    private DoodleAnimator da;
    private GameObject go;

    private void OnEnable()
    {
        da = GetComponent<DoodleAnimator>();
        go = gameObject;
        StartCoroutine("PlayAndDeleteGameObject");
    }

    IEnumerator PlayAndDeleteGameObject(){


        //yield return da.PlayAndPauseAt(0, -1);
        yield return new WaitForSeconds(0);
        //Destroy(go);
    }
}
