using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePawn : PieceType
{
    new public List<Vector2Int> GetMoves(Vector2Int pieceLocation, bool isEnemy){
        Debug.Log("Getting moves");
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int direction = Vector2Int.up;
        if (isEnemy){
            direction = Vector2Int.down;
        }
        moves.Add(pieceLocation + direction);
        Debug.Log("Location: " + pieceLocation + "Moves: " + moves);
        return moves;
    }
}
