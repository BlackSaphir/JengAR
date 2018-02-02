using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.iOS
{
    public class Plane_Generator : MonoBehaviour
    {

        public GameObject planePrefab;
        //public GameObject Spawner;
        private UnityARAnchorManager unityARAnchorManager;

        // Use this for initialization
        void Start()
        {
            unityARAnchorManager = new UnityARAnchorManager();
            UnityARUtility.InitializePlanePrefab(planePrefab);
        }

        void Update()
        {
            //if (UnityARUtility.planePrefab != null && Spawner == null)
            //{
            //    Instantiate(Spawner, new Vector3(planePrefab.transform.position.x / 2, planePrefab.transform.position.y, planePrefab.transform.position.z / 2), planePrefab.transform.rotation);
            //}
            //else if (UnityARUtility.planePrefab == null && Spawner != null)
            //{
            //    Destroy(Spawner);
            //}

            //if (Spawner != null)
            //{
            //    Spawner.transform.position = new Vector3(planePrefab.transform.position.x / 2, planePrefab.transform.position.y, planePrefab.transform.position.z / 2);
            //    Spawner.transform.rotation = Quaternion.Euler(planePrefab.transform.rotation.x, planePrefab.transform.rotation.y, planePrefab.transform.rotation.z);
            //}
        }

        public static void Generate_Tower()
        {

        }

        void OnDestroy()
        {
            unityARAnchorManager.Destroy();
        }

        void OnGUI()
        {
            List<ARPlaneAnchorGameObject> arpags = unityARAnchorManager.GetCurrentPlaneAnchors();
            if (arpags.Count >= 1)
            {
                //ARPlaneAnchor ap = arpags [0].planeAnchor;
                //GUI.Box (new Rect (100, 100, 800, 60), string.Format ("Center: x:{0}, y:{1}, z:{2}", ap.center.x, ap.center.y, ap.center.z));
                //GUI.Box(new Rect(100, 200, 800, 60), string.Format ("Extent: x:{0}, y:{1}, z:{2}", ap.extent.x, ap.extent.y, ap.extent.z));
            }
        }
    }
}
