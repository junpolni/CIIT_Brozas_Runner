using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoundManager>().Play("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
