
using System.Collections;
using UnityEngine;

public class VRHandGrabber : OVRGrabber
{
    [SerializeField] bool isGrabbing = false;
    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }
    protected override void Start()
    {

        base.Start();
    }

    public void DetectGrabbing(string SGrabbing)
    {
        if (SGrabbing.Equals("true"))
        {
            isGrabbing = true;
        }
        else if (SGrabbing.Equals("false"))
        {
            isGrabbing = false;
        }
    }

    public override void Update()
    {
        base.Update();
 //       Debug.Log(m_grabCandidates.Count);
        if (isGrabbing && !m_grabbedObj && m_grabCandidates.Count > 0)
        {
            GrabBegin();
            Debug.Log("Grab Began");
        }
        else if (!isGrabbing)
        {
            Debug.Log("Not Grabbing");
            GrabEnd();
        }
        else
        {
            Debug.Log("Nothing to grab!");
        }
    }

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
