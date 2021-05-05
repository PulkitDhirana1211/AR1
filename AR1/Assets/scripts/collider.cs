using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class collider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject drawPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ARSession.state == ARSessionState.SessionTracking)
            followPalmCenter();
        Debug.Log("Shivam gupta");
    }
    void followPalmCenter()
    {
        Debug.Log("Shivam");

        HandInfo curentHand = ManomotionManager.Instance.Hand_infos[0].hand_info;
        ManoGestureContinuous gesture = curentHand.gesture_info.mano_gesture_continuous;
        Vector3 palmPosition = curentHand.tracking_info.palm_center;
        if (gesture == ManoGestureContinuous.CLOSED_HAND_GESTURE)
        {
           
            this.transform.position = ManoUtils.Instance.CalculateNewPosition(palmPosition, curentHand.tracking_info.depth_estimation);
        }

    }
}
