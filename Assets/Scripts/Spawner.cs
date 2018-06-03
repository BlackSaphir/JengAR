using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UnityEngine.XR.iOS
{
    public class Spawner : MonoBehaviour
    {
        public GameObject JengaCube;

        public GameObject Plane;

        public Vector3 Intialize;

        public Vector3 Intialize_Turnaround;

        private float Delta;

        bool turnaround;

        public static GameObject Temp_JengaCube;

        public static List<GameObject> Jenga_List = new List<GameObject>();

        public static GameObject Temp_Plane;


        private void Start()
        {
            Delta = JengaCube.transform.localScale.x * 2.55f;
            Temp_JengaCube = JengaCube;
            Temp_Plane = Plane;
            //Build();
        }

        public void Build()
        {
            //Instantiate(Temp_Plane, new Vector3(Intialize.x, Intialize.y - 0.05f, Intialize.z), Quaternion.identity);
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (turnaround == false)
                    {
                        GameObject temp = Instantiate(JengaCube);
                        Jenga_List.Add(temp);
                        temp.transform.position = Intialize + Vector3.right * i * Delta;
                        temp.transform.rotation = Quaternion.identity;

                        temp.AddComponent<Rigidbody>();
                        temp.GetComponent<Rigidbody>().drag = 0;
                        temp.GetComponent<Rigidbody>().mass = 0.0001f;
                    }
                    else
                    {
                        GameObject temp = Instantiate(JengaCube);
                        Jenga_List.Add(temp);
                        temp.transform.position = Intialize_Turnaround + Vector3.forward * i * Delta;
                        temp.transform.rotation = Quaternion.Euler(0, 90, 0);

                        temp.AddComponent<Rigidbody>();
                        temp.GetComponent<Rigidbody>().drag = 0;
                        temp.GetComponent<Rigidbody>().mass = 0.0001f;
                    }
                    if (i == 2)
                    {
                        if (turnaround == true)
                        {
                            turnaround = false;
                        }
                        else
                        {
                            turnaround = true;
                        }
                    }
                }


                Intialize.y += 1.55f /** JengaCube.transform.localScale.y*/;
                Intialize_Turnaround.y += 1.55f /** JengaCube.transform.localScale.y*/;
            }


            //for (int i = 0; i < Jenga_List.Count; i++)
            //{
            //    Jenga_List[i].AddComponent<Rigidbody>();
            //    Jenga_List[i].GetComponent<Rigidbody>().drag = 4;
            //    Jenga_List[i].GetComponent<Rigidbody>().mass = 0.00000000000000000001f;
            //    //Jenga_List[i].GetComponent<Rigidbody>().mass = 0.1f;
            //}

        }
    }

}
