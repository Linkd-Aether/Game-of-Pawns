using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;
    public Text pieceQuantity;
    public Moveset storageType;
    public int slotPieces;
    private Button inventoryButton;
    public static InventorySlot instance;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        inventoryButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        inventoryButton.interactable = true;
    }


    /*
    //Add piece to the UI
    public void AddPiece(){
        icon.sprite = piece.icon;
        icon.enabled = true;

        inventoryButton.interactable = true;
    }
    */

    //Summon the piece
    public void UsePiece(){
        Debug.Log("checkmate pog");

        CursorController.instance.currentAction.onEnd();
        CursorController.instance.currentAction = new SummonAction(CursorController.instance, storageType, slotPieces);
        //Inventory.instance.queuedPiece = piece;

    }
}
