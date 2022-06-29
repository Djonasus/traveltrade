
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public TileData[] TilePrefabs;
    public TileData[,] SpawnedTiles;
    public Vector2Int MapSize;

    // Start is called before the first frame update
    void Start()
    {
        SpawnedTiles = new TileData[MapSize.x, MapSize.y];
        StartCoroutine(GenerateMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator GenerateMap()
    {
        PlaceTile(MapSize.x / 2, MapSize.y / 2);
        while (true)
        {
            Vector2Int pos;
            while (true)
            {
                pos = new Vector2Int(Random.Range(1, MapSize.x - 1), Random.Range(1, MapSize.y - 1));
                if(SpawnedTiles[pos.x, pos.y] == null &&
                    (SpawnedTiles[pos.x+1,pos.y] != null ||
                    SpawnedTiles[pos.x - 1, pos.y] != null ||
                    SpawnedTiles[pos.x, pos.y+1] != null ||
                    SpawnedTiles[pos.x, pos.y-1] != null))
                {
                    break;
                }
            }
            PlaceTile(pos.x, pos.y);

            yield return new WaitForSeconds(.2f);
        }
    }
    public void PlaceTile(int x, int y)
    {
        List<TileData> availableTiles = new List<TileData>();

        foreach (var tilePrefab in TilePrefabs)
        {
            if (CanAppendTile(SpawnedTiles[x-1,y], tilePrefab, TileDirection.West) &&
                CanAppendTile(SpawnedTiles[x - 1, y], tilePrefab, TileDirection.East) &&
                CanAppendTile(SpawnedTiles[x - 1, y], tilePrefab, TileDirection.North) &&
                CanAppendTile(SpawnedTiles[x - 1, y], tilePrefab, TileDirection.South))
            {
                availableTiles.Add(tilePrefab);
            }
        }

        if (availableTiles.Count == 0)
        {
            return;
        }

        SpawnedTiles[x,y] = Instantiate(availableTiles[Random.Range(0, availableTiles.Count)], new Vector3(x, 0, y)*0.8f, Quaternion.identity);
    }
    bool CanAppendTile(TileData existingTile, TileData TileToAppend, TileDirection direction)
    {
        if (existingTile == null) return true;
        else if (direction == TileDirection.South) return (existingTile.NorthSide == TileToAppend.SouthSide);
        else if (direction == TileDirection.North) return (existingTile.SouthSide == TileToAppend.NorthSide);
        else if (direction == TileDirection.East) return (existingTile.WestSide == TileToAppend.EastSide);
        else if (direction == TileDirection.West) return (existingTile.EastSide == TileToAppend.WestSide);
        else throw new System.ArgumentException("Wrong Direction Value!",nameof(direction));
    }
}
