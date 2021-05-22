using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{

    ChangeColor[] colors;
    int count;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        count = transform.childCount;
        colors = new ChangeColor[count];

        for (int i = 0; i < count; i++)
        {

            GameObject ci = this.gameObject.transform.GetChild(i).gameObject;
            colors[i] = (ChangeColor)ci.GetComponent(typeof(ChangeColor));
        }
    }

    public string CheckColor(float x, float z)
    {
        for (int i = 0; i < count; i++)
        {
            if (colors[i].Match(x, z))
            {
                return colors[i].AskColor();
            }
        }
        
        return "nocolor";
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
