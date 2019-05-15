using UnityEngine;

[CreateAssetMenu]
public class PrefabPlacerData : ScriptableObject {

    public float pepperRightPos = 5.5f;
    public float pepperJellyYPos = 2.6f;
    public float tomatoRightPos = 5.5f;
    public float bigTomatoRightPos = 0;

    public float easyJellyPos = 8.9f;
    public float mediumJullyPos = 5f;
    public float hardJellyPos = 2f;

    public GameObject jellyPrefab;
    public GameObject jellySpecialPrefab;
    public GameObject jellyBeanParent;
    public GameObject saltShaker;
    public GameObject pepperShaker;
    public GameObject smallTomato;
    public GameObject bigTomato;
    public GameObject bigKnife;
    public GameObject bigPlainKnife;
}
