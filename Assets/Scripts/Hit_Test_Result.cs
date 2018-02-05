using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.iOS
{
    public class Hit_Test_Result : MonoBehaviour
    {
        //public Transform m_HitTransform;
        public GameObject Spawner_Object;
        public float maxRayDistance = 30.0f;
        public LayerMask collisionLayer = 1 << 10;  //ARKitPlane layer
        public GameObject temp;
        Vector3 temp_turnaround;


        bool HitTestWithResultType(ARPoint point, ARHitTestResultType resultTypes)
        {
            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(point, resultTypes);

            if (hitResults.Count > 0)
            {
                foreach (var hitResult in hitResults)
                {
                    if (temp != null)
                    {
                        Destroy(temp);
                    }

                    temp = Instantiate(Spawner_Object);

                    temp.GetComponent<Spawner>().Intialize = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                    temp_turnaround = temp.GetComponent<Spawner>().Intialize;

                    temp.GetComponent<Spawner>().Intialize_Turnaround = new Vector3(temp_turnaround.x + (2.5f * Spawner.Temp_JengaCube.transform.localScale.x), temp_turnaround.y, temp_turnaround.z + (-2.5f * Spawner.Temp_JengaCube.transform.localScale.z));
                    //temp.GetComponent<Spawner>().Build();
                    Debug.Log("Got hit!");
                    return true;

                }
            }
            return false;
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_IOS

            if (Input.touchCount > 0)
            {

                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
                    ARPoint point = new ARPoint
                    {
                        x = screenPosition.x,
                        y = screenPosition.y
                    };

                    // prioritize reults types
                    ARHitTestResultType[] resultTypes =
                        {
                        //ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        // if you want to use infinite planes use this:
                        ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                        //ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
                        //ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                        };

                    foreach (ARHitTestResultType resultType in resultTypes)
                    {
                        if (HitTestWithResultType(point, resultType))
                        {
                            return;
                        }
                    }
                }

            }

#endif
        }


    }
}

