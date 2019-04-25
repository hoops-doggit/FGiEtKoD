using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato_Spawner : MonoBehaviour {

    [SerializeField]
    private List<GameObject> pepperList;
    [SerializeField]
    private int maxNumberOfToms;
    [SerializeField]
    private int numberOfToms;
    private int totalNumberOfPeppers;
    [SerializeField]
    private GameObject smallTomato;
    private GameObject smallTomatoClone;
    public float waitForSeconds = 5f;

    void Start()
    {
        StartCoroutine("StartTomatoReplacer");
    }

    private IEnumerator StartTomatoReplacer()
    {
        Debug.Log("started tomato wait");
        yield return new WaitForSeconds(waitForSeconds);
        PickObjectToReplaceWithTomato();
        Debug.Log("finished Tomato wait");
    }

    public void PickObjectToReplaceWithTomato()
    {
        numberOfToms = Random.Range(0, maxNumberOfToms + 1);
        for (int i = 1; i < numberOfToms; i++)
        {
            ReplaceWithTomato(Random.Range(1, pepperList.Count));
        }
    }

    public void ReplaceWithTomato(int i)
    {
        smallTomatoClone = Instantiate(smallTomato, pepperList[i].transform.position, Quaternion.identity, pepperList[i].transform);
        smallTomatoClone.transform.parent = null;
        pepperList[i].SetActive(false);
    }

    public void AddSelf(GameObject go)
    {
        pepperList.Add(go);
    }
	

}
