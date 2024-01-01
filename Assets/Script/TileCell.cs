using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCell : MonoBehaviour
{
    public Vector2Int Cordinates { get; set; }

    public Tile Tile { get; set; }

    public bool is_Empty => Tile == null;
    public bool is_Occupied => Tile != null;
}
