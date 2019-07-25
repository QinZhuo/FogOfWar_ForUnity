using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FogOfWar
{
    public class InitMapByPhysics : MonoBehaviour
    {
        public FowManager fowManager;
        int[,] mapData;
        void Start()
        {
            PhysicsCheck();
        }
        public void PhysicsCheck()
        {
            mapData = new int[(int)(fowManager.FogSizeX / fowManager.MapTileSize), (int)(fowManager.FogSizeY / fowManager.MapTileSize)];
            for (int i = 0; i < mapData.GetLength(0); i++)
            {
                for (int j = 0; j < mapData.GetLength(1); j++)
                {
                    if (Physics.CheckBox(fowManager.GetV3(new int[] { i, j }), new Vector3(fowManager.MapTileSize - 0.02f, 0f, fowManager.MapTileSize - 0.02f)/2))
                    {
                        mapData[i, j] = 1;
                    }
                    else
                    {
                        mapData[i, j] = 0;
                    }
                }
            }
            fowManager.InitMap(mapData);
        }
    }

}
