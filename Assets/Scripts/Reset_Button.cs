using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityEngine.XR.iOS
{
    public class Reset_Button : MonoBehaviour
    {
        public GameObject Spawner_Object;
        public GameObject temp;
        Vector3 temp_turnaround;

        public void Reset()
        {
            for (int i = 0; i < Spawner.Jenga_List.Count; i++)
            {
                Destroy(Spawner.Jenga_List[i].gameObject);
            }
            Spawner.Jenga_List.Clear();
            Destroy(Spawner.Temp_Plane.gameObject);

            temp.GetComponent<Spawner>().Build();
           
        }

        private void Start()
        {
            temp = Instantiate(Spawner_Object);

            temp.GetComponent<Spawner>().Intialize = new Vector3(temp.transform.position.x, temp.transform.position.y, temp.transform.position.z);
            temp_turnaround = temp.GetComponent<Spawner>().Intialize;

            temp.GetComponent<Spawner>().Intialize_Turnaround = new Vector3(temp_turnaround.x + 2.55f/*0.125f*/, temp_turnaround.y, temp_turnaround.z - 2.55f/*0.125f*/);


            Button Resetb = GetComponent<Button>();
            Resetb.onClick.AddListener(() => Reset());
        }

    }
}