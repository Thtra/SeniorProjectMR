using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatedObject : MonoBehaviour

{
    //   public GameObject manipulatedObject;
    // Start is called before the first frame update

    void Start()
    {
        PolyImport.GetComponent<SphereCollider>().radius = 0.1f;
        var word = PolyImport.GetComponent<SphereCollider>();
        Collider[] newGrabPoints = new Collider[1];
        newGrabPoints[0] = word;
        OVRGrabbable grab = gameObject.AddComponent<OVRGrabbable>();
        OVRGrabbable myInstance = PolyImport.GetComponent<OVRGrabbable>();

        myInstance.CustomGrabCollider(word);
    }
    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 positionvaluesright = Tracking_Capture.positionvaluesright;
        Quaternion rotationvaluesright = Tracking_Capture.rotationvaluesright;

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) == true)
        {
            PolyImport.transform.position = positionvaluesright;
            PolyImport.transform.rotation = rotationvaluesright;
        }
        PolyImport.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PolyImport.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
