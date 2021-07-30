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
    private float tileSize = 1;
    public Transform tilePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        boardArray = new Tile[rows, columns];
        GenerateGrid();
    }

    /**
    Generates a grid of tiles that we can play on, still need to generate tile objects but
    structure is largely down
    */
    private void GenerateGrid() {

        for (int row = 0; row < rows; row++){
            for (int col = 0; col < columns; col++){

                //Make tile from reference object
                Tile tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();

                //set new tile position
                tile.tilePosition.x = col;
                tile.tilePosition.y = row;

                //Assign object coordinates
                float positionX = col * tileSize;
                float positionY = row * tileSize;

                tile.transform.position = new Vector2(positionX, positionY);
                tile.name = "Square" + col + "-" + row;
                tile.renderSprite();

                boardArray[col, row] = tile;
                Debug.Log("(" + col + ", " + row + ")" + boardArray[col, row]);
            }
        }

        //test piece instantiation
        if (rows > 4 && columns > 4){
            Piece pPawn = Instantiate(playerPawn, new Vector3(0, 0, -2), Quaternion.identity);
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
        Debug.Log("col: " + col + ", row: " + row + ", boardArray size: " + boardArray);
        return boardArray[col, row];
    }
    public Tile getTileFromBoard(Vector2Int position){
        return getTileFromBoard(position.x, position.y);
    }
}
