using UnityEngine;

public class EndScene_CrowdAnimator : MonoBehaviour
{

    private Animator _an;
    public Transform _gbTransform;
    private SpriteRenderer _sr;



    private void OnEnable()
    {

        _an = GetComponentInChildren<Animator>();
        _an.speed = Random.Range(0.4f, 1.2f);
        _an.Play("CrowdJump01", 0, Random.Range(0f, 1f));

    }

    private void Update()
    {
        //transform.LookAt(_gbTransform);   
    }

}
