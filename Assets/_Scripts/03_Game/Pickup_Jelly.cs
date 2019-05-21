using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JellyColour
{
    pink,
    blue,
    green,
    orange,
    yellow
}

public class Pickup_Jelly : MonoBehaviour {

   

    public Sprite pink;
    public Sprite blue;
    public Sprite green;
    public Sprite orange;
    public Sprite yellow;

    public JellyColour jc;
    private SpriteRenderer _sr;

    private string colorText;
    private GameObject _gb;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        jc = (JellyColour)Random.Range(0, 5);

        switch (jc)
        {
            case JellyColour.pink:
                _sr.sprite = pink;
                colorText = "pink";
                break;
            case JellyColour.blue:
                _sr.sprite = blue;
                colorText = "blue";
                break;
            case JellyColour.green:
                _sr.sprite = green;
                colorText = "green";
                break;
            case JellyColour.orange:
                _sr.sprite = orange;
                colorText = "orange";
                break;
            case JellyColour.yellow:
                _sr.sprite = yellow;
                colorText = "yellow";
                break;
            default:
                _sr.sprite = pink;
                colorText = "something";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _gb = other.gameObject;
        StartCoroutine("ChangeColor");
    }

    private IEnumerator ChangeColor(){
        yield return new WaitForSeconds(0.025f);
        _gb.GetComponentInChildren<BakedAnimator>().ChangeColor(colorText);
        StopCoroutine("ChangeColor");
    }
}
