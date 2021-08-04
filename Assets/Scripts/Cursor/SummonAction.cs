using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAction : Action
{
    public GameObject pieceToSummon;
    public List<Vector2Int> validSpaces;
    public Object movePreviewPrefab = Resources.Load("moveProject");
    private List<GameObject> spacePreviewObjects = new List<GameObject>();

    /**
    Constructs the SummonAction with the selected piece type
    */
    public SummonAction(CursorController controller, GameObject piece) : base(controller){
        pieceToSummon = piece;
        Debug.Log("ran summon action!");
        validSpaces = controller.GetComponent<PlayerPiece>().GetMoves();
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
        if (tile != null && validSpaces.Contains(tile.tilePosition)){

            // TODO instantiate pieceToSummon at the location
            Piece summonPieceData = pieceToSummon.GetComponent<Piece>();
            tile.pieceOnTile = summonPieceData;
            tile.instantiatePiece(summonPieceData);
            
            
            // TODO call enemy controller to execute the enemy's turn
        }
    }
}
