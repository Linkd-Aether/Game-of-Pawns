using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
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
        // directions are all four cardinal directions
        Vector2Int[] directions = {
            new Vector2Int(-1, 0), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(0, 1)
        };

        // for each direction, add valid moves until reaching a piece or space without a tile
        foreach (Vector2Int direction in directions){
            Vector2Int current = piece.location + direction;
            Tile tile = board.getTileFromBoard(current);
            // as long as the current tile exits and is empty, add it and look at the next one
            while (tile != null && tile.pieceOnTile == null){
                moves.Add(current);
                current += direction;
                tile = board.getTileFromBoard(current);
            }

            // if the first non-empty space had an enemy, include it too
            if (tile.pieceOnTile.isOppositeSide(piece.isEnemy)){
                moves.Add(current);
            }
        }

        return moves;
    }
}
