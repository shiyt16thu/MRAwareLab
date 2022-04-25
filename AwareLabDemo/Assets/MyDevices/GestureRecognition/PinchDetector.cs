using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinchDetector : MonoBehaviour
{
    [Tooltip("Event that runs when we recognize a gesture")]
    public UnityEvent OnMiddlePinchRecognized;
    public UnityEvent OnRingPinchRecognized;

    [SerializeField]
    [Tooltip("Is this gesture recognizer active right now?")]
    private bool shouldRecognize = true;

    [Tooltip("Minimum required wait time before firing another recogintion event")]
    public float timeBetweenRecognition = 5f;

    [Tooltip("Enabling this will only trigger recognition when we are certain we can see hands")]
    public bool waitForHighConfidenceData = true;

    public OVRSkeleton skeleton;

    private OVRHand hand;
    private float lastRecognition;

    // Start is called before the first frame update
    void Start()
    {
        lastRecognition = timeBetweenRecognition;
        Debug.Log("pinchdetector started.");

        if (skeleton == null)
        {
            Debug.Log("no skeleton");
            skeleton = GetComponent<OVRSkeleton>();
        }
        hand = skeleton.gameObject.GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        lastRecognition += Time.deltaTime;
        if (lastRecognition < timeBetweenRecognition) return;

        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Debug.Log("Recognized Pinch");
            OnMiddlePinchRecognized?.Invoke();
            lastRecognition = 0f;
            GameObject __sweeper = GameObject.Find("sweeper");
            sweeperctrl __ctrl = __sweeper.GetComponent<sweeperctrl>();
            if (__ctrl != null)
                __ctrl.powerbutton();
            return;
        }
        else if (hand.GetFingerIsPinching(OVRHand.HandFinger.Ring))
        {
            OnRingPinchRecognized?.Invoke();
            lastRecognition = 0f;
            GameObject __sweeper = GameObject.Find("sweeper");
            sweeperctrl __ctrl = __sweeper.GetComponent<sweeperctrl>();
            if (__ctrl != null)
                __ctrl.runbutton();
            return;
        }
    }
}
