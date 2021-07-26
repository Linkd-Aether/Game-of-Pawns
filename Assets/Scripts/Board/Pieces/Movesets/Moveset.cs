using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Moveset
{
    /**
    Returns the name of the type of piece
    */
    abstract public string GetTypeName();
    
    /**
    Calculates which squares are legal for this piece to move on its turn
    */
    abstract public List<Vector2Int> GetMoves(Piece piece);

    /**
    Executes a move to the target location (might be changed with upgrades, but otherwise constant between pieces)
    */
    public void ExecuteMove(Piece piece, Vector2Int targetLocation){
        //TODO
        //if the square at the targetLocation has an opponent's piece, remove it, and if it was an enemy that
        //was captured, add a piece of that type to the captured pieces
        //then move the moving piece to the target location, and update the tile's slot
    }
}
