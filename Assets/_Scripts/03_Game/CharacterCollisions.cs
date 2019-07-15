using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour {

    public bool groundContact;
    public int groundCount;
    private CharacterMovement cm;
    [SerializeField]
    private BakedAnimator bodyColour;
    public GameObject clothes_top;
    private Clothes_BakedAnimator _cbaTop;
    public GameObject clothes_bottom;
    private Clothes_BakedAnimator _cbaBottom;
    public GameObject slice;
    public Camera came;
    public Transform slicePos;
    private BakedAnimator ba;
    private int colourBumps;


    //jelliesCollected gets incrememnted up inside a jellybean script. Not the topmost one.
    //NOTE: Jellybeans are triggers
    public int jelliesCollected;

    private void Start()
    {
        cm = CharacterMovement.cm;
        groundContact = false;
        clothes_top.SetActive(false);
        ba = GetComponentInChildren<BakedAnimator>();
        _cbaTop = clothes_top.GetComponent<Clothes_BakedAnimator>();
        //_cbaBottom = clothes_bottom.GetComponent<Clothes_BakedAnimator>();
    }
    

    public void OnCollisionEnter(Collision col)
    {
        string tag = col.gameObject.tag;

        if (tag == "ground")
        {
            //groundContact = true;
            groundCount++;
            cm.UpdateGroundStats();

            if(cm.transform.position.y < 0)
            {
                cm.Boink();
            }
        }

        if (tag == "box")
        {
            cm.Pushback();
        }

        if (tag == "clothesPile")
        {
            clothes_top.SetActive(true);

            _cbaTop.m_Sprites= col.gameObject.GetComponent<ClothesPile_ClothesContainer>().GiveGBClothing();
            Destroy(col.gameObject.GetComponent<BoxCollider>());
            cm.HitClothesPile();
        }

        if (tag == "butterKnife")
        {
            cm.Pushback();
            Debug.Log("hitButterKnife");
        }

        if (tag == "bigKnife")

        {
            colourBumps++;
            col.gameObject.GetComponentInParent<Knife_Behaviour>().StartColliderToggle();
            if (clothes_top.activeSelf == true)
            {
                clothes_top.SetActive(false);
            }
            cm.Pushback();
            GameObject sliceClone = Instantiate(slice, gameObject.transform.position, Quaternion.identity);
            sliceClone.transform.SetParent(null);
            sliceClone.GetComponent<FX_Slice2Parent>().MoveSlice(slicePos, came);
        }

        if (tag == "ice")
        {
            groundCount++;
            cm.UpdateGroundStats();
            cm.IceSkatingStart();
        }

        if(tag  == "sponge" && bodyColour.currentColour == "blue")
        {
            cm.IceSkatingStart();
            groundCount++;
            cm.UpdateGroundStats();
        }
        if(tag == "sponge" && bodyColour.currentColour != "blue")
        {
            groundCount++;
            cm.UpdateGroundStats();
        }
    }

    public void OnCollisionExit(Collision col)
    {
        string tag = col.gameObject.tag;

        if (tag == "ground")
        {
            //groundContact = false;
            groundCount--;
            cm.UpdateGroundStats();
        }

        if(tag == "sponge")
        {
            groundCount--;
            cm.UpdateGroundStats();
        }

        if (tag == "ice")
        {
            //groundContact = false;
            groundCount--;
            cm.UpdateGroundStats();
            cm.IceSkatingStop();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(ba.currentColour);
        //Debug.Log("colour bumps = " + colourBumps);
        if (ba.currentColour != "pink" && other.gameObject.tag == "pepper")
        {
            //Debug.Log("colourBumps == " + colourBumps);
            colourBumps++;
            if (colourBumps > 2)
            {
                colourBumps = 0;
                ba.currentColour = "pink";
                ba.ChangeColor("pink");
            }
        }
    }

    private void LandedOnGround()
    {
        //groundContact = true;
        groundCount++;
        cm.UpdateGroundStats();
    }

    private void LeftGround()
    {

    }

    private void FixedUpdate()
    {
        if (groundCount > 0)
        {
            groundContact = true;
            cm.UpdateGroundStats();
        }

        else
        {
            groundContact = false;
            cm.UpdateGroundStats();
        }
    }

}
