using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSelectorScript : MonoBehaviour
{
    string RoadName;
    bool Checker;
    CheckTerrainTexture terrainTexture;
    // Start is called before the first frame update
    void Start()
    {
        terrainTexture = GetComponent<CheckTerrainTexture>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Checker)
        RoadSelected();
    }
    void RoadSelected()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                // Check if hit.transform is door, 
                if (hit.collider.tag == "Road")
                {
                    var pointOfContact = hit.point;
                    terrainTexture.ConvertPosition(pointOfContact);
                    RoadName = hit.collider.name;
                    terrainTexture.GetTerrainTexture();
                    Debug.Log(RoadName + " hit point: " + pointOfContact);
                }


            }
        }
    }
    public void RoadCheckerActive()
    {
        Checker = true;
    }
}
