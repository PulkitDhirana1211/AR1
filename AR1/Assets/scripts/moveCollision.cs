using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCollision : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    Color lastColor;


    void OnTriggerEnter(Collider c )
    {
        if (c.gameObject.tag.Equals("hand")) 
        lastColor = gameObject.GetComponent<Renderer>().material.color;

        // trigCol.gameObject.GetComponent<Renderer>().material.color = Color.green;

    }

    void OnTriggerStay(Collider trigCol)
    {
        if (trigCol.gameObject.tag.Equals("hand"))
        {
            HandInfo myTrackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info;

            ManoGestureContinuous myGestureInfo = myTrackingInfo.gesture_info.mano_gesture_continuous;

            grabMove(myTrackingInfo, myGestureInfo, trigCol);
        }

    }

    void OnTriggerExit(Collider trigCol)
    {
        if (trigCol.gameObject.tag.Equals("hand")) 
        gameObject.GetComponent<Renderer>().material.color = lastColor;
        // trigCol.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

    }

    void grabMove(HandInfo trackingInfo, ManoGestureContinuous gesture_info, Collider trigCol)
    {
        // checked if we have a closed hand
        if (gesture_info ==ManoGestureContinuous.CLOSED_HAND_GESTURE)
        {

            //Change the color of the object being held to green
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;

            // Get the position of the centre of hand
            Vector3 normalizedPalmCentre = trackingInfo.tracking_info.palm_center;
            float depth = trackingInfo.tracking_info.depth_estimation;
            Vector3 relativePalmCentrePosition = ManoUtils.Instance.CalculateNewPosition(normalizedPalmCentre, depth);

            //Move the object with hand
            float smoothingVariable = 0.85f;
            gameObject.transform.position = trigCol.gameObject.transform.position;



        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;

        }



    }
}
