using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector2Int pieceLocation { get; set; }
    public PieceType type { get; set; } = new BasePawn();
    public bool isEnemy { get; set; } = false;

    // Start is called before the first frame update
    private void Start()
    {
        pieceLocation = new Vector2Int(2,3);
        Debug.Log("Get moves");
        type.GetMoves(pieceLocation, isEnemy);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
