using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public TileBehaviour leftTile,rightTile,upTile,downTile;
    int level; //beetween 0 and 3
    enum special { terrain, road, well, shop, guardhouse, wall , house, administration};
    special buildings;

    int priority; //0 is the highest

    GameObject guarded;
    GameObject waterAccess;
    GameObject roaded;

    void Start()
    {
        level = 0;
        buildings = special.terrain;
        guarded = null;
        waterAccess = null;
        roaded = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
