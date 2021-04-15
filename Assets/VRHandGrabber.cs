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
