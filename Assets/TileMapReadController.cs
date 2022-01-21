using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] List<TileData> tileDatas;
    Dictionary<TileBase, TileData> dataFromTiles;

    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(TileData tiledata in tileDatas)
        {
            foreach(TileBase tile in tiledata.tiles)
            {
                dataFromTiles.Add(tile, tiledata);
            }
        }
    }

    public Vector3Int GetGridPosition(Vector2 _position, bool _mousePosition)
    {
        Vector3 worldPosition;

        if (_mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(_position);
        }
        else
        {
            worldPosition = _position;
        }

        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);

        return gridPosition;
    }

    public TileBase GetTileBase(Vector3Int gridPosition, bool _mousePosition = false)
    {
        TileBase tile = tilemap.GetTile(gridPosition);

        return tile;
    }

    public TileData GetTileData(TileBase _tilebase)
    {
        return dataFromTiles[_tilebase];
    }
}
