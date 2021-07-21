using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

public int rows;
public int columns;
private float tileSize = 1;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Tan me high, Fred");
        GenerateGrid();
    }

    private void GenerateGrid() {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("whiteTile"));
        for (int row = 0; row < rows; row++){
            for (int col = 0; col < columns; col++){
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float positionX = col * tileSize;
                float positionY = row * -tileSize;

                tile.transform.position = new Vector2(positionX, positionY);
            }
        }

        Destroy(referenceTile);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
