using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer spriteRenderer;
    public Piece pieceOnTile;
    public Vector2Int tilePosition;

    public Tile Instance = null;

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
}
