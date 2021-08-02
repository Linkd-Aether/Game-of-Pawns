using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;
    private Piece piece;

    private Button inventoryButton;

    private void Awake(){
        inventoryButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        inventoryButton.interactable = false;
    }


    //Add piece to the UI
    public void AddPiece(Piece newPiece){
        piece = newPiece;

        icon.sprite = piece.icon;
        icon.enabled = true;

        inventoryButton.interactable = true;
    }

    //Clear the slot of the piece
    public void ClearSlot(){
        piece = null;
        icon.sprite = null;
        icon.enabled = false;

        inventoryButton.interactable = false;
    }

    //getter for piece
    public Piece getPiece(){
        return piece;
    }

    public void RemoveItemFromInventory(){
        Inventory.instance.Remove(piece);
    }

    //Summon the piece
    public void UsePiece(){
        Debug.Log("checkmate pog");
        if(piece != null){
            //piece.Place();
        }
    }
}
