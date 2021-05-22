using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public string color = "yellow";

    public GameObject tracker;
    private ColorTracker basecolor;

    private ParticleSystem r;
    

    // Start is called before the first frame update
    void Start()
    {
        if (tracker != null)
        {
            basecolor = (ColorTracker)tracker.GetComponent(typeof(ColorTracker));
        }

        Recolor(color);
    }

    public void Recolor(string co)
    {
        r = GetComponent<ParticleSystem>();

        var ps = r.main;
        color = co;

        ps.startColor = basecolor.GetColor(color);
        
    }


    public bool Match(float x, float z)
    {
        if((transform.position.x == x) && (transform.position.z == z))
        {
            return true;
        }
        return false;
    }

    public string AskColor()
    {
        return color;
    }
}
