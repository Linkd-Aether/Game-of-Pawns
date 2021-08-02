using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public delegate void OnPieceChanged();

    public OnPieceChanged onPieceChangedCallback;
    public static Inventory instance;

    void Awake(){
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }

        instance = this;
    }

    #endregion
    public List<Piece> pieces = new List<Piece>();
    public int inventoryLimit;

    //Add a piece to the inventory
    public void Add (Piece piece){

        if(pieces.Count <= inventoryLimit){
            AddToList(piece);

            //Indicate that a piece was changed if it was
            if(onPieceChangedCallback != null){
                onPieceChangedCallback.Invoke();
            }
            
        } else {
            Debug.Log("You've maxed out on pieces!");
        }
        
    }

    //Remove a piece from the list of pieces
    public void Remove (Piece piece){
        pieces.Remove(piece);
    }

    public void AddToList(Piece piece){
        Debug.Log("Piece type: " + piece.type.ToString().Substring(0,1));
    }
}
