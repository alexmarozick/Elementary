using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifyTile : MonoBehaviour
{


    bool ready;
    public string color = "grey";
    public string direction = "none";

    string below = "grey";

    CreateTerrain script1;
    public GameObject map;
    MapSystem scriptM;

    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        scriptM = (MapSystem)map.GetComponent(typeof(MapSystem));
    }

    public void Unlock()
    {
        ready = true;
    }

    public void Lock()
    {
        ready = false;
    }


    //return color
    public string AskColor()
    {
        
        return below;
    }


    public bool CanMove(float x, float y)
    {
        string temp = scriptM.FindTile(transform.position.x, transform.position.z, transform.position.y);
        if (temp == "none")
        {
            return false;
        }
        string i = "north";
        if (x > 0)
        {
            //Debug.Log("E");
            i = "east";
        }else if(x < 0)
        {
            //Debug.Log("W");
            i = "west";

        }
        if(y > 0)
        {
            //Debug.Log("N");
            i = "north";

        }else if(y < 0)
        {
            //Debug.Log("S");
            i = "south";
        }
        

        return scriptM.CanMove(transform.position.x, transform.position.z, transform.position.y, i); ;
    }

    //get the tile color below before it changes from being landed on
    public void GetTile()
    {
        string temp = scriptM.FindTile(transform.position.x, transform.position.z, transform.position.y);
        if(temp != "none")
        {
            below = temp;
        }
        //Debug.Log(below);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
