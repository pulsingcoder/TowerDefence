using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;
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
        PathFind();
        //ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(start);
        while(queue.Count >0 && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("searching from " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }
        print("Finished path find?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
       if (searchCenter == end)
        {
            print("Searching from end node, therefore stop logging");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int dir in directions)
        {
            Vector2Int explorationCoordinates = from.GetGridPos() + dir;
            try
            {
                QueueNewNeighbour(explorationCoordinates);
            }
            catch
            {
                // Do nothing
            }
        }    
    }

    private void QueueNewNeighbour(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];
        if (neighbour.isExplored)
        {
            // do nothing
        }
        else
        {
            neighbour.SetTopColor(Color.grey);
            queue.Enqueue(neighbour);
            print("Quing " + neighbour);
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
