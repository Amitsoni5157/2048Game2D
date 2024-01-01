using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    public Tile TilePrefab;
    public TileState[] tileStates;

    private TileGrid grid;
    private List<Tile> tiles;

    private void Awake()
    {
        grid = GetComponentInChildren<TileGrid>();
        tiles = new List<Tile>(16);
    }

    private void Start()
    {
        CreateTile();
        CreateTile();
    }

    private void CreateTile()
    {
        Tile tile = Instantiate(TilePrefab, grid.transform);
        tile.SetState(tileStates[0],2);
        tile.Spawn(grid.GetRandomEmptyCell());
        tiles.Add(tile);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveTiles(Vector2Int.up,0,1,1,1);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveTiles(Vector2Int.down, 0, 1, grid.height-2, -1);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTiles(Vector2Int.left, 1, 1, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTiles(Vector2Int.right, grid.width -2, -1, 0, 1);
        }

    }

    private void MoveTiles(Vector2Int direction, int starti,int incrementi,int startj,int incrementj)
    {
        for (int i = starti; i >= 0 && i < grid.width; i+= incrementi)
        {
            for (int j = startj; j >=0 && j < grid.height; j+= incrementj)
            {
                TileCell cell = grid.GetCell(i,j);
                if(cell.is_Occupied)
                {
                    MoveTile(cell.Tile,direction);
                }
            }
        }
    }

    private void MoveTile(Tile tile, Vector2Int direction)
    {
        TileCell newcell = null;
        TileCell adjacent = grid.GetAdjacentCell(tile.cell, direction);

        while (adjacent != null)
        {
            if(adjacent.is_Occupied)
            {
                break;
            }
            newcell = adjacent;
            adjacent = grid.GetAdjacentCell(adjacent, direction);
        }
        if(newcell != null)
        {
            tile.MoveTo(newcell);
        }
    }
}
