using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IClicked
{
    // Start is called before the first frame update

    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public bool isTraversable;
    public Piece pieceOnTile;
    public Vector2Int tilePosition;
    public Vector2 tileCoordinates;

    public Tile Instance = null;
    
    void Awake()
    {
        //Debug.Log("camp fred");
        if(Instance == null){
            Instance = this;
        } else if(Instance != this){
            Destroy(gameObject);
        }

        //Add and get sprite renderer
        gameObject.AddComponent<SpriteRenderer>();
        gameObject.AddComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
        boxCollider = gameObject.GetComponent<BoxCollider2D>();

        boxCollider.size = new Vector2(1,1);                    
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void onClickTile(){
        Debug.Log("Clicking tile");
    }

    public void onClickAction(){
        Debug.Log("Tile " + tilePosition.x + "-" + tilePosition.y);
    }
}
