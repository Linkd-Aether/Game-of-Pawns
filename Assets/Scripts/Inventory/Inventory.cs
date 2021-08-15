using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //public List<Piece> pieces = new List<Piece>();
    public Piece queuedPiece;
    public int inventoryLimit;
    public int capturedPieces;
    public Text summonLimit;

    /**
        Update the UI when a captured piece is added to the player's sleight of pieces
    */
    public void UpdateUIAdd(Moveset moveset){
        //Debug.Log("Adding to UI with " + capturedPieces + " pieces");

        //Determine which slot we need to add to or subtract from
        InventorySlot alteredSlot = getInventorySlotType(moveset);
        
        //Add the piece to the respective moveset
        if (capturedPieces < inventoryLimit)
        {
            capturedPieces += 1;
            alteredSlot.slotPieces += 1;
            alteredSlot.pieceQuantity.text = alteredSlot.slotPieces.ToString();

            summonLimit.text = "Pieces: " + capturedPieces.ToString() + "/" + inventoryLimit;

            //Debug.Log("Total captured pieces: " + capturedPieces);
            //Debug.Log("Captured pieces of altered type: " + alteredSlot.slotPieces);
        }
    }

    /**
        Update the UI when a captured piece is used by the player.
    */
    public void UpdateUISubtract(Moveset moveset)
    {
        //Debug.Log("Subtracting from UI with " + capturedPieces + " pieces");

        //Determine which slot we need to add to or subtract from
        InventorySlot alteredSlot = getInventorySlotType(moveset);
        
        //subtract the piece from the respective moveset
        if (capturedPieces > 0)
        {
            capturedPieces -= 1;
            alteredSlot.slotPieces -= 1;
            alteredSlot.pieceQuantity.text = alteredSlot.slotPieces.ToString();
            
            summonLimit.text = "Pieces: " + capturedPieces.ToString() + "/" + inventoryLimit;
            
            //Debug.Log("Total captured pieces: " + capturedPieces);
            //Debug.Log("Captured pieces of altered type: " + alteredSlot.slotPieces);
        }
    }

    /**
        Helper function that gets the appropriate inventory slot for modification
    */
    public InventorySlot getInventorySlotType(Moveset moveset)
    {
        //Iterate through each object until we find one with the moveset we want
        for (var i = 0; i < transform.childCount; i++)
        {
            InventorySlot slot = transform.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null && moveset == slot.storageType)
            {
                return transform.GetChild(i).GetComponent<InventorySlot>();
            }
        }
        //Go here if we somehow bug out
        Debug.Log("We couldn't find a slot type");
        return null;
    }
}
