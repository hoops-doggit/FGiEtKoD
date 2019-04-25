using UnityEngine;

public class Tomato_CanBeReplacedWithTomato : MonoBehaviour {
    [SerializeField]
    private bool canTomato = true;
	// Use this for initialization
	void Start () {
        if (canTomato)
        {
            _GM.instance.GetComponent<Tomato_Spawner>().AddSelf(gameObject);
        }        
	}
}
