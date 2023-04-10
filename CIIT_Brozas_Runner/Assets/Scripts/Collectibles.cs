using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int balloonCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            Debug.Log("Balloon collected");
            balloonCount = balloonCount + 1;
            Destroy(col.gameObject);
        }
    }
}
