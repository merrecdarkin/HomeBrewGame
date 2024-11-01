using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyPointScript : MonoBehaviour
{
 
    public void setRallyPoint(Vector3 setPlace){
        transform.position=setPlace;
    }
}
