using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes_ColourChange : MonoBehaviour {



    [SerializeField]
    private Material clothesMaterial;

    public GameObject top;




    public string[] colours;

    public string dyeColour;




    //gets the dye colour from the object the character bumped into
    public void ChangeClothesColour(string objectColour){
        colours[0] = colours[1];
        colours[1] = colours[2];
        colours[2] = objectColour;
        CheckClothesColour();

    }

    //checks to see if the colours are all the same or not
    public void CheckClothesColour(){
        //if colours are all the same then script needs to switch design with the new one
        if(colours[0].Equals(colours[1]) && colours[1].Equals(colours[2])){
            Debug.Log("they're all the same");
            RemoveMaterialTint();
        }
        else{
            Debug.Log("They're not the same");
        }


    }

    private void RemoveMaterialTint()
    {
        Debug.Log("changColorNow!!!");
        //var matCol = top.GetComponent<Renderer>().material.color;
        Color getRed = new Vector4(0, 0.2f, 0.2f, 0);
        top.GetComponent<Renderer>().material.color = top.GetComponent<Renderer>().material.color - getRed ;
    }

    private void AssignClothingVariation( string colour){

    }

    private void AddColourToMaterial(string col){

    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeClothesColour(dyeColour);
    }






    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
