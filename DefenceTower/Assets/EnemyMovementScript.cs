using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] List<Waypoint> Path;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(FollowPath());

    }

    IEnumerator FollowPath()
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
