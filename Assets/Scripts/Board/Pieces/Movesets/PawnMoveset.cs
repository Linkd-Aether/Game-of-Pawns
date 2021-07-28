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
        // direction of movement depends on whether piece is an enemy
        Vector2Int direction = Vector2Int.up;
        if (piece.isEnemy){
            direction = Vector2Int.down;
        }

        // able to move forward if no piece is there
        Vector2Int current = piece.location + direction;
        Tile tile = board.getTileFromBoard(current);
        if (tile != null && tile.pieceOnTile == null){
            moves.Add(piece.location + direction);
            current += direction;
            tile = board.getTileFromBoard(current);
            // able to move forward two spaces if there are no pieces there either, and the piece hasn't moved yet
            if (!piece.moved && tile != null && tile.pieceOnTile == null){
                moves.Add(piece.location + direction * 2);
            }
        }

        // able to move diagonally forward if a capturable piece is there
        Vector2Int[] diagOffsets = {Vector2Int.left, Vector2Int.right};
        foreach (Vector2Int diagOffset in diagOffsets){
            current = piece.location + direction + diagOffset;
            tile = board.getTileFromBoard(current);
            if (tile != null && tile.pieceOnTile != null && tile.pieceOnTile.isOppositeSide(piece.isEnemy)){
                moves.Add(current);
            }
        }

        return moves;
    }
}
