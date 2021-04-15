using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking_Capture : MonoBehaviour
{
	public GameObject right_controller;
    public static Vector3 positionvaluesright;
    public static Quaternion rotationvaluesright;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionvaluesright = right_controller.transform.position;
        rotationvaluesright = right_controller.transform.rotation;
 //              Debug.Log("Right hand position: " + right_controller.transform.position);

    }
}
