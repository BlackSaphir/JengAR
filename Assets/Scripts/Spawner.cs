using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UnityEngine.XR.iOS
{
    public class Spawner : MonoBehaviour
    {
        public GameObject JengaCube;

        public Vector3 Intialize;

        public Vector3 Intialize_Turnaround;

        private float Delta;

        bool turnaround;

        public static GameObject Temp_JengaCube;

        public static List<GameObject> Jenga_List = new List<GameObject>();


        private void Start()
        {
            Delta = JengaCube.transform.localScale.x * 2.55f;
            Temp_JengaCube = JengaCube;
            Build();
        }

        public void Build()
        {
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
                    }
                    else
                    {
                        GameObject temp = Instantiate(JengaCube);
                        Jenga_List.Add(temp);
                        temp.transform.position = Intialize_Turnaround + Vector3.forward * i * Delta;
                        temp.transform.rotation = Quaternion.Euler(0, 90, 0);
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

                Intialize.y += 1.5f * JengaCube.transform.localScale.y;
                Intialize_Turnaround.y += 1.5f * JengaCube.transform.localScale.y;
            }


            //for (int i = 0; i < Jenga_List.Count; i++)
            //{
            //    Jenga_List[i].AddComponent<Rigidbody>();
            //    Jenga_List[i].GetComponent<Rigidbody>().mass = 5;
            //}

        }
    }

}
