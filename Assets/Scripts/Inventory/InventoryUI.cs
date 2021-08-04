using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update

    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onPieceChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateUI(){

    }
}
