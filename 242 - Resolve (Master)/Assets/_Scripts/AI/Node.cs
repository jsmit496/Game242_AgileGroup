using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public int gridX;
    public int gridY;

    public Vector3 position;

    public Node parent;

    public int gCost;
    public int hCost;

    public int FCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public Node(bool _walkable, Vector3 _position, int _gridX, int _gridY)
    {
        walkable = _walkable;
        position = _position;
        gridX = _gridX;
        gridY = _gridY;
    }
}
