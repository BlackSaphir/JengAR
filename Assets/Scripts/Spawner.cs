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

        public float Delta;

        bool turnaround;



        public void Build()
        {

            for (int j = 0; j < 20; j++)
            {

                for (int i = 0; i < 3; i++)
                {
                    if (turnaround == false)
                    {
                        GameObject temp = Instantiate(JengaCube);
                        temp.transform.position = Intialize + Vector3.right * i * Delta;
                        temp.transform.rotation = Quaternion.identity;
                        temp.AddComponent<Rigidbody>();
                    }
                    else
                    {
                        GameObject temp = Instantiate(JengaCube);
                        temp.transform.position = Intialize_Turnaround + Vector3.forward * i * Delta;
                        temp.transform.rotation = Quaternion.Euler(0, 90, 0);
                        temp.AddComponent<Rigidbody>();

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

                Intialize.y += .15f;
                Intialize_Turnaround.y += .15f;
            }
        }
    }
}
