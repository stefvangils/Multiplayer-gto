using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCasting : MonoBehaviour {

    public LayerMask layerMaskUnit;
    public Text x;
    public Text y;
    public Map Map;
    private Vector2Int SpawnCoordinate;

    GameObject selectedgameobject;
	// Use this for initialization
	void Start () {
        selectedgameobject = null;
	}
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetKeyDown(KeyCode.Space))
        //      {
        //          Debug.DrawRay(Vector3.zero, Vector3.forward * 5, Color.magenta, 5);

        //          RaycastHit raycastHit;

        //          if(Physics.Raycast(Vector3.zero, Vector3.forward, out raycastHit, 5))
        //          {
        //              raycastHit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
        //          }
        //      }


        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, 5);
            if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMaskUnit))
            {
               
                SelectUnit(raycastHit.transform.parent.gameObject);
                
            }
            else
            {
                Deselect();
            }
           
        }
    }

    void SelectUnit(GameObject unitToSelect)
    {
        selectedgameobject = unitToSelect;
        selectedgameobject.GetComponent<MeshRenderer>().material.color = Color.red;

    }

    void Deselect()
    {
        if (selectedgameobject != null)
        {
            selectedgameobject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        

    }

    public void MoveUnit()
    {
        Debug.Log("moveunit is bereikt");
        if (selectedgameobject != null)
        {
            Debug.Log("object is not null");
            SpawnCoordinate.x = Convert.ToInt32(x.text);
            SpawnCoordinate.y = Convert.ToInt32(y.text);

            Cell cell = Map.GetCell(SpawnCoordinate.x, SpawnCoordinate.y);

            selectedgameobject.transform.SetParent(cell.transform, false);
        }
    }
}
