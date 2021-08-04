using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class Moveset : ScriptableObject
{
    public static GridManager board;

    public void OnEnable(){
        board = GridManager.Instance;
    }

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
        Tile tile = board.getTileFromBoard(targetLocation);
        if (tile != null){
            // if a piece is on the tile, capture it
            if (tile.pieceOnTile != null){
                //TODO if the player piece was captured, change to a take damage action
                if (tile.pieceOnTile.isEnemy){
                    //add piece of same type to captured pieces
                    Inventory.instance.UpdateUIAdd(tile.pieceOnTile.type);
                }
                //remove captured piece
                Object.Destroy(tile.pieceOnTile.gameObject);
            }
            piece.Place(tile.tilePosition);
            piece.moved = true;
        }
        else{
            Debug.Log("location was not at a tile!");
        }
    }
}
