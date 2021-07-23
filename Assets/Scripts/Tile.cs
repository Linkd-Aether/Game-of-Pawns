using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite tileSprite;
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
        tileSprite = Resources.Load("whiteTile") as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
