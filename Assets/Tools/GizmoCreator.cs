using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCreator : MonoBehaviour {

    public Color gizCol = new Color(0, 0, 1, 0.5f);
    public Vector3 offset = new Vector3(23, 0, 0);
    private Vector3 realPos;

    
    private void OnDrawGizmosSelected()
    {
        realPos.x = transform.position.x + offset.x;
        realPos.y = transform.position.y + offset.y;
        realPos.z = transform.position.z + offset.z;
        
    }

    void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = gizCol;
        Gizmos.DrawCube(realPos, new Vector3(15, 3, 3));
    }
}
