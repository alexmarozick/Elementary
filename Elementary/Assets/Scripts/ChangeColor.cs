using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public string color = "yellow";

    public GameObject tracker;
    private ColorTracker basecolor;

    private ParticleSystem r;
    private Color yColor = new Color(0.914f, 0.788f, 0.263f);
    private Color rColor = new Color(0.871f, 0.376f, 0.141f);
    private Color bColor = new Color(0.275f, 0.451f, 0.773f);
    private Color gColor = new Color(0.016f, 0.612f, 0.346f);
    private Color cColor = new Color(0.604f, 0.914f, 0.961f);

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
}
