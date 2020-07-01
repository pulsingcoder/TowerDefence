using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));

    }

    IEnumerator FollowPath(List<Waypoint> Path)
    {
        print("Starting petrol");

        foreach (Waypoint ways in Path)
        {
            transform.position = ways.transform.position;
            print("Visiting block " + ways.gameObject.name);    
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
