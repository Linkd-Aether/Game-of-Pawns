using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : Piece
{
    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }
}
