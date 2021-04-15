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
    private bool hasStarted = false;
    private bool hasRecognize = false;
    private bool done = false;

    public UnityEvent notRecognize;

    void Start()
    {
        StartCoroutine(DelayRoutine(2.5f, Initialize));
    }

    public IEnumerator DelayRoutine(float delay, Action actionToDo)
    {
        yield return new WaitForSeconds(delay);
        actionToDo.Invoke();
    }

    public void Initialize()
    {
        SetSkeleton();
        hasStarted = true;
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

        if (hasStarted.Equals(true))
        {
            Gesture currentGesture = Recognize();
            hasRecognize = !currentGesture.Equals(new Gesture());
            if (hasRecognize)
            {
                done = true;
                Debug.Log("New Gesture Found : " + currentGesture.GestureName);
                currentGesture.onRecognized?.Invoke();
            }
            else
            {
                if (done)
                {
                    done = false;
                    notRecognize?.Invoke();
                }
            }
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        g.GestureName = "New Gesture";
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
