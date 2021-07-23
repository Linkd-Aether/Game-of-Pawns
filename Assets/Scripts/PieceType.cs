using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceType
{
    public string name;
    public Sprite baseSprite;
    
    public List<Vector2Int> GetMoves(Vector2Int pieceLocation, bool isEnemy){
        List<Vector2Int> moves = new List<Vector2Int>();
        return moves;
    }
    public void ExecuteMove(){
        
    }
}
