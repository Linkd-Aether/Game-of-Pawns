using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    bool isDead;

    private Vector2[] playerMoveset;
    private Vector2[] playerLocation;
    private int[] capturedPieces;

    private bool isPlayerTurn = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerTurn){
            foreach (Vector2 move in playerMoveset){

            }
        }
        
    }
}
