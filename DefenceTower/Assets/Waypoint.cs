using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor = Color.grey;
    Vector2Int gridPos;
    const int GRIDSIZE = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;
   
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
       if (exploredFrom != null)
        {
            this.SetTopColor(Color.grey);
        }

    }

    public int GetGridSize()
    {
        return GRIDSIZE;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                 Mathf.RoundToInt(transform.position.x / GRIDSIZE) ,
                 Mathf.RoundToInt(transform.position.z / GRIDSIZE) 
            );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRender = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;
    }
}
