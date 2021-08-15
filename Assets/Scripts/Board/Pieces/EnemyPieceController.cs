using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPieceController : MonoBehaviour
{

    public static EnemyPieceController instance;
    

    public void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    public void EnemyTurn(){
        if(gameObject.transform.childCount > 0){
            for(int i = 0; i < gameObject.transform.childCount; i++){
            GameObject currentPiece = gameObject.transform.GetChild(i).gameObject;
            }
        } else {
            //Trigger next transition?
        } 
    }

    private void PawnTurn(GameObject currentPiece){
        Piece objectPiece = currentPiece.GetComponent<Piece>();
        Moveset pieceMoveset = objectPiece.type;
        List<Vector2Int> moves = pieceMoveset.GetMoves(objectPiece);

        //See if the piece can kill a diagonal target
        bool isEnemyDetected = false;
        foreach(Vector2Int move in moves){

            //If there's a diagonal move, go for it!
            if(move.y != objectPiece.location.y){
                pieceMoveset.ExecuteMove(objectPiece, move);
                isEnemyDetected = true;
            }
        }

        //If there are no victims, randomly move forward one or two spaces.
        if(!isEnemyDetected){
            Vector2Int randomMove = moves[Random.Range(0, moves.Count)];
            pieceMoveset.ExecuteMove(objectPiece, randomMove);
        }        
    }

    private void RookTurn(GameObject currentPiece){
        Piece objectPiece = currentPiece.GetComponent<Piece>();
        Moveset pieceMoveset = objectPiece.type;
        List<Vector2Int> moves = pieceMoveset.GetMoves(objectPiece);

    }
}
