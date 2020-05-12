using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{

    private Vector3 downLeftCorner;
    private const int size = 8;
    private const int prioritySize = 5;
    public GameObject Tile;
    private GameObject[] matTile;
    //PF for PriorityFactor
    public float expand_PF; // construction on a new tile
    public float levelUp_PF; // increase level of existing tiles
    public float construct_PF; // augment the number of habitation per existing tiles 
    public float stability_PF; // balance beetween empirical objectiv and personnal's ones. 1 follow empirical ruling.
    bool securityFactor; //is the entire town under one or multiple guardhouses
    bool wallFactor; //is the town completly walled
    bool roadingFactor; //is the town linked to all other town with road



    int[] matOfPriority; // 0 : roads ; 1 : level up ; 2 : habitations ; 3 : well ; 4 : guards ; a value of 0 is the highest
    int[] matOfPriorityCurrent;

    void Start()
    {
        downLeftCorner = this.GetComponent<Transform>().position + (size/2 -(float)0.5) * (Vector3.back + Vector3.left);
        matTile = new GameObject[size * size];
        matOfPriority = new int[prioritySize];
        matOfPriorityCurrent = new int[prioritySize];
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void chooseAction()
    {
        int x=0;
        for (int i = 0; i <= prioritySize - 1; ++i)
        {
            if (matOfPriorityCurrent[x] > matOfPriorityCurrent[i]) x = i;
            else if (matOfPriorityCurrent[x] == matOfPriorityCurrent[i] && matOfPriority[x] > matOfPriority[i]) x = i;
        }
    }

    bool Populate ()
    {
        Debug.Log("populate start");

        TileBehaviour lastTile = null;
        for (int i = 0; i <= size*size -1; ++i)
        {
            matTile[i] = Instantiate(Tile, (downLeftCorner + i / size * Vector3.right + i % size * Vector3.forward), Quaternion.identity, this.transform); //fill up the mat

            Debug.Log("populate num " + i);
            TileBehaviour temp = matTile[i].GetComponent<TileBehaviour>();
            if (lastTile != null) // link left (and linked right)
            {
                lastTile.rightTile = temp;
                temp.leftTile = lastTile;
            }
            if (i > size) // link down (and linked up)
            {
                temp.downTile = matTile[i - size].GetComponent<TileBehaviour>();
                matTile[i - size].GetComponent<TileBehaviour>().upTile = temp;
            }

            lastTile = temp;
        }

        Debug.Log("Populate end");
        return true;
    }

}
