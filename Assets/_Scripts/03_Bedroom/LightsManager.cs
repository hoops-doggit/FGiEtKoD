using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour {

    public Light bedroom01;
    public Light bedroom02;
    public Light gameplay01;

    [Header("Catwalk Lights")]
    public Light catwalk01;
    public Light catwalk02;
    public Light catwalk03;
    public Light catwalk04;
    public Light catwalk05;

    private float bedroom01Intentsity;
    private float bedroom02Intensity;
    private float gameplay01Intensity;

    private float catwalk01Intensity;
    private float catwalk02Intensity;
    private float catwalk03Intensity;
    private float catwalk04Intensity;
    private float catwalk05Intensity;


    public bool doorCollision;
    public bool enteringCatwalk;

    public GameObject rightDoor;

    float bedroomTime = 0.0f;
    float exitBedroomTime = 0f;
    float enterCatwalkTime = 0f;

    private void OnEnable()
    {
        bedroom01.gameObject.SetActive(true);
        bedroom02.gameObject.SetActive(true);
        gameplay01.gameObject.SetActive(true);

        catwalk01.gameObject.SetActive(true);
        catwalk02.gameObject.SetActive(true);
        catwalk03.gameObject.SetActive(true);
        catwalk04.gameObject.SetActive(true);
        catwalk05.gameObject.SetActive(true);


        bedroom01Intentsity = bedroom01.intensity;
        bedroom02Intensity = bedroom02.intensity;
        gameplay01Intensity = gameplay01.intensity;

        catwalk01Intensity = catwalk01.intensity;
        catwalk02Intensity = catwalk02.intensity;
        catwalk03Intensity = catwalk03.intensity;
        catwalk04Intensity = catwalk04.intensity;
        catwalk05Intensity = catwalk05.intensity;

        doorCollision = false;
       

        bedroom01.intensity = bedroom01Intentsity;
        bedroom02.intensity = bedroom02Intensity;
        gameplay01.intensity = 0;
        gameplay01.gameObject.SetActive(false);
        catwalk01.intensity = 0;
        catwalk01.gameObject.SetActive(false);
        catwalk02.intensity = 0;
        catwalk02.gameObject.SetActive(false);
        catwalk03.intensity = 0;
        catwalk03.gameObject.SetActive(false);
        catwalk04.intensity = 0;
        catwalk04.gameObject.SetActive(false);
        catwalk05.intensity = 0;
        catwalk05.gameObject.SetActive(false);



    }

    public void LeavingBedroom(){
        gameplay01.gameObject.SetActive(true);
        doorCollision = true;
    }

    public void EnteringCatwalk(){
        catwalk01.gameObject.SetActive(true);
        catwalk02.gameObject.SetActive(true);
        catwalk03.gameObject.SetActive(true);
        catwalk04.gameObject.SetActive(true);
        catwalk05.gameObject.SetActive(true);

        enteringCatwalk = true;
    }




    //might put this in a coroutine instead so that once it's done the update isn't necessary
    void FixedUpdate()
    {



        if (doorCollision)
        {
            //Debug.Log(t);
            bedroomTime += 10f * Time.deltaTime;
            exitBedroomTime += 20f * Time.deltaTime;

            bedroom01.intensity = Mathf.Lerp(bedroom01Intentsity, 0f, bedroomTime);
            bedroom02.intensity = Mathf.Lerp(bedroom02Intensity, 0f, exitBedroomTime);
            gameplay01.intensity = Mathf.Lerp(0f, gameplay01Intensity, bedroomTime);
        }

        if (enteringCatwalk){
            enterCatwalkTime += 1f * Time.deltaTime;

            gameplay01.intensity = Mathf.Lerp(gameplay01Intensity, 0f, enterCatwalkTime);
            catwalk01.intensity = Mathf.Lerp(0f, catwalk01Intensity, enterCatwalkTime);
            catwalk02.intensity = Mathf.Lerp(0f, catwalk02Intensity, enterCatwalkTime);
            catwalk03.intensity = Mathf.Lerp(0f, catwalk03Intensity, enterCatwalkTime);
            catwalk04.intensity = Mathf.Lerp(0f, catwalk04Intensity, enterCatwalkTime);
            catwalk05.intensity = Mathf.Lerp(0f, catwalk05Intensity, enterCatwalkTime);
        }
    }



}
