using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public GameObject thingToDestroy;

	public void DestroySomething()
    {
        Destroy(thingToDestroy);
    }        
}
