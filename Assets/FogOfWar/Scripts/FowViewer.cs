using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FogOfWar
{
    public class FowViewer : MonoBehaviour
    {
        public int viewerRange = 7;
        // Use this for initialization
        void Start()
        {
            FowManager.AddViewer(this);
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnDestroy()
        {
            FowManager.RemoveViewer(this);
        }
    }
}
