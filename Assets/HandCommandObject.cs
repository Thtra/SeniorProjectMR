using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCommandObject : MonoBehaviour
{



    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }
    public void  MoveObject()
    {
        Vector3 positionvaluesright = Tracking_Capture.positionvaluesright;
        Quaternion rotationvaluesright = Tracking_Capture.rotationvaluesright;

        PolyImport.transform.position = positionvaluesright;
        PolyImport.transform.rotation = rotationvaluesright;
    }

    public void StopObject()
    {

        PolyImport.transform.position = PolyImport.transform.position;
        PolyImport.transform.position = PolyImport.transform.position;

    }
}
