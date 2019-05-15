using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Collider : MonoBehaviour {

    public GameObject lightning;
    private GameObject lightningClone;
    public GameObject jellyBean;
    public GameObject goldenJellyBean;
    private float pauseBeforeSpawningLightning;
    public float colliderWidth;
    private float colliderRadius;
    public Collider[] allObjectsInsideCollider;
    


    private void OnEnable()
    {
        colliderRadius = colliderWidth /= 2;
        Destroy(GetComponent<Collider>());
        ScanForItems();
    }


    private void ScanForItems()
    {
        Vector3 center = new Vector3(0, 0, gameObject.transform.position.z) ;

        allObjectsInsideCollider =  Physics.OverlapBox(center, new Vector3(colliderRadius, colliderRadius, colliderRadius));
        StartCoroutine("SpawnLightning");
        StartCoroutine("DestroyObject");
    }

    public void LemonPower(Collider x, Vector3 pos)
    {
        if (x.tag == "jellybean")
        {
            SpawnLightningClone(pos);
            x.GetComponent<Jellybean_Behaviour>().ChangeToSpecial();
        }

        else if (x.tag == "pepper")
        {
            SpawnLightningClone(pos);
            GameObject newJB = Instantiate(jellyBean, new Vector3(pos.x, pos.y + 2.987f, pos.z), Quaternion.identity, null);
            //instantiate smoke particles
            Destroy(x.gameObject);
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }

    private IEnumerator SpawnLightning()
    {
        yield return new WaitForSeconds(pauseBeforeSpawningLightning);
        Sound_GBSfx.instance.PlayLightning();
        
        foreach (Collider x in allObjectsInsideCollider)
        {
            LemonPower(x, x.transform.position);
        }
        yield return new WaitForSeconds(0.15f);
        Sound_GBSfx.instance.JellyPickup(1);
    }

    public void SpawnLightningClone(Vector3 pos)
    {        
        lightningClone = Instantiate(lightning, pos, Quaternion.identity, null);
        SpriteRenderer sr = lightningClone.GetComponent<SpriteRenderer>();
        float flipI = Random.Range(0, 1);
        if (flipI > 0.5f)
        {
            sr.flipX = true;
        }        
    }

}


