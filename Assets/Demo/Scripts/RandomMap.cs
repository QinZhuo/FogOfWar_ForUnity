using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FogOfWar;
public class RandomMap : MonoBehaviour {
    public GameObject redCube;
    public int MapSize=20;
	// Use this for initialization
	void Start () {
        Ramdom();

    }
    public void Ramdom()
    {
        
        var mapData = new int[MapSize, MapSize];
        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                mapData[i, j] = Random.Range(0, 100) < 2 ? 1 : 0;
                 
            }
        }
        for (int t = 0; t < 2; t++)
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (mapData[i, j] == 0)
                    {
                        if (FOWTool.InMap(i + 1, j, MapSize, MapSize) && mapData[i + 1, j] == 1)
                        {
                            mapData[i, j] = Random.Range(0, 100) < 60 ? 1 : 0;
                        }
                        else if (FOWTool.InMap(i, j + 1, MapSize, MapSize) && mapData[i, j + 1] == 1)
                        {
                            mapData[i, j] = Random.Range(0, 100) < 60 ? 1 : 0;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                if (mapData[i, j] == 1)
                {
                    Instantiate(redCube, new Vector3(i-10, 0, j-10)+Vector3.one/2, Quaternion.identity);
                }

            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
