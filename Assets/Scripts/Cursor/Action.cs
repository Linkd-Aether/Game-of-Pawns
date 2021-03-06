using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public CursorController cursorController;

    /**
    Constructs the action with a reference to the cursor controller
    */
    public Action(CursorController controller){
        cursorController = controller;
    }

    /**
    Selects a friendly piece on the clicked square, if there is one
    */
    virtual public void onClick(Tile tile){
        if (tile != null && tile.pieceOnTile != null && tile.pieceOnTile.isEnemy == false){
            onEnd();
            cursorController.currentAction = new MoveAction(cursorController, tile.pieceOnTile);
        }
        else{
            onEnd();
            cursorController.currentAction = new Action(cursorController);
        }
    }

    /**
    Should be called whenever the action is changed
    */
    virtual public void onEnd(){

    }
}
