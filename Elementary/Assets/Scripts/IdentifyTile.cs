using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifyTile : MonoBehaviour
{
    bool ready;
    public string color = "grey";
    public string direction = "none";

    string below = "grey";
    string north = "grey"; 
    string east = "grey";
    string south = "grey";
    string west = "grey";


    string setcolor = "nocolor";

    CreateTerrain script1;
    public GameObject map;
    MapSystem scriptM;
    public GameObject pickupmap;
    PickupSystem scriptP;

    // Start is called before the first frame update
    void Start()
    {
        ready = false;
        scriptM = (MapSystem)map.GetComponent(typeof(MapSystem));

        scriptP = (PickupSystem)pickupmap.GetComponent(typeof(PickupSystem));

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
    public string AskColor(string direction)
    {
        if(direction == "north")
        {
            return north;
        }else if (direction == "east")
        {
            return east;
        }
        else if(direction == "south")
        {
            return south;
        }
        else if(direction == "west")
        {
            return west;
        }
        else
        {
            return below;
        }
            
    }


    public bool CanMove(float x, float y)
    {
        string temp = scriptM.FindTile(transform.position.x, transform.position.z, transform.position.y - 1.0f);
        if (temp == "none")
        {
            //Debug.Log("failed");
            return false;
        }
        string i = "north";
        if (x > 0)
        {
            Debug.Log("E");
            i = "east";
        }else if(x < 0)
        {
            Debug.Log("W");
            i = "west";

        }
        if(y > 0)
        {
            Debug.Log("N");
            i = "north";

        }else if(y < 0)
        {
            Debug.Log("S");
            i = "south";
        }
        

        return scriptM.CanMove(transform.position.x, transform.position.z, transform.position.y, i); ;
    }

    //get the tile color below before it changes from being landed on
    public void GetTile()
    {
        string temp = scriptM.FindTile(transform.position.x, transform.position.z, transform.position.y - 1.0f);
        if(temp != "none")
        {
            below = temp;
        }

        temp = scriptM.FindTile(transform.position.x, transform.position.z + 1.0f, transform.position.y);
        if (temp != "none")
        {
            north = temp;
        }
        temp = scriptM.FindTile(transform.position.x + 1.0f, transform.position.z, transform.position.y);
        if (temp != "none")
        {
            east = temp;
        }
        temp = scriptM.FindTile(transform.position.x, transform.position.z - 1.0f, transform.position.y);
        if (temp != "none")
        {
            south = temp;
        }
        temp = scriptM.FindTile(transform.position.x - 1.0f, transform.position.z, transform.position.y);
        if (temp != "none")
        {
            west = temp;
        }



        setcolor = scriptP.CheckColor(transform.position.x, transform.position.z);

        //Debug.Log(below);
    }


    public void PassColor(string color, string colorN, string colorE, string colorS, string colorW)
    {
        scriptM.SetTile(transform.position.x, transform.position.z, transform.position.y - 1.0f, color, "down");
        scriptM.SetTile(transform.position.x, transform.position.z + 1.0f, transform.position.y, colorN, "north");
        scriptM.SetTile(transform.position.x + 1.0f, transform.position.z, transform.position.y, colorE, "east");
        scriptM.SetTile(transform.position.x, transform.position.z - 1.0f, transform.position.y, colorS, "south");
        scriptM.SetTile(transform.position.x - 1.0f, transform.position.z, transform.position.y, colorW, "west");
    }

    public bool NewColor()
    {
        if (setcolor == "nocolor")
        {
                return false;
            
        }
        
        return true;
    }

    public string GetColor()
    {
        
        
        
        string temp = setcolor;
        setcolor = "nocolor";
        return temp;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
