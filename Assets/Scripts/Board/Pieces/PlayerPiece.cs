using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : Piece
{

    public static PlayerPiece instance;

    private void Awake(){
        DontDestroyOnLoad(gameObject);

        if(instance == null){
            instance = this;
        }
    }
}
