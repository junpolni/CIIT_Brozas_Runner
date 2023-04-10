using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int balloonCount;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            FindObjectOfType<SoundManager>().Play("BalloonCollectedSFX");

            Debug.Log("Balloon collected");
            balloonCount = balloonCount + 1;

            anim.SetBool("isCrawling", false);

            Destroy(col.gameObject);
        }
    }
}
