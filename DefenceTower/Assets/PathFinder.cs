using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    // Start is called before the first frame update
    void Start()
    {
        LookBlocks();
        ColorStartEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int dir in directions)
        {
            Vector2Int explorationCoordinates = start.GetGridPos() + dir;
            try {
                grid[explorationCoordinates].SetTopColor(Color.grey);
            }
            catch
            {
                // Do nothing
            }
        }    
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
