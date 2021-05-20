using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSystem : MonoBehaviour
{

    PuzzleGate[] locks;
    int count;
    public GameObject Map;
    MapSystem ScriptM;
    bool once = true;

    // Start is called before the first frame update
    
    
    void Start()
    {

        ScriptM = (MapSystem)Map.GetComponent(typeof(MapSystem));
        count = transform.childCount;
        locks = new PuzzleGate[count];

        for (int i = 0; i < count; i++)
        {
            
            GameObject ci = this.gameObject.transform.GetChild(i).gameObject;
            //locks[i] = (PuzzleGate)ci.GetComponent(typeof(PuzzleGate));
        }
        
    }


    void StrikeOut()
    {
        for(int i = 0; i < count; i++)
        {
            //ScriptM.StrikeOut(locks[i].GetX, locks[i].GetZ, locks[i].GetY - 1.0f)
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (once)
        {
            once = false;
            StrikeOut();
        }
    }
}
