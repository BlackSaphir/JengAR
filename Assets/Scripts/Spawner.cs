using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Cube;

    public Vector3 Intialize;

    public Vector3 Intialize_Turnaround;

    public float Delta;

    bool turnaround;

    // Use this for initialization
    void Start()
    {


        for (int j = 0; j < 20; j++)
        {

            for (int i = 0; i < 3; i++)
            {
                if (turnaround == false)
                {
                    GameObject temp = Instantiate(Cube);
                    temp.transform.position = Intialize + Vector3.right * i * Delta;
                    temp.transform.rotation = Quaternion.identity;
                }
                else
                {
                    GameObject temp = Instantiate(Cube);
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

            Intialize.y += 1.5f;
            Intialize_Turnaround.y += 1.5f;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
