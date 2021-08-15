using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private static string[] movementTypes =
        {"PawnMovement",
         "RookMovement",
         "BishopMovement",
         "KnightMovement"};


    // Spawns a variable amount of pieces around the spawn point
    public static void SpawnPieces(int difficulty, Vector2Int location)
    {
        // Empties the location of the spawner marker
        GridManager.Instance.getTileFromBoard(location).pieceOnTile = null;

        // Spawns a guaranteed enemy on the spawner's location
        string randMovement = movementTypes[Random.Range(0, movementTypes.Length)];

        GridManager.Instance.CreatePlayerPiece(Resources.Load<Moveset>(randMovement), GridManager.Instance.getTileFromBoard(location), true);

        // Spawns a random amount of other enemies within a range, all decided by difficulty
        int randPasses = Random.Range(difficulty - 1, difficulty + 1);

        for(int i = 0; i < randPasses; i++)
        {

            // alternative math for more clumping if I can prove it works:
            int randX = (int)(Mathf.Pow(Random.value, 2) * (difficulty * 2));
            randX -= randX / 2;

            int randY = (int)(Mathf.Pow(Random.value, 2) * (difficulty * 2));
            randY -= randY / 2;


            if (location.x + randX >= 0 &&
                location.y + randY >= 0 &&
                GridManager.Instance.getTileFromBoard(new Vector2Int(location.x + randX, location.y + randY)).pieceOnTile == null)
            {
                randMovement = movementTypes[Random.Range(0, movementTypes.Length)];
                GridManager.Instance.CreatePlayerPiece(Resources.Load<Moveset>(randMovement), GridManager.Instance.getTileFromBoard(new Vector2Int(location.x + randX, location.y + randY)), true);
            }
        }
    }
}
