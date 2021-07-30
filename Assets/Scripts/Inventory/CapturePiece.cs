using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePiece : DefeatPiece
{
    public Piece piece;
    
    public override void Capture(){
        base.Capture();


    }
    

    private void PickUp(){
        Debug.Log("Obtaining piece" + piece.type);
        Inventory.instance.Add(piece);
        Destroy(gameObject);
    }
}
