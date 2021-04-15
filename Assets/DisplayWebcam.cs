using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayWebcam : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture webCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;
    // Start is called before the first frame update
    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            webCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
        }
        if (webCam == null)
        {
            Debug.Log("Unable to find web cam");
            return;
        }
        webCam.Play();
        background.texture = webCam;

        camAvailable = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (!camAvailable)
            return;

        float ratio = (float)webCam.width / (float)webCam.height;
        fit.aspectRatio = ratio;
        float scaleY = webCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);


        int orient = -webCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
