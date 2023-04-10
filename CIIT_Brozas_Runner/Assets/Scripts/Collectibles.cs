using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int balloonCount;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            FindObjectOfType<SoundManager>().Play("BalloonCollectedSFX");

            Debug.Log("Balloon collected");
            balloonCount = balloonCount + 1;
            Destroy(col.gameObject);
        }
    }
}
