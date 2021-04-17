/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandGrabber : OVRGrabber
{
    [SerializeField]
    bool grabbing = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public void DetectGrab(string stringgrabbing)
    {
        if (stringgrabbing.Equals(true))
        {
            grabbing = true;
            Debug.Log(grabbing);
        }
        else if (stringgrabbing.Equals(false))
        {
            grabbing = false;
        }
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(!m_grabbedObj && m_grabCandidates.Count > 0 && grabbing)
        {
            GrabBegin();
        }
        else
        {
            GrabEnd();
            Release();
        }
    }

    public void Release()
    {
        m_lastPos = transform.position;
        m_lastRot = transform.rotation;
    }

}
*/
﻿using System.Collections;
using UnityEngine;

public class VRHandGrabber : OVRGrabber
{
    // Boolean used to check if is Grabbing or not.
    [SerializeField]
    bool isGrabbing = false;
    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }
    protected override void Start()
    {
        // We begin by initialize the base.Start function where are set few variable from OVRGrabber like:
        // m_lastPos, m_last_Rot and the m_parentTransform.
        base.Start();
    }

    // Function used as a switch to determinate if we are grabbing or not by passing as argument
    // the string "true" in the gesture when detected and "false" when is not recognize
    public void DetectGrabbing(string _isGrabbing)
    {
        // if "_isGrabbing" is true, we set isGrabbing to true
        if (_isGrabbing.Equals("true"))
        {
            isGrabbing = true;
        }
        // else if "_isGrabbing" is false, we set isGrabbing to false
        else if (_isGrabbing.Equals("false"))
        {
            isGrabbing = false;
        }
    }

    public override void Update()
    {
        // we call the base.Update to make sure that OVRGrabber update some values
        base.Update();
        // if we are not grabbin anything and we have a candidate able to be grabbed
        // and isGrabbing (found by the gesture detector on this case) is true
        Debug.Log(m_grabCandidates.Count);
        if (isGrabbing && !m_grabbedObj && m_grabCandidates.Count > 0)
        {
            // we call the GrabBegin the object
            GrabBegin();
            Debug.Log("Grab Began");
        }
        // else if there is an object that we are grabbing and the isGrabbing is false
        else if (!isGrabbing)
        {
            // we call the override GrabEnd
            Debug.Log("Not Grabbing");
            GrabEnd();
        }
        else
        {
            Debug.Log("Nothing to grab!");
        }
    }

    // To call in the gestures for refrech the position and rotation when releasing
    public void EndGrab()
    {
        GrabEnd();
    }

    public void TeleObject()
    {
        Vector3 positionvaluesright = Tracking_Capture.positionvaluesright;
        Quaternion rotationvaluesright = Tracking_Capture.rotationvaluesright;

        PolyImport.transform.position = positionvaluesright;
        PolyImport.transform.rotation = rotationvaluesright;
    }
   
}
