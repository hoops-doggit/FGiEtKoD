using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLerper : MonoBehaviour {

    public Light light01;
    public Light light02;

    private float light01Intensity;
    private float light02Intensity;

    public bool collided;


    // starting value for the Lerp
    float t = 0.0f;

    private void Start()
    {
        light01.gameObject.SetActive(true);
        light02.gameObject.SetActive(true);
        light01Intensity = light01.intensity;
        light02Intensity = light02.intensity;
        collided = false;
        t = 0;
        Debug.Log("light is on" + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }


    void FixedUpdate()
    {
        light01.intensity = Mathf.Lerp(light01Intensity, 0f, t);
        light02.intensity = Mathf.Lerp(0f, light02Intensity, t);

        if (collided)
        {
            t += 10f * Time.deltaTime;
        }
    }
}

