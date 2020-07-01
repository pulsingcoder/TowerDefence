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
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();
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
        
    }

    private void CreatePath()
    {
        path.Add(end);
        Waypoint previous = end.exploredFrom;
        while (previous != start)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(start);
        path.Reverse();
    }

    private void BreathFirstSearch()
    {
        queue.Enqueue(start);
        while(queue.Count >0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }
       
        
    }

    private void HaltIfEndFound()
    {
       if (searchCenter == end)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int dir in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + dir;
            if (grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbour(explorationCoordinates);
            }
            
        }    
    }

    private void QueueNewNeighbour(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing
        }
        else
        {
           
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
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
    public List<Waypoint> GetPath()
    {
        LookBlocks();
        ColorStartEnd();
        BreathFirstSearch();
        CreatePath();
        return path;
    }
}
