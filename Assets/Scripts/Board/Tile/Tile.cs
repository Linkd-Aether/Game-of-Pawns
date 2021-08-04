using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer spriteRenderer;
    public Piece pieceOnTile;
    public Vector2Int tilePosition;

    void Awake()
    {
        //get sprite renderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    /**
    Renders a sprite
    */
    public void renderSprite(){
        //Sums the x and y position of the board, varying visual element depending on if sum is even or odd
        if(((tilePosition.x + tilePosition.y) % 2) == 0){
            spriteRenderer.sprite = Resources.Load<Sprite>("blackTile");
        } else {
            spriteRenderer.sprite = Resources.Load<Sprite>("whiteTile");
        }
    }

    /*
    Helper function made to instantiate a summoned piece on a tile
    */
    public void instantiatePiece(Piece summonedPiece){
        //Define initial variables
        GameObject loadedFile = new GameObject();
        string filePath = "";

        //If else statement to determine piece type and find the appropriate piece game object to spawn in
        if(summonedPiece.type is PawnMoveset){
            loadedFile = Resources.Load<GameObject>(filePath + "PlayerPawn"); 
            
        } else if(summonedPiece.type is RookMoveset){
            loadedFile = Resources.Load<GameObject>(filePath + "PlayerRook"); 
        }

        Piece newPiece = loadedFile.GetComponent<Piece>();

        Piece newSummonedPiece = Instantiate(newPiece, new Vector3(tilePosition.x, tilePosition.y, -2), Quaternion.identity);
        newSummonedPiece.Place(new Vector2Int(tilePosition.x, tilePosition.y));

        
    }
}
