using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardDoor : MonoBehaviour {

    public Light light01;
    public Light light02;
    public Light light03;

    private float light01Intensity;
    private float light02Intensity;
    private float light03Intensity;

    public bool collided;

    public GameObject rightDoor;

    float t = 0.0f;
    float t3 = 0f;

    private void Start()
    {
        light01.gameObject.SetActive(true);
        light02.gameObject.SetActive(true);
        light03.gameObject.SetActive(true);
        light01Intensity = light01.intensity;
        light02Intensity = light02.intensity;
        light03Intensity = light03.intensity;
        collided = false;
        t = 0;
        t3 = 0; 
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        var thing = GetComponent<Animator>();
        thing.SetTrigger("Thing");
        other.gameObject.GetComponentInParent<CharacterMovement>().GotHit();
    }


    void FixedUpdate()
    {
        light01.intensity = Mathf.Lerp(light01Intensity, 0f, t);
        light03.intensity = Mathf.Lerp(light03Intensity, 0f, t3);
        light02.intensity = Mathf.Lerp(0f, light02Intensity, t);

        if (collided)
        {
            //Debug.Log(t);
            t += 10f * Time.deltaTime;
            t3 += 20f * Time.deltaTime;
        }
    }

    public void TurnOffRightDoor()
    {
        rightDoor.SetActive(false);
    }

    public void TurnOffLeftDoor()
    {
        gameObject.SetActive(false);
    }

}
