using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer spriteRenderer;
    public bool isTraversable;
    public Piece pieceOnTile;
    public Vector2 tilePosition;
    public Vector2 tileCoordinates;

    public Tile Instance = null;
    
    void Awake()
    {
        Debug.Log("camp fred");
        if(Instance == null){
            Instance = this;
        } else if(Instance != this){
            Destroy(gameObject);
        }
        gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
     
        
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void renderSprite(){
        int tilePosSum = (int)(tilePosition.x + tilePosition.y);

        Debug.Log(tilePosSum);

        if(((tilePosition.x + tilePosition.y) % 2) == 0){
            spriteRenderer.sprite = Resources.Load<Sprite>("blackTile");
        } else {
            spriteRenderer.sprite = Resources.Load<Sprite>("whiteTile");
        }
    }
}
