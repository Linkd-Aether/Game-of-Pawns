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
        //Debug.Log("ran summon action!");
        
        //Save inventory variables to private values in InventorySlot
        currentSlotPieces = slotPieces;
        pieceMovesetType = pieceType;

        //Get valid spaces and instantiate them
        if (PlayerPiece.instance == null){
            Debug.Log("could not find PlayerPiece instance");
            return;
        }
        validSpaces = PlayerPiece.instance.GetMoves();
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

            //Debug.Log("help");

            //instantiate pieceToSummon at the location
            Inventory.instance.UpdateUISubtract(pieceMovesetType);
            GridManager.Instance.CreateSummonedPiece(pieceMovesetType, tile, false);
            onEnd();

            // TODO call enemy controller to execute the enemy's turn

            cursorController.currentAction = new Action(cursorController);
            
            
        } else {
            base.onClick(tile);
        }
    }

    /**
    When the SummonAction ends, remove all move projections
    */
    public override void onEnd()
    {
        foreach (GameObject moveProject in spacePreviewObjects){
            Transform.Destroy(moveProject);
        }
    }
}
