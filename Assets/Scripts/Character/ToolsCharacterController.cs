using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if(Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    private void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);

    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    //���忡 ��ġ�� ��ü�� �ݶ��̴��� ��ȣ�ۿ�
    private bool UseToolWorld()
    {
        //ĳ������ ���� ��ġ + ĳ���Ͱ� �ٶ󺸴� ���� * ���� ����
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit !=null)
            {
                hit.Hit();
                return true;
            }
        }
        return false;
    }

    //�׸��� ������ ��ȣ�ۿ�
    private void UseToolGrid()
    {
        TileBase tilebase = tileMapReadController.GetTileBase(selectedTilePosition);
        TileData tileData = tileMapReadController.GetTileData(tilebase);
        if (tileData != plowableTiles) { return; }

        if (cropsManager.Check(selectedTilePosition))
        {
            cropsManager.Seed(selectedTilePosition);
        }
        else
        {
            cropsManager.Plow(selectedTilePosition);
        }
    }
}
