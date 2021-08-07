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

    public static CursorController instance;

    public Action currentAction;

    private Camera mainCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        


        controls = new CursorControls();
        ChangeCursor(cursor, new Vector2(31, 21));
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
        //Debug.Log("current action initialized: " + currentAction);

        //On these actions, call these functions
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    //Change cursor sprite to clicked sprite
    private void StartedClick(){
        //there's no option to save the position of the cursor in the image, from the editor so we have to change
        //the vector manually whenever the cursor changes unfortunately.
        ChangeCursor(cursorClicked, new Vector2(26, 26));
    }

    //Change cursor sprite to unclicked sprite
    private void EndedClick(){
        //Debug.Log("Ended Click");
        ChangeCursor(cursor, new Vector2(31, 21));
        Vector2 mousePositionFloat = mainCamera.ScreenToWorldPoint(controls.Mouse.Position.ReadValue<Vector2>());
        //Debug.Log("mousePositionFloat: " + mousePositionFloat);
        Vector2Int mousePosition = new Vector2Int(Mathf.FloorToInt(mousePositionFloat.x), Mathf.FloorToInt(mousePositionFloat.y));
        Tile tile = GridManager.FindObjectOfType<GridManager>().GetComponent<GridManager>().getTileFromBoard(mousePosition);
        //Debug.Log("calling current action's onClick Event");
        //Debug.Log("passing " + tile);
        currentAction.onClick(tile);
    }

    //Change cursor sprite on and off click
    private void ChangeCursor(Texture2D cursorType, Vector2 hotspot){
        //there's no option to save the position of the cursor in the image, from the editor so we have to change
        //the vector manually whenever the cursor changes unfortunately.
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }


}
