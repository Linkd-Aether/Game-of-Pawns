using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector2Int location = new Vector2Int(-1, -1);
    public Sprite icon = null;
    public Moveset type;
    public bool isEnemy = false;
    public bool moved = false;

    private void Awake(){
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        icon = renderer.sprite;
    }

    /**
    Places the piece at the specified location. If there is no space there, or there is a piece or obstacle, it
    results in unspecified behavior.
    */
    public void Place(Vector2Int targetLocation){
        GridManager board = GridManager.Instance;
        if (board.getTileFromBoard(location) != null) {
            board.getTileFromBoard(location).pieceOnTile = null;
        }
        board.getTileFromBoard(targetLocation).pieceOnTile = this;
        location = targetLocation;
        transform.position = new Vector3(targetLocation.x, targetLocation.y, -1);
    }

    /**
    Calculates which squares are legal for this piece to move on its turn
    */
    public List<Vector2Int> GetMoves(){
        return type.GetMoves(this);
    }

    /**
    Executes a move to the target location (might be changed with upgrades, but otherwise constant between pieces)
    */
    public void ExecuteMove(Vector2Int targetLocation){
        type.ExecuteMove(this, targetLocation);
    }

    /**
    Returns whether or not the piece is an enemy to the given side (true is enemy)
    */
    virtual public bool isOppositeSide(bool side){
        return side ^ isEnemy;
    }
}
