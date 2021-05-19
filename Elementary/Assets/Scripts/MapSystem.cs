using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MapSystem : MonoBehaviour
{

    TerrainSystem[] mapspace;
    int count;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.childCount);
        count = transform.childCount;
        mapspace = new TerrainSystem[count];
        for(int i = 0; i < count; i++)
        {
            GameObject ci = this.gameObject.transform.GetChild(i).gameObject;
            mapspace[i] = (TerrainSystem)ci.GetComponent(typeof(TerrainSystem));
        }
    }


    int Find(float x, float z)
    {
        for (int j = 0; j < count; j++)
        {
            if (mapspace[j] != null)
            {
                if (mapspace[j].Match(x, z))
                {
                    return j;
                }

            }
        }
        return -1;
    }


    //determine if the cube is on the same location as the tile
    public string FindTile(float x, float z)
    {
         int t = Find(x, z);

         if(t < 0)
        {
            return "none";
        }
        else
        {
            return mapspace[t].GetColor();
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
