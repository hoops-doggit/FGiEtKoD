using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLerper : MonoBehaviour {

    public Light light01;
    public Light light02;

    private float light01Intensity;
    private float light02Intensity;

    public float light02Increment;
    public float light01Decrement;
    bool thing;


	

		// animate the game object from -1 to +1 and back
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    private void Start()
    {
        light01.gameObject.SetActive(true);
        light02.gameObject.SetActive(true);
        light01Intensity = light01.intensity;
        light02Intensity = light02.intensity;
        thing = false;
        t = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        thing = true;
    }

    void FixedUpdate()
    {
        light01.intensity = Mathf.Lerp(light01Intensity, 0f, t);
        light02.intensity = Mathf.Lerp(0f, light02Intensity, t);


        if (thing)
        {
            t += 10f * Time.deltaTime;
        }
        

    }
}

