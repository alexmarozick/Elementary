using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MapSystem : MonoBehaviour
{

    TerrainSystem[] mapspace;
    int[][] connected;
    bool[] connects;
    int count;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.childCount);
        count = transform.childCount;
        mapspace = new TerrainSystem[count];
        connected = new int[count][];
        connects = new bool[count];

        for(int i = 0; i < count; i++)
        {
            connects[i] = true;
            connected[i] = new int[4];
            for(int k = 0; k < 4; k++)
            {
                //NESW
                connected[i][k] = -1;
            }
            
            GameObject ci = this.gameObject.transform.GetChild(i).gameObject;
            mapspace[i] = (TerrainSystem)ci.GetComponent(typeof(TerrainSystem));
        }

        TilePaths();
    }

    //find all possible connections between tiles
    private void TilePaths() {
        for (int j = 0; j < count; j++)
        {
            if (mapspace[j] != null)
            {
                float x2 = mapspace[j].GetX();
                float z2 = mapspace[j].GetZ();
                float y2 = mapspace[j].GetY();

                int t;
                //NESW
                t = Find(x2, z2 + 1.0f, y2);
                if(t >= 0)
                {
                    connected[j][0] = t;
                }
                t = Find(x2 + 1.0f, z2, y2);
                if (t >= 0)
                {
                    connected[j][1] = t;
                }
                t = Find(x2, z2 - 1.0f, y2);
                if (t >= 0)
                {
                    connected[j][2] = t;
                }
                t = Find(x2 - 1.0f, z2, y2);
                if (t >= 0)
                {
                    connected[j][3] = t;
                }
            }
        }

    }

    //player use this to check if they can move in that direction
    public bool CanMove(float x, float z, float y, string direction)
    {
        int t = Find(x, z, y - 1.0f);
        if (direction == "north")
        {
            if(connected[t][0] >= 0)
            {
                return connects[connected[t][0]];
            }
            
        }
        else if (direction == "east")
        {
            if (connected[t][1] >= 0)
            {
                return connects[connected[t][1]];
            }
        }
        else if (direction == "south")
        {
            if (connected[t][2] >= 0)
            {
                return connects[connected[t][2]];
            }
        }
        else if (direction == "west")
        {
            if (connected[t][3] >= 0)
            {
                return connects[connected[t][3]];
            }
        }
        return true;
    }

    //for puzzlegates to remove locations
    void StrikeOut(float x, float z, float y)
    {
        int t = Find(x, z, y);
        if(t >= 0)
        {
            connects[t] = false;
        }
        
    }

     //internal method for finding the right tile
    int Find(float x, float z, float y)
    {
        for (int j = 0; j < count; j++)
        {
            if (mapspace[j] != null)
            {
                if (mapspace[j].Match(x, z, y))
                {
                    return j;
                }

            }
        }
        return -1;
    }


    //determine the color of the tile beneath the player
    public string FindTile(float x, float z, float y)
    {
        int t = Find(x, z, y - 1.0f);

        
        
         
        if(t < 0)
        {
            return "none";
        }
        else
        {
            /*int zz = 0;
            for (int j = 0; j < 4; j++)
            {
                if (connected[t][j] >= 0)
                {
                    zz += 1;
                }
                
            }
            Debug.Log(zz);*/
            return mapspace[t].GetColor();
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
