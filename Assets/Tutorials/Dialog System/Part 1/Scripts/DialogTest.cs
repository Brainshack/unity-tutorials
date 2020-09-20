using System;
using UnityEngine;

namespace Tutorials.Dialog_System.Part_1.Scripts
{
    public class DialogTest : MonoBehaviour
    {

        public GameObject dialogGo;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                dialogGo.SetActive(true);
        }
    }
}