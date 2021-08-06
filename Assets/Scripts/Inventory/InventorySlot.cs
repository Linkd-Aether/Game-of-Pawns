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

    /**
        Activated when a piece is clicked, triggering a summon action
    */
    public void UsePiece(){
        Debug.Log("Using piece...");
        CursorController.instance.currentAction.onEnd();
        CursorController.instance.currentAction = new SummonAction(CursorController.instance, storageType, slotPieces);
    }
}
