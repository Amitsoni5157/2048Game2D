using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public TileRow[] Rows { get; private set; }
    public TileCell[] Cells { get; private set; }

    public int size => Cells.Length;
    public int height => Rows.Length;
    public int width => size / height;

    private void Awake()
    {
        Rows = GetComponentsInChildren<TileRow>();
        Cells = GetComponentsInChildren<TileCell>();
    }

    private void Start()
    {
        for (int i = 0; i < Rows.Length; i++)//i == y//j == x
        {
            for (int j = 0; j < Rows[i].Cells.Length; j++)
            {
                Rows[i].Cells[j].Cordinates = new Vector2Int(j,i);
            }
        }
    }
    public TileCell GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return Rows[y].Cells[x];
        }
        else
        {
            return null;
        }
    }

    public TileCell GetCell(Vector2Int cordinates)
    {
        return GetCell(cordinates.x,cordinates.y);
    }

    public TileCell GetAdjacentCell(TileCell cell, Vector2Int direction)
    {
        Vector2Int cordinates = cell.Cordinates;
        cordinates.x += direction.x;
        cordinates.y -= direction.y;

        return GetCell(cordinates);
    }

    public TileCell GetRandomEmptyCell()
    {
        int index = Random.Range(0, Cells.Length);
        int startingIndex = index;

        while (Cells[index].is_Occupied)
        {
            index++;
            if(index >= Cells.Length)
            {
                index = 0;
            }

            if(index == startingIndex)
            {
                return null;
            }
        }
        return Cells[index];
    }
}
