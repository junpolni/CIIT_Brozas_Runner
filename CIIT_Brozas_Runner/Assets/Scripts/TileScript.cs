using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] TilesPlacement[] tilesPlacement;

    // Start is called before the first frame update
    void Start()
    {
        tilesPlacement = GetComponentsInChildren<TilesPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
