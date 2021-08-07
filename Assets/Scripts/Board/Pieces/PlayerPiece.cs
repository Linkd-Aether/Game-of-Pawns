using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : Piece
{

    public static PlayerPiece instance;

    private void Awake(){
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
}
