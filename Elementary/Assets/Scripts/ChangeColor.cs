using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public string color = "yellow";

    private ParticleSystem r;
    private Color yColor = new Color(0.914f, 0.788f, 0.263f);
    private Color rColor = new Color(0.871f, 0.376f, 0.141f);
    private Color bColor = new Color(0.275f, 0.451f, 0.773f);
    private Color grColor = new Color(0.016f, 0.612f, 0.346f);
    private Color cColor = new Color(0.604f, 0.914f, 0.961f);

    // Start is called before the first frame update
    void Start()
    {
        Recolor(color);
    }

    public void Recolor(string co)
    {
        r = GetComponent<ParticleSystem>();

        var ps = r.main;
        color = co;

        if (color == "yellow")
        {
            ps.startColor = yColor;
        }

        else if (color == "blue")
        {
            ps.startColor = bColor;
        }

        else if (color == "red")
        {
            ps.startColor = rColor;
        }

        else if (color == "cyan")
        {
            ps.startColor = cColor;
        }

        else if (color == "green")
        {
            ps.startColor = grColor;
        }
    }
}
