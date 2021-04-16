using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
[System.Serializable]
public struct Gesture
{
    public string GestureName;
    public List<Vector3> fingerData;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    public float threshold = 0.5f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerbones = null;
    private bool Started = false;
    private bool hasRecognized = false;
    private bool done = false;
    public UnityEvent notRecognized;

    void Start()
    {
        StartCoroutine(DelayRoutine(3.0f, Start));
        SetSkeleton();
        Started = true;
    }

    public IEnumerator DelayRoutine(float delay, Action Starto)
    {
        yield return new WaitForSeconds(delay);
        Starto.Invoke();
    }
    public void SetSkeleton()
    {
        fingerbones = new List<OVRBone>(skeleton.Bones);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        if (Started.Equals(true) && OVRPlugin.GetHandTrackingEnabled())
        {
            Gesture currentGesture = Recognize();
            hasRecognized = !currentGesture.Equals(new Gesture());
                if (hasRecognized)
            {
                done = true;
                Debug.Log("Gesture: " + currentGesture.GestureName);
                currentGesture.onRecognized?.Invoke();
            }
            else
            {
                if (done)
                {
                    done = false;
                    notRecognized?.Invoke();
                }
            }
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerbones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerData = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;
        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerbones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);
                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }
            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }
        return currentGesture;
    }
}
