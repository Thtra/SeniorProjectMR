using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayWebCamSimple : MonoBehaviour
{
    static WebCamTexture webCam;

    public GameObject cam;
    public GameObject ctrlL;
    public GameObject ctrlR;
    public GameObject crosshair;
    public GameObject OVR;

    int state = 0;
    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }
    void Start()
    {
        if (webCam == null)
            webCam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = webCam;

        if (!webCam.isPlaying)
            webCam.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {

            if (state == 0)
            {
                cam.transform.position = ctrlR.transform.position;
                state = 1;
                crosshair.SetActive(true);
            }
            else if (state==1)
            {
                cam.transform.LookAt(ctrlR.transform.position);
                state = 0;
                crosshair.SetActive(false);
            }
        }

    }

    
}
