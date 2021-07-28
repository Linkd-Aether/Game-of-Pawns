using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAction : Action
{
    public GameObject pieceToSummon;
    public List<Vector2Int> validSpaces;

    /**
    Constructs the SummonAction with the selected piece type
    */
    public SummonAction(CursorController controller, GameObject piece) : base(controller){
        pieceToSummon = piece;
        validSpaces = controller.GetComponent<PlayerPiece>().GetMoves();
    }

    /**
    Summons the selected captured piece on the clicked tile if it is valid to be summoned there, otherwise
    either deselects the captured piece, or selects a friendly piece.
    */
    override public void onClick(Tile tile){
        if (validSpaces.Contains(tile.tilePosition)){
            // TODO instantiate pieceToSummon at the location
            // TODO call enemy controller to execute the enemy's turn
        }
    }
}
