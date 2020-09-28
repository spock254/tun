using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneralTest : MonoBehaviour
{
    public InventoryInit inventory;
    public ItemInit item;

    public Tile tileA;
    public Tilemap tilemap;
    public Vector3Int previous;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 spawnPosition = player.position;
            spawnPosition.x += PlayerMovement.x_player;
            spawnPosition.y += PlayerMovement.y_player;
            Debug.Log("x " + PlayerMovement.x_player);
            Debug.Log("y " + PlayerMovement.y_player);
            Vector3Int currentCell = tilemap.WorldToCell(spawnPosition);
            //tilemap.SwapTile(tileA, tileB);
            tilemap.SetTile(currentCell, tileA);
            tilemap.SetTile(previous, null);
        }
    }
}
