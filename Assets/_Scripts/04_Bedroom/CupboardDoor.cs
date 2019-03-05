using UnityEngine;

public class CupboardDoor : MonoBehaviour {

    public LightsManager lm;
    public GameObject rightDoor;

    private void OnTriggerEnter(Collider other)
    {
        lm.LeavingBedroom();
        var thing = GetComponent<Animator>();
        thing.SetTrigger("Thing");
        //since the only object that can collide is the player character I could make the character movement script static and just run hitdoor
        CharacterMovement.cm.HitDoor();
        Sound_MusicHandler.sm.PlayEndBit();
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
