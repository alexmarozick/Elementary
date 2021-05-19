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

    //get the tile color below before it changes from being landed on
    public void GetTile()
    {
        string temp = scriptM.FindTile(transform.position.x, transform.position.z);
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
