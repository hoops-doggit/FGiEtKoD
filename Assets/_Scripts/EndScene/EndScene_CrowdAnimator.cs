using UnityEngine;

public class EndScene_CrowdAnimator : MonoBehaviour 
{

    private Animator _an;
    public Transform _gbTransform;


    private void OnEnable()
    {
        _an = GetComponentInChildren<Animator>();
        _an.speed = Random.Range(0.2f, 1.2f);
    }

    private void Update()
    {
        transform.LookAt(_gbTransform);   
    }

}
