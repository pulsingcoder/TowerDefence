using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] List<Block> Path;
    // Start is called before the first frame update
    void Start()
    {
        PrintAllWaypoints();

    }

    private void PrintAllWaypoints()
    {
        foreach (Block ways in Path)
        {
            print(ways.name + " ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
