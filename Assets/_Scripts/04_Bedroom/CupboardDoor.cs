using UnityEngine;

public class CupboardDoor : MonoBehaviour {

    public LightsManager lm;
    public GameObject rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        lm.LeavingBedroom();
        var thing = GetComponent<Animator>();
        thing.SetTrigger("Thing");
        other.gameObject.GetComponentInParent<CharacterMovement>().HitDoor();

    }

    public void TurnOffRightDoor()
    {
        rightDoor.SetActive(false);
    }

    public void TurnOffLeftDoor()
    {
        gameObject.SetActive(false);
    }

}
