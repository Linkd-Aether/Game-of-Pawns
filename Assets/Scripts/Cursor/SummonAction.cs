using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAction : Action
{
    public GameObject pieceToSummon;
    public List<Vector2Int> validSpaces;
    public Object movePreviewPrefab = Resources.Load("moveProject");
    private List<GameObject> spacePreviewObjects = new List<GameObject>();

    private int currentSlotPieces;

    private Moveset pieceMovesetType;

    /**
    Constructs the SummonAction with the selected piece type
    */
    public SummonAction(CursorController controller, Moveset pieceType, int slotPieces) : base(controller){
        Debug.Log("ran summon action!");
        
        validSpaces = PlayerPiece.instance.GetMoves();
        currentSlotPieces = slotPieces;
        pieceMovesetType = pieceType;

        foreach (Vector2Int space in validSpaces){
            Vector3 position = new Vector3(space.x, space.y, -1);
            GameObject spaceProject = GameObject.Instantiate(movePreviewPrefab, position, Quaternion.identity) as GameObject;
            spacePreviewObjects.Add(spaceProject);
        }
    }

    /**
    Summons the selected captured piece on the clicked tile if it is valid to be summoned there, otherwise
    either deselects the captured piece, or selects a friendly piece.
    */
    override public void onClick(Tile tile){
        if (tile != null && validSpaces.Contains(tile.tilePosition) && currentSlotPieces > 0){

            Debug.Log("help");

            // TODO instantiate pieceToSummon at the location
            GridManager.Instance.CreateSummonedPiece(pieceMovesetType, tile);
            Inventory.instance.UpdateUISubtract(pieceMovesetType);
            onEnd();
            cursorController.currentAction = new Action(cursorController);
            
            // TODO call enemy controller to execute the enemy's turn
        } else {
            base.onClick(tile);
        }
    }

    /**
    When the MoveAction ends, remove all move projections
    */
    public override void onEnd()
    {
        foreach (GameObject moveProject in spacePreviewObjects){
            Transform.Destroy(moveProject);
        }
    }
}
