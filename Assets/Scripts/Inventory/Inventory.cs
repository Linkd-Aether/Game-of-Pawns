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
    public Piece queuedPiece;
    public int inventoryLimit;

    //Add a piece to the inventory
    public void Add (Piece piece){

        if(pieces.Count <= inventoryLimit){
            AddToList(piece);
            UpdateUI();

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
        pieces.Add(piece);
    }

    public void UpdateUI(){
        Debug.Log("Updating UI with length of " + pieces.Count);
        

        for(int i = 0; i < 4; i++){
            
            //Get the newest open slot by using the list of pieces
            string desiredSlot = "InventorySlot" + (i+1);
            Debug.Log("desired slot " + desiredSlot);
            //Transform testTransform = instance.transform.Find("InventorySlot1");
            GameObject slotObject = instance.transform.GetChild(i).gameObject;
            InventorySlot slotScript = slotObject.GetComponent<InventorySlot>();
            
            if(i < pieces.Count){
                Debug.Log("sprite garble: " + pieces[i].icon);
                slotScript.AddPiece(pieces[i]);
            } else {
                slotScript.ClearSlot();
            }
            
        }
    }
}
