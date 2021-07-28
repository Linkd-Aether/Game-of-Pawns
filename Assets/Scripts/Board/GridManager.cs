using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

// test piece instatiation
public Piece playerPawn;
public Piece playerRook;
public Piece enemyPawn;
public Piece enemyRook;

public int rows;
public int columns;
public Tile[,] boardArray;
public List<Tile> boardTiles = new List<Tile>();
private float tileSize = 1;


    // Start is called before the first frame update
    private void Start()
    {
        GenerateGrid();
    }

    /**
    Generates a grid of tiles that we can play on, still need to generate tile objects but
    structure is largely down
    */
    private void GenerateGrid() {

        //Specify boardArray dimensions
        boardArray = new Tile[columns, rows];

        for (int row = 0; row < rows; row++){
            for (int col = 0; col < columns; col++){

                //Make tile from reference object
                //GameObject tile = (GameObject)Instantiate(referenceTile, transform);


                //make new object
                GameObject tile = new GameObject();
                tile.transform.parent = transform;
                Tile newTile = tile.AddComponent<Tile>() as Tile;
                Tile getTile = tile.GetComponent<Tile>();

                //tile.newTile.tileSprite = Resources.Load("whiteTile") as Sprite;

                //getTile.tilePosition
                //set new tile position
                getTile.Instance.tilePosition.x = col;
                getTile.Instance.tilePosition.y = row;

                //Assign object coordinates
                float positionX = col * tileSize;
                float positionY = row * tileSize;

                newTile.Instance.tileCoordinates = new Vector2(positionX, positionY);

                tile.transform.position = new Vector2(positionX, positionY);
                tile.name = "Square" + col + "-" + row;
                //newTile.tileSprite = Resources.Load("whiteTile") as Sprite;
                //Instantiate(tile, new Vector3(positionX, positionY, 0), Quaternion.identity);
                //newTile.transform.position = new Vector2(positionX, positionY);
                getTile.renderSprite();

                boardArray[col, row] = getTile;
                //boardTiles.Add(getTile);
            }
        }

        //test piece instantiation
        if (rows > 4 && columns > 4){
            Piece pPawn = Instantiate(playerPawn, new Vector3(0, 0, 0), Quaternion.identity);
            pPawn.Place(new Vector2Int(0, 0));
        }
    }

    /*
    Gets a tile from the board
    */
    public Tile getTileFromBoard(int col, int row){
        if (col < 0 || col >= columns || row < 0 || row >= rows){
            return null;
        }
        return boardArray[col, row];
    }
    public Tile getTileFromBoard(Vector2Int position){
        return getTileFromBoard(position.x, position.y);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
