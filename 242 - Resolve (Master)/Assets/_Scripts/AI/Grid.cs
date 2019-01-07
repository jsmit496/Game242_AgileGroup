using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform startPosition;
    public LayerMask unwalkable;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float Distance;

    Node[,] grid;
    public List<Node> path;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    private void Update()
    {
        if (path != null)
        {
            foreach (Node node in path)
            {
                print(string.Format("X: {0}; y: {1}", node.gridX, node.gridY));
            }
        }
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool wall = true;
                if (Physics.CheckSphere(worldPoint, nodeRadius, unwalkable))
                {
                    wall = false;
                }

                grid[x, y] = new Node(wall, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 _worldPosition)
    {
        float percentX = ((_worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float percentY = ((_worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    public List<Node> GetNeighborNodes(Node _node)
    {
        List<Node> neighborNodes = new List<Node>();
        int xCheck;
        int yCheck;

        //Right Side
        xCheck = _node.gridX + 1;
        yCheck = _node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }


        //Left Side
        xCheck = _node.gridX - 1;
        yCheck = _node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Top Side
        xCheck = _node.gridX;
        yCheck = _node.gridY + 1;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Bottom Side
        xCheck = _node.gridX;
        yCheck = _node.gridY - 1;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        /*
        //Top-Left Side
        xCheck = _node.gridX - 1;
        yCheck = _node.gridY + 1;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Bottom-Left Side
        xCheck = _node.gridX - 1;
        yCheck = _node.gridY - 1;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Top-Right Side
        xCheck = _node.gridX + 1;
        yCheck = _node.gridY + 1;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Bottom-Right Side
        xCheck = _node.gridX + 1;
        yCheck = _node.gridY - 1;
        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }
        */

        return neighborNodes;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 0.2f, gridWorldSize.y));
        Node aiNode = NodeFromWorldPosition(startPosition.position);

        if (grid != null)
        {
            foreach (Node node in grid)
            {
                if (node.walkable)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                if (path != null)
                {
                    if (path.Contains(node))
                    {
                        Gizmos.color = Color.red;
                    }
                }

                if (aiNode != null)
                {
                    if (aiNode == node)
                    {
                        Gizmos.color = Color.cyan;
                    }
                }

                Gizmos.DrawCube(node.position, new Vector3(1 * (nodeDiameter - Distance), 0.2f, 1 * (nodeDiameter - Distance)));
            }
        }
    }
}
