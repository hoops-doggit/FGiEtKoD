using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTest : MonoBehaviour {

    public List<int> intList = new List<int> { 0, 22, 55, 7 };
    public Text number00;
    public Text number01;
    public Text number02;
    public Text number03;

    private static NameScore num1;
    private static NameScore num2;
    private static NameScore num3;
    private static NameScore num4;

    public Dictionary<int, NameScore> dict = new Dictionary<int, NameScore>()
    {
        //{0, num1},{1, num2}, {2,num3}, {3,num4}
    };

    public List<NameScore> namescoreList = new List<NameScore> { num1, num2 };

    public void Start()
    {
        num1.name = "jacob";
        num1.score = 21;

        dict.Add(0, num1);

        num2.name = "Brooklyn";
        num2.score = 999;

        dict.Add(1, num2);
    }

    public void SortDict()
    {

    }

    public void Thing()
    {
        intList.Sort();
        namescoreList.Sort();

    }
	
	// Update is called once per frame
	void Update () {
        number00.text = intList[0].ToString();
        number01.text = intList[1].ToString();
        number02.text = intList[2].ToString();
        number03.text = intList[3].ToString();
    }
}

[System.Serializable]
public struct NameScore
{
    public string name;
    public int score;

}

