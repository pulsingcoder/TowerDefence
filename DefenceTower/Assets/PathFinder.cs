using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LookBlocks();
        ColorStartEnd();
    }

    private void ColorStartEnd()
    {
        start.SetTopColor(Color.green);
        end.SetTopColor(Color.red);
    }

    private void LookBlocks()
    {
       Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            // To check if it already have a key, overlapping area
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Skipping a already contain box at pos" + waypoint.GetGridPos());
            }
            // If not then add to dictionary
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
               
            }
           

        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
