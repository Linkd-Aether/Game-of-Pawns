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
        ChangeCursor(cursor);
        DetectObject();
    }

    private void DetectObject(){

        //Ray we project from the mouse
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());

        //Detects what a ray hits
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if(hits2D.collider != null){
            IClicked click = hits2D.collider.gameObject.GetComponent<IClicked>();

            if(click != null){
                click.onClickAction();
            }

            Debug.Log("Hit2D collider: " + hits2D.collider.tag);
        } else {
            Debug.Log("Fuck");
        }
    }

    //Change cursor sprite on and off click
    private void ChangeCursor(Texture2D cursorType){

        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }


}
