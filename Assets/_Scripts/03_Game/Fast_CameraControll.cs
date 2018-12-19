using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast_CameraControll : MonoBehaviour {

    public static Fast_CameraControll instance;
    public Camera cam;

    public float fieldOfView_fast;
    private float fieldOfView_normal;

    private void Awake()
    {
        instance = this;
        fieldOfView_normal = cam.fieldOfView;
    }

    public void GoingFast()
    {
        //cam.fieldOfView = fieldOfView_fast;
        StartCoroutine("Test");
    }

    public void NormalSpeed()
    {
        StartCoroutine("End");
        //cam.fieldOfView = fieldOfView_normal;
    }

    private IEnumerator Test()
    {
        while (cam.fieldOfView < (fieldOfView_fast*.75f))
        {
            cam.fieldOfView += 0.2f;
            yield return new WaitForSeconds(0.05f);
        }

        while(cam.fieldOfView < fieldOfView_fast)
        {
            cam.fieldOfView += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }

        if (cam.fieldOfView >= fieldOfView_fast)
        {
            yield return null;
        }        
    }

    private IEnumerator End()
    {
        while (cam.fieldOfView > (fieldOfView_normal / .75f))
        {
            cam.fieldOfView -= 0.2f;
            yield return new WaitForSeconds(0.05f);
        }

        while (cam.fieldOfView > fieldOfView_fast)
        {
            cam.fieldOfView -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }

        if (cam.fieldOfView <= fieldOfView_fast)
        {
            yield return null;
        }
    }
}
