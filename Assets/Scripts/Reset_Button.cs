using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityEngine.XR.iOS
{
    public class Reset_Button : MonoBehaviour
    {
        public void Reset()
        {
            for (int i = 0; i < Spawner.Jenga_List.Count; i++)
            {
                Destroy(Spawner.Jenga_List[i].gameObject);
            }
            Spawner.Jenga_List.Clear();
        }

        private void Start()
        {
            Button Resetb = GetComponent<Button>();
            Resetb.onClick.AddListener(() => Reset());
        }

    }
}