using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int GRIDSIZE = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGridSize()
    {
        return GRIDSIZE;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                 Mathf.RoundToInt(transform.position.x / GRIDSIZE) * GRIDSIZE,
                 Mathf.RoundToInt(transform.position.z / GRIDSIZE) * GRIDSIZE
            );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRender = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;
    }
}
