using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveControl : MonoBehaviour
{
    public float MovementSet=50.0f;
    public float MovementAnimateS; private bool IsMoving;
    public int Initiative=1; public int InitiativeMod=0;

    private Vector2 placeToMoveTo; 
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject rallypoint;
    private RallyPointScript GetRally;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera= GameObject.Find("MainCamera").GetComponent<Camera>();
        RollInitiativeOnTurn();
        GetRally= rallypoint.GetComponent<RallyPointScript>();
        MovementSet=50.0f;
        placeToMoveTo=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z= 0.0f;
        transform.position= Vector2.MoveTowards(transform.position, rallypoint.transform.position, MovementAnimateS * Time.deltaTime);
        if ((IsMoving)&&(Vector3.Distance(transform.position,rallypoint.transform.position))<0.5f){ IsMoving=false;}

        if ((Input.GetMouseButtonDown(0))&&(!IsMoving)) {
            MovetoPlaceMarker(new Vector2(mouseWorldPos.x, mouseWorldPos.y));
        }
            
            
    }

    void MovetoPlaceMarker(Vector3 placeToMoveToMarked){
        placeToMoveTo.x=placeToMoveToMarked.x;         placeToMoveTo.y=placeToMoveToMarked.x;
            if(MovementSet>(Vector3.Distance(transform.position,placeToMoveToMarked))){
                MovementSet=MovementSet-(Vector3.Distance(transform.position,placeToMoveToMarked));
                Debug.Log(Vector3.Distance(transform.position,placeToMoveToMarked));
                GetRally.setRallyPoint(placeToMoveToMarked);
                IsMoving=true;
            }
        

   }

    public void RollInitiativeOnTurn(){
        Initiative=Random.Range(1,21+InitiativeMod);
    }

   void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MovementSet);
    }

}
