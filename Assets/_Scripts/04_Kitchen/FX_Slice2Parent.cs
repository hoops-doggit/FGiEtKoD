using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FX_Slice2Parent : MonoBehaviour {

    public GameObject slice;

    public Transform target;

    public void MoveSlice(Transform pos, Camera came)
    {
        Vector3 screenPos = came.WorldToScreenPoint(pos.position);
        slice.transform.position = screenPos;
        slice.SetActive(true);
    }
}
