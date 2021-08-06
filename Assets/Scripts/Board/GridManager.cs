using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    // test piece instatiation
    public Piece playerPawn;
    public Piece playerRook;
    public Piece enemyPawn;
    public Piece enemyRook;

    public Piece defaultPiece;

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
        GenerateBoardDetails();
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
                tile.renderSprite();

                boardArray[col, row] = tile;
                //Debug.Log("(" + col + ", " + row + ")" + boardArray[col, row]);
            }
        }

        //center camera
        Camera.main.transform.position = new Vector3((float)columns / 2, (float)rows / 2, -10);

        //test piece instantiation
        if (rows > 8 && columns > 8){
            Piece pPawn = Instantiate(playerPawn, new Vector3(0, 0, -2), Quaternion.identity);
            pPawn.Place(new Vector2Int(0, 0));
            /*
            Piece pRook = Instantiate(playerRook, new Vector3(2, 4, -2), Quaternion.identity);
            pRook.Place(new Vector2Int(2, 4));
            Piece ePawn = Instantiate(enemyPawn, new Vector3(1, 3, -2), Quaternion.identity);
            ePawn.Place(new Vector2Int(1, 3));
            Piece eRook = Instantiate(enemyRook, new Vector3(6, 7, -2), Quaternion.identity);
            eRook.Place(new Vector2Int(6, 3));
            */

            CreateSummonedPiece(Resources.Load<Moveset>("RookMoveset"), getTileFromBoard(new Vector2Int(2, 4)), false);
            CreateSummonedPiece(Resources.Load<Moveset>("PawnMoveset"), getTileFromBoard(new Vector2Int(1, 3)), true);
            CreateSummonedPiece(Resources.Load<Moveset>("RookMoveset"), getTileFromBoard(new Vector2Int(6, 3)), true);
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
        Create a summoned piece from the default piece prefab to instantiate
    */
    public void CreateSummonedPiece(Moveset moveset, Tile tile, bool isPieceEnemy){
        //Get the default piece prefab

        Piece newSummon = Instantiate(defaultPiece, new Vector3(tile.tilePosition.x, tile.tilePosition.y, -2), Quaternion.identity);

        tile.pieceOnTile = newSummon;

        //Initialize qualities of the newly summoned piece
        if(isPieceEnemy){
            newSummon.icon = getEnemyPieceSprite(moveset);
        } else {
            newSummon.icon = getFriendlyPieceSprite(moveset);
        }
        
        newSummon.type = moveset;
        newSummon.isEnemy = isPieceEnemy;
        newSummon.initSprite();

        newSummon.Place(new Vector2Int(tile.tilePosition.x, tile.tilePosition.y));
    }

    /*
        Helper function that gets the appropriate friendly piece sprite depending on the moveset
    */
    private Sprite getFriendlyPieceSprite(Moveset moveset){
        if(moveset is RookMoveset){
            return Resources.Load<Sprite>("Sprites/whiteRook");
        } else if(moveset is PawnMoveset){
            return Resources.Load<Sprite>("Sprites/whitePawn");
        }
        Debug.Log("Could not get sprite. Something's wrong...");
        return null;
    }

    /*
        Helper function that gets the appropriate enemy piece sprite depending on the moveset
    */
    private Sprite getEnemyPieceSprite(Moveset moveset){
        if(moveset is RookMoveset){
            return Resources.Load<Sprite>("Sprites/blackRook");
        } else if(moveset is PawnMoveset){
            return Resources.Load<Sprite>("Sprites/blackPawn");
        } else if(moveset is ObstacleMoveset){
            return Resources.Load<Sprite>("greyTile");
        }
        Debug.Log("Could not get sprite. Something's wrong...");
        return null;
    }

    public void GenerateBoardDetails()
    {

        // Randomly choose a level design from the folder
        string[] files = Directory.GetFiles("Assets/Resources/Level Layouts", "*.chess");
        string levelString = files[Random.Range(0, files.Length)];

        StreamReader reader = new StreamReader(levelString);

        // Reverse the line order because files read top-down
        List<string> levelLines = new List<string>();
        while (!reader.EndOfStream)
        {
            levelLines.Add(reader.ReadLine());
        }
        levelLines.Reverse();


        int row = 0;
        foreach (string rowString in levelLines)
        {
            int col = 0;
            foreach (char colChar in rowString.ToCharArray())
            {
                switch (colChar)
                {
                    case '_':
                        Debug.Log(col + " " + row);
                        CreateSummonedPiece(Resources.Load<Moveset>("ObstacleMoveset"), getTileFromBoard(new Vector2Int(col, row)), true);
                        break;
                    default:
                        break;
                }
                col++;
            }
            row++;
        }
    }
}
