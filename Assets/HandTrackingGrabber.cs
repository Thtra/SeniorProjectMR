using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandTrackingGrabber : OVRGrabber
{
    /*
    private OVRHandPrefab hand;
    public float pinchThreshold = 0.7f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHandPrefab>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        PinchChecker();
    }
    void PinchChecker()
    {
        float pinchStrength = hand.PinchStrength(OVRPlugin.HandFinger.Index);
        bool isPinching = pinchStrength > pinchThreshold;

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
            GrabBegin();
        else if (m_grabbedObj && !isPinching)
            GrabEnd();
    }
    */
}
