using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector2Int location;
    public Sprite icon = null;
    public Moveset type;
    public bool isEnemy = false;
    public bool moved = false;
    public GridManager board;

    /**
    Places the piece at the specified location. If there is no space there, or there is a piece or obstacle, it
    results in unspecified behavior.
    */
    public void Place(Vector2Int targetLocation){
        location = targetLocation;
        transform.position = new Vector3(targetLocation.x, targetLocation.y);
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

    void Start()
    {
        // test initialization
        type = PawnMoveset.Instance;
        location = new Vector2Int(2,3);
        List<Vector2Int> moves = type.GetMoves(this);
        // Debug statements
        Debug.Log("Piece Location: (" + location.x + ", " + location.y + ")");
        Debug.Log("Piece Type: " + type.GetTypeName());
        Debug.Log("Number of spaces to move to: " + moves.Count);
        Debug.Log("Moves:");
        foreach (Vector2Int move in moves){
           Debug.Log("    (" + move.x + ", " + move.y + ")");
        }
    }
}
