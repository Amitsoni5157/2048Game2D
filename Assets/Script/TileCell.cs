using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCell : MonoBehaviour
{
    public Vector2Int Cordinates { get; set; }

    public Tile tile { get; set; }

    public bool is_Empty => tile == null;
    public bool is_Occupied => tile != null;
}
