using UnityEngine;

public class EndScene_CrowdAnimator : MonoBehaviour
{

    private Animator _an;
    private SpriteRenderer _sr;
    public float range;


    private void OnEnable()
    {
        Vector3 gbt = gameObject.transform.rotation.eulerAngles;
        float adjust = Random.Range(gbt.y - range, gbt.y + range);
        _an = GetComponentInChildren<Animator>();
        _an.speed = Random.Range(0.4f, 1.2f);
        _an.Play("CrowdJump01", 0, Random.Range(0f, 1f));

        gameObject.transform.eulerAngles = new Vector3(gbt.x, adjust, gbt.z);

    }

}
