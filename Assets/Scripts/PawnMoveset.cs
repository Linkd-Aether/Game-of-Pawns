using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMoveset : Moveset
{
    /**
    Singleton instance
    */
    private static PawnMoveset instance = null;

    /**
    Returns the singleton instance
    */
    public static PawnMoveset Instance {
        get {
            if (instance == null) {
                instance = new PawnMoveset();
            }
            return instance;
        }
    }

    /**
    Returns the name of the type of piece
    */
    override public string GetTypeName(){
        return "Pawn";
    }

    /**
    Calculates which squares are legal for this piece to move on its turn
    */
    override public List<Vector2Int> GetMoves(Piece piece){
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int direction = Vector2Int.up;
        if (piece.isEnemy){
            direction = Vector2Int.down;
        }
        Vector2Int current = piece.location + direction;
        if (/**current is a valid space and there is no piece there*/false){
            moves.Add(piece.location + direction);
            current += direction;
            if (!piece.moved && /**current is a valid space and there is no piece there*/false){
                moves.Add(piece.location + direction * 2);
            }
        }
        if (/**left diagonal is an enemy*/false){
            moves.Add(piece.location + direction + new Vector2Int(-1, 0));
        }
        if (/**right diagonal is an enemy*/false){
            moves.Add(piece.location + direction + new Vector2Int(1, 0));
        }
        return moves;
    }
}
