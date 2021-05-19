using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTracker : MonoBehaviour
{

    private Color yColor = new Color(0.914f, 0.788f, 0.263f);
    private Color rColor = new Color(0.871f, 0.376f, 0.141f);
    private Color bColor = new Color(0.275f, 0.451f, 0.773f);
    private Color gColor = new Color(0.545f, 0.545f, 0.545f);
    private Color grColor = new Color(0.016f, 0.612f, 0.346f);
    private Color cColor = new Color(0.604f, 0.914f, 0.961f);


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public Color GetColor(string name)
    {
        if (name == "yellow")
        {
            return yColor;
        }

        else if (name == "blue")
        {
            return bColor;
        }

        else if (name == "red")
        {
            return rColor;
        }

        else if (name == "cyan")
        {
            return cColor;
        }

        else if (name == "green")
        {
            return grColor;
        }

        else
        {
            return gColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
