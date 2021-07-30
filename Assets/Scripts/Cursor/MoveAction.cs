using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    public Piece selectedPiece;
    public List<Vector2Int> validMoves;
    public Object movePreviewPrefab = Resources.Load("moveProject");
    private List<GameObject> movePreviewObjects = new List<GameObject>();

    /**
    Constructs the MoveAction with the selected piece
    */
    public MoveAction(CursorController controller, Piece piece) : base(controller){
        selectedPiece = piece;
        validMoves = selectedPiece.GetMoves();
        Debug.Log("loaded moves: " + validMoves);
        foreach (Vector2Int move in validMoves){
            Debug.Log("Loaded moveProject");
            Vector3 position = new Vector3(move.x, move.y, -1);
            GameObject moveProject = GameObject.Instantiate(movePreviewPrefab, position, Quaternion.identity) as GameObject;
            movePreviewObjects.Add(moveProject);
        }
    }

    /**
    Executes a move if the move is valid. If it is not, acts the same as selecting a piece
    */
    override public void onClick(Tile tile){
        if (tile != null && validMoves.Contains(tile.tilePosition)){
            selectedPiece.ExecuteMove(tile.tilePosition);
            onEnd();
            cursorController.currentAction = new Action(cursorController);
            // TODO call enemy controller to execute the enemy's turn
        }
        else{
            base.onClick(tile);
        }
    }

    /**
    When the MoveAction ends, remove all move projections
    */
    public override void onEnd()
    {
        foreach (GameObject moveProject in movePreviewObjects){
            Transform.Destroy(moveProject);
        }
    }
}
