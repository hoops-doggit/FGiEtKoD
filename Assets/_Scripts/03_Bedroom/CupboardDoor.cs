using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardDoor : MonoBehaviour {

    public Light light01;
    public Light light02;

    private float light01Intensity;
    private float light02Intensity;

    public bool collided;

    public GameObject rightDoor;

    float t = 0.0f;

    private void Start()
    {
        light01.gameObject.SetActive(true);
        light02.gameObject.SetActive(true);
        light01Intensity = light01.intensity;
        light02Intensity = light02.intensity;
        collided = false;
        t = 0;
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
        light02.intensity = Mathf.Lerp(0f, light02Intensity, t);

        if (collided)
        {
            Debug.Log(t);
            t += 10f * Time.deltaTime;
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
