using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingEnabler : MonoBehaviour
{

    public GameObject HUD;
    public bool smthn;
    public GameObject ovrHandPrefabLeft;
    public GameObject ovrHandPrefabRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRPlugin.GetHandTrackingEnabled())
        {
            ovrHandPrefabLeft.SetActive(true);
            ovrHandPrefabRight.SetActive(true);
            HUD.SetActive(true);
        }
        else
        {
            ovrHandPrefabLeft.SetActive(false);
            ovrHandPrefabRight.SetActive(false);
            HUD.SetActive(false);
        }
    }
}
