using System;
using UnityEngine;

namespace Part2
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