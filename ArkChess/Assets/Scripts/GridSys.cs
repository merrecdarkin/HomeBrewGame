using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridsys : MonoBehaviour
{
    Nodes[,] grid;
    [SerializeField] int width= 25;
    [SerializeField] int length= 25;
    [SerializeField] float CellSize= 1f;


    // Start is called before the first frame update
    void Start()
    {
        grid= new Nodes[length, width];
    }

    private void OnDrawGizmos(){
        for (int y = 0; y <width; y ++){
            for (int x = 0; x <length; x ++){
            Vector3 pos = new Vector3(transform.position.x + (x* CellSize), 0f, transform.position.z + (y*CellSize));
            Gizmos.DrawCube(pos, Vector3.one);
        }
        }
    }

    
}
