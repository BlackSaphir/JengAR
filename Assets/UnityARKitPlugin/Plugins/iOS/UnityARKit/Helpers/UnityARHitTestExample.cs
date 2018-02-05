using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.iOS
{
    public class UnityARHitTestExample : MonoBehaviour
    {
        //public Transform m_HitTransform;
        public GameObject Spawner;
        public float maxRayDistance = 30.0f;
        public LayerMask collisionLayer = 1 << 10;  //ARKitPlane layer
        public GameObject temp;
        Vector3 Penis_Mofo;


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

                    temp = Instantiate(Spawner);

                    temp.GetComponent<Spawner>().Intialize = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                    Penis_Mofo = temp.GetComponent<Spawner>().Intialize;

                    temp.GetComponent<Spawner>().Intialize_Turnaround = new Vector3(Penis_Mofo.x + 0.25f, Penis_Mofo.y, Penis_Mofo.z - 0.25f);
                    temp.GetComponent<Spawner>().Build();

                    Debug.Log("Got hit!");
                    //m_HitTransform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                    //m_HitTransform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
                    //temp.transform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
                    //temp.transform.position = m_HitTransform.position;
                    //temp.transform.rotation = m_HitTransform.rotation;
                    //temp.transform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                    //Debug.Log(string.Format("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
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
                if (!EventSystem.current.IsPointerOverGameObject())
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
            }
#endif
        }


    }
}

