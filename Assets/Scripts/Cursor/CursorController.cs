using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    //Primary cursor texture
    [SerializeField, Tooltip("Main Cursor")]
    private Texture2D cursor;

    //Cursor texture on click
    [SerializeField, Tooltip("Clicked Cursor")]
    private Texture2D cursorClicked;

    private CursorControls controls;

    public Action currentAction;

    private Camera mainCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    //Enable controls
    private void OnEnable(){
        controls.Enable();
    }

    //Disable controls
    private void OnDisable(){
        controls.Disable();
    }

    private void Start(){

        currentAction = new Action(this);
        Debug.Log("current action initialized: " + currentAction);

        //On these actions, call these functions
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    //Change cursor sprite to clicked sprite
    private void StartedClick(){
        ChangeCursor(cursorClicked);
    }

    //Change cursor sprite to unclicked sprite
    private void EndedClick(){
        Debug.Log("Ended Click");
        ChangeCursor(cursor);
        //DetectObject();
        Vector2 mousePositionFloat = mainCamera.ScreenToWorldPoint(controls.Mouse.Position.ReadValue<Vector2>());
        Debug.Log("mousePositionFloat: " + mousePositionFloat);
        Vector2Int mousePosition = new Vector2Int(Mathf.FloorToInt(mousePositionFloat.x), Mathf.FloorToInt(mousePositionFloat.y));
        Tile tile = GridManager.FindObjectOfType<GridManager>().GetComponent<GridManager>().getTileFromBoard(mousePosition);
        Debug.Log("calling current action's onClick Event");
        Debug.Log("passing " + tile);
        currentAction.onClick(tile);
    }

    //Change cursor sprite on and off click
    private void ChangeCursor(Texture2D cursorType){

        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }


}
