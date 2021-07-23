using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
public int rows;
public int columns;
public Tile[] boardTiles;
private float tileSize = 1;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Tan me high, Fred");
        GenerateGrid();

        
    }

    /**
    Generates a grid of tiles that we can play on, still need to generate tile objects but
    structure is largely down
    */
    private void GenerateGrid() {

        //Reference object
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("whiteTile"));
        for (int row = 0; row < rows; row++){
            for (int col = 0; col < columns; col++){

                //Make tile from reference object
                //GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                //make new object
                Tile newTile = gameObject.AddComponent<Tile>() as Tile;

                //set new tile position
                newTile.Instance.tilePosition.x = col;
                newTile.Instance.tilePosition.y = row;

                //Assign object coordinates
                float positionX = col * tileSize;
                float positionY = row * -tileSize;

                newTile.Instance.tileCoordinates = new Vector2(positionX, positionY);

                newTile.transform.position = newTile.Instance.tileCoordinates;
            }
        }

        Destroy(referenceTile);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
