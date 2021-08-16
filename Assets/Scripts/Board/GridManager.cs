using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //prefabs for instantiating pieces
    public Piece defaultPiece;
    public Piece playerPiece;

    //area theme
    public Theme theme;

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

    private static GridManager _instance;

    public static GridManager Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
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
                tile.renderSprite(theme);

                boardArray[col, row] = tile;
                //Debug.Log("(" + col + ", " + row + ")" + boardArray[col, row]);
            }
        }

        //center camera
        Camera.main.transform.position = new Vector3((float)columns / 2, (float)rows / 2, -10);

        //test piece instantiation
        if (rows > 6 && columns > 4){
            CreatePlayerPiece(Resources.Load<Moveset>("PawnMoveset"), getTileFromBoard(new Vector2Int(0, 0)), false);
            CreateSummonedPiece(Resources.Load<Moveset>("RookMoveset"), getTileFromBoard(new Vector2Int(2, 4)), false);
            CreateSummonedPiece(Resources.Load<Moveset>("PawnMoveset"), getTileFromBoard(new Vector2Int(1, 3)), true);
            CreateSummonedPiece(Resources.Load<Moveset>("RookMoveset"), getTileFromBoard(new Vector2Int(6, 3)), true);

            CreateSummonedPiece(Resources.Load<Moveset>("BishopMoveset"), getTileFromBoard(new Vector2Int(0, 1)), false);
            CreateSummonedPiece(Resources.Load<Moveset>("KnightMoveset"), getTileFromBoard(new Vector2Int(0, 2)), false);
        }
    }

    /*
    Gets a tile from the board
    */
    public Tile getTileFromBoard(int col, int row){
        if (col < 0 || col >= columns || row < 0 || row >= rows){
            return null;
        }
        //Debug.Log("col: " + col + ", row: " + row + ", boardArray size: " + boardArray);
        return boardArray[col, row];
    }
    public Tile getTileFromBoard(Vector2Int position){
        return getTileFromBoard(position.x, position.y);
    }

    /*
        Create a summoned piece from the default piece prefab.
    */
    public void CreateSummonedPiece(Moveset moveset, Tile tile, bool isPieceEnemy){
        //Get the default piece prefab

        Piece newSummon = Instantiate(defaultPiece, new Vector3(tile.tilePosition.x, tile.tilePosition.y, -2), Quaternion.identity);
        newSummon.transform.parent = GameObject.Find("EnemyPieceManager").transform;

        //Initialize qualities of the newly summoned piece
        newSummon.type = moveset;
        newSummon.isEnemy = isPieceEnemy;
        newSummon.initSprite();

        newSummon.type.ExecuteMove(newSummon, new Vector2Int(tile.tilePosition.x, tile.tilePosition.y));
        newSummon.moved = false;
    }

    /*
        Create the player's piece from the player piece prefab.
    */
    public void CreatePlayerPiece(Moveset moveset, Tile tile, bool isPieceEnemy){
        //Get the default piece prefab

        Piece newSummon = Instantiate(playerPiece, new Vector3(tile.tilePosition.x, tile.tilePosition.y, -2), Quaternion.identity);

        //Initialize qualities of the newly summoned piece
        newSummon.type = moveset;
        newSummon.isEnemy = isPieceEnemy;
        newSummon.initSprite();

        newSummon.type.ExecuteMove(newSummon, new Vector2Int(tile.tilePosition.x, tile.tilePosition.y));
        newSummon.moved = false;
    }

    // Scans through the grid and spawns enemies on any of the marked spaces
    public void ScanSpawners(int difficulty)
    {
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                if(boardArray[x,y].pieceOnTile.gameObject.tag == "Spawner")
                {
                    Spawner.SpawnPieces(difficulty, new Vector2Int(x, y));
                }
            }
        }
    }
}
