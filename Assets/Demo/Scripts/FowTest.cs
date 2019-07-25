using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FogOfWar;
public class FowTest : MonoBehaviour {
    public int[,] mapData;
    public FOWMap map;
    public int mapSize = 20;
    public int[] playerPos;
    
	// Use this for initialization
	void Start () {

     
        mapData = new int[mapSize, mapSize];
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                mapData[i, j] = Random.Range(0, 100)<2?1:0;
            }
        }
        for (int t = 0; t < 2; t++)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (mapData[i, j] == 0)
                    {
                        if (FOWTool.InMap(i + 1, j, mapSize, mapSize) && mapData[i + 1, j] == 1)
                        {
                            mapData[i, j] = Random.Range(0, 100)<60? 1:0;
                        }
                        else if (FOWTool.InMap(i, j + 1, mapSize, mapSize) && mapData[i, j + 1] == 1)
                        {
                            mapData[i, j] = Random.Range(0, 100) < 60 ? 1 : 0;
                        }
                    }
                }
            }
        }
       
        map = new FOWMap();
        map.InitMap(mapData);
        playerPos = new int[] { mapSize/2, mapSize/2 };
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerPos[1] += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerPos[1] -= 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerPos[0] -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerPos[0] += 1;
        }
        map.FreshFog();
        map.ComputeFog(playerPos[0], playerPos[1], 10);
       
    }
    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Gizmos.color = map.GetTile(i, j).type == 0 ? new Color(1,0.5f,1,0.1f) : Color.red;
                    Gizmos.DrawCube(new Vector3(i,  0,j), Vector3.one*0.8f);
                    
                    if(map[i, j].r == 255)
                    {
                      
                    }else if (map[i, j].b == 255)
                    {
                        Gizmos.color = new Color(0, 0, 0, 0.5f);
                        Gizmos.DrawSphere(new Vector3(i, 0, j), 0.7f);
                    }
                    else
                    {
                        Gizmos.color = Color.black;
                        Gizmos.DrawSphere(new Vector3(i, 0, j), 0.7f);
                    }
                   
                   
                }
            }
           
            Gizmos.color = Color.green;

            Gizmos.DrawSphere(new Vector3(playerPos[0], 0, playerPos[1]), 0.5f);
        }
      


    }
    public Texture tex
    {
        get
        {
            return map.FogTexture;
        }
    }
  

}