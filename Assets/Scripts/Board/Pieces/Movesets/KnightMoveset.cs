using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KnightMoveset : Moveset
{

    /**
    Singleton instance
    */
    private static KnightMoveset instance = null;

    /**
    Returns the singleton instance
    */
    public static KnightMoveset Instance {
        get {
            if (instance == null) {
                instance = new KnightMoveset();
            }
            return instance;
        }
    }

     /**
    Returns the name of the type of piece
    */
    override public string GetTypeName(){
        return "Knight";
    }

   /**
    Calculates which squares are legal for this piece to move on its turn
    */
    override public List<Vector2Int> GetMoves(Piece piece){
        List<Vector2Int> moves = new List<Vector2Int>();

        if(board == null)
        {
            board = GridManager.Instance;
        }

        getKnightMove(moves, piece, new Vector2Int(-2, 1));
        getKnightMove(moves, piece, new Vector2Int(-1, 2));
        getKnightMove(moves, piece, new Vector2Int(-2, -1));
        getKnightMove(moves, piece, new Vector2Int(-1, -2));
        getKnightMove(moves, piece, new Vector2Int(2, 1));
        getKnightMove(moves, piece, new Vector2Int(1, 2));
        getKnightMove(moves, piece, new Vector2Int(2, -1));
        getKnightMove(moves, piece, new Vector2Int(1, -2));

        return moves;
    }

    private void getKnightMove(List<Vector2Int> moves, Piece piece, Vector2Int tilePosition){
        Vector2Int current = piece.location + tilePosition;
        Tile tile = board.getTileFromBoard(current);

        if(tile != null && tile.pieceOnTile == null){
            moves.Add(current);
        }
    }
}
