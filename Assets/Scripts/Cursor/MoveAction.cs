using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    public Piece selectedPiece;
    public List<Vector2Int> validMoves;

    /**
    Constructs the MoveAction with the selected piece
    */
    public MoveAction(CursorController controller, Piece piece) : base(controller){
        selectedPiece = piece;
        validMoves = selectedPiece.GetMoves();
    }

    /**
    Executes a move if the move is valid. If it is not, acts the same as selecting a piece
    */
    override public void onClick(Tile tile){
        if (tile != null && validMoves.Contains(tile.tilePosition)){
            selectedPiece.ExecuteMove(tile.tilePosition);
            cursorController.currentAction = new Action(cursorController);
            // TODO call enemy controller to execute the enemy's turn
        }
        else{
            base.onClick(tile);
        }
    }
}
