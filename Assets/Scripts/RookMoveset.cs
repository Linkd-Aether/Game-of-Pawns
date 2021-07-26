using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMoveset : Moveset
{
    /**
    Singleton instance
    */
    private static RookMoveset instance = null;

    /**
    Returns the singleton instance
    */
    public static RookMoveset Instance {
        get {
            if (instance == null) {
                instance = new RookMoveset();
            }
            return instance;
        }
    }

    /**
    Returns the name of the type of piece
    */
    override public string GetTypeName(){
        return "Rook";
    }

    /**
    Calculates which squares are legal for this piece to move on its turn
    */
    override public List<Vector2Int> GetMoves(Piece piece){
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int[] directions = {
            new Vector2Int(-1, 0), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(0, 1)
        };
        // TODO use board methods to complete rook's GetMoves method
        foreach (Vector2Int direction in directions){
            Vector2Int current = piece.location + direction;
            while(/**Space is on map, and there is no obstacle or friendly piece*/false){
                moves.Add(current);
                current += direction;
                if (/**an enemy is on the space*/false){
                    break;
                }
            }
        }
        return moves;
    }
}
