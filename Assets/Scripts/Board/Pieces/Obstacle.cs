using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Piece
{
    /**
    Returns whether or not the piece is an enemy to the given side (true is enemy)
    */
    override public bool isOppositeSide(bool side){
        return false;
    }
}
