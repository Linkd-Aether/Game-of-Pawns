using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveset : Moveset
{
    /**
    Singleton instance
    */
    private static ObstacleMoveset instance = null;

    /**
    Returns the singleton instance
    */
    public static ObstacleMoveset Instance {
        get {
            if (instance == null) {
                instance = new ObstacleMoveset();
            }
            return instance;
        }
    }

    /**
    Returns the name of the type of piece
    */
    override public string GetTypeName(){
        return "Obstacle";
    }

    /**
    Calculates which squares are legal for this piece to move on its turn
    */
    override public List<Vector2Int> GetMoves(Piece piece){
        return new List<Vector2Int>();
    }
}
