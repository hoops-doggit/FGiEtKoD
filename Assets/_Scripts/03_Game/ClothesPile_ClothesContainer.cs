using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPile_ClothesContainer : MonoBehaviour {

    public List<Sprite> top01;
    public List<Sprite> top02;
    public List<Sprite> bottom01;
    public List<Sprite> bottom02;

    public string topName;
    public string bottomName;

    private Clothes_BakedAnimator _cba;


    private void OnCollisionEnter(Collision collision)
    {
        _cba = collision.gameObject.GetComponentInChildren<Clothes_BakedAnimator>();
        GiveGBClothing();
        Debug.Log("Did clothesPileContainter thing");
    }



    public List<Sprite> GiveGBClothing(){
        int topOrBottom = Random.Range(0, 2);

        Debug.Log("topOrBottom = " + topOrBottom);
        if (topOrBottom == 0){
            int whichTop = Random.Range(0, 2);
            if (whichTop == 0){
                return top01;
            }
            if (whichTop == 1){
                return top02;
            }
        }

        else if (topOrBottom == 1)
        {
            int whichbottom = Random.Range(0, 2);
            if (whichbottom == 0)
            {
                return bottom01;
            }
            if (whichbottom == 1)
            {
                return bottom02;
            }
        }
        return null;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
