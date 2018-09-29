using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Behaviour : MonoBehaviour {

    public float knifeDownSpeed;
    public float knifeUpSpeed;
    public float knifePosition;
    public float upRot;
    public float downRot;

    private float _currentRot;
    public bool _goingDown;

    public void KnifeDown()
    {
        knifePosition = knifePosition + knifeDownSpeed;
        transform.rotation = Quaternion.Euler(0,0, Mathf.Lerp(upRot, downRot, knifePosition ));
        if (knifePosition > 1)
        {
            knifePosition = 0;
            _goingDown = false;
        }
    }

    public void KnifeUp()
    {
        knifePosition = knifePosition + knifeUpSpeed;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(downRot, upRot, knifePosition));
        if (knifePosition > 1)
        {
            knifePosition = 0;
            _goingDown = true;
        }
    }


    // Use this for initialization
    void Start () {
        transform.eulerAngles = new Vector3(0, 0, upRot);
        _goingDown = true;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (_goingDown)
        {
            KnifeDown();
        }

        else if (!_goingDown)
        {
            KnifeUp();
        }

    }
}
