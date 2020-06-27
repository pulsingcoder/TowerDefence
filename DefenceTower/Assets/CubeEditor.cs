using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    // Update is called once per frame
    void Update()
    {
        SnapToGrid();

        UpdateLabel();
    }

    private void UpdateLabel()
    {
        TextMesh textMesh;
        int gridSize = waypoint.GetGridSize();
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x / gridSize + ", " + waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = "cube " + labelText;
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3(
                waypoint.GetGridPos().x,
                0f,
                waypoint.GetGridPos().y
            );
    }
}
