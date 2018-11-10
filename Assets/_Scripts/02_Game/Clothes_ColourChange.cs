using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes_ColourChange : MonoBehaviour
{


    public BakedAnimator gbTorsoClothes;
    public List<Sprite> toGiveToCharacter = new List<Sprite>();

    public Sprite[,] topClothesMatrix;
    [SerializeField]
    private Sprite[] hRed;
    [SerializeField]
    private Sprite[] hBlack;
    [SerializeField]
    private Sprite[] hWhite;








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
    public void CheckClothesColour()
    {
        //if colours are all the same then script needs to switch design with the new one
        if (colours[0].Equals(colours[1]) && colours[1].Equals(colours[2]))
        {
            //Debug.Log("they're all the same");
            RemoveMaterialTint();
        }
        else
        {
            //Debug.Log("They're not the same");
            int x = 0;
            int y = 0;

            #region first column
            if(colours[1].Equals(null)){
                x = 0;
            }
            if (colours[1].Equals("red"))
            {
                x = 1;
            }

            if (colours[1].Equals("black"))
            {
                x = 2;
            }

            if (colours[1].Equals("white"))
            {
                x = 3;
            }
            #endregion

            #region second column
            if (colours[1].Equals(null)){
                y = 0;
            }
            if (colours[1].Equals("red"))
            {
                y = 1;
            }

            if (colours[1].Equals("black"))
            {
                y = 2;
            }

            if (colours[1].Equals("white"))
            {
                y = 3;
            }

            Debug.Log("x = " + x + "  y = " + y);
            GetClothes(x, y);
            #endregion
        }



    }

    private void GetClothes(int across, int down){

        if (across == 1){
            //red column
            if (down == 0){
                gbTorsoClothes.m_Sprites[0] = hRed[0]; //top of red row first frame
                gbTorsoClothes.m_Sprites[1] = hRed[1]; //top of red row second frame
            }

            if (down == 1){
                gbTorsoClothes.m_Sprites[0] = hRed[2];
                gbTorsoClothes.m_Sprites[1] = hRed[3];
            }
        }

        //get clothes
        //change clothes to top



    }

    private void RemoveMaterialTint()
    {
        //Debug.Log("changColorNow!!!");
        //var matCol = top.GetComponent<Renderer>().material.color;
        Color getRed = new Vector4(0, 0.2f, 0.2f, 0);
        //top.GetComponent<Renderer>().material.color = top.GetComponent<Renderer>().material.color - getRed ;
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
