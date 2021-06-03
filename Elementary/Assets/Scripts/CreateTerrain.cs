using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class CreateTerrain : MonoBehaviour
{
    public Transform player;
    public GameObject terrain;
    public ResultScreen gameover;
    public Vector3 TerrainOffset;
    public Vector3 TerrainSize;
    bool connected, shift;
    public string color = "grey";
    public string direction = "none";

    string shiftto = "grey";

    CreateFace script1;

    private Color yColor = new Color(0.914f, 0.788f, 0.263f);
    private Color rColor = new Color(0.871f, 0.376f, 0.141f);
    private Color bColor = new Color(0.275f, 0.451f, 0.773f);
    private Color gColor = new Color(0.545f, 0.545f, 0.545f);
    private Color grColor = new Color(0.016f, 0.612f, 0.346f);
    private Color cColor = new Color(0.604f, 0.914f, 0.961f);

    public GameObject tracker;
    private ColorTracker basecolor;

    void Start()
    {
        shift = false;

        if (tracker != null)
        {
            basecolor = (ColorTracker)tracker.GetComponent(typeof(ColorTracker));
        }

        Create(color);
    }

    public void Create(string co)
    {
        color = co;
        shiftto = color;

        float size = 1f;

        Vector3[] vertices = {
            new Vector3(0, 0, size),
            new Vector3(0, 0, 0),
            new Vector3(size, 0, size),
            new Vector3(size, 0, 0),
        };

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].Scale(TerrainSize);
            vertices[i] += TerrainOffset;
        }

        int[] triangles = {
            0, 2, 1, // front
			1, 2, 3,
        };

        Vector2[] uvs = new Vector2[] {
                new Vector2(0, 0.50f),
                new Vector2(0.25f, 0.50f),
                new Vector2(0, 0.25f),
                new Vector2(0.25f, 0.25f)
        };

        //Vector2[] uvs = Recolor(color);

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        MeshRenderer r = GetComponent<MeshRenderer>();

        r.material.color = basecolor.GetColor(color);

        //mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    public string GetColor()
    {
        //Debug.Log("where");
        return color;
    }

    //Method to change tile color
    public void SetColor(string co)
    {
        MeshRenderer r = GetComponent<MeshRenderer>();

        color = co;

        if (color == "yellow")
        {
            r.material.color = yColor;
        }

        else if (color == "blue")
        {
            r.material.color = bColor;
        }

        else if (color == "red")
        {
            r.material.color = rColor;
        }

        else if (color == "cyan")
        {
            r.material.color = cColor;
        }

        else if (color == "green")
        {
            r.material.color = grColor;
        }

        else
        {
            r.material.color = gColor;
        }
    }

    //Use this for the actual interactions. "co" refers to the color of the face it just intersected
    public void ColorEffect(string co)
    {
        // Blue extinguishes red, red burns green, and green absorbs blue
        if ((color == "red" & co == "blue") | (color == "green" & co == "red") | (color == "blue" & co == "green"))
        {
            SetColor("grey");
        }

        // If the color of the terrain is red and it isn't blue, the player dies
        else if (color == "red" & co != "blue")
        {
            ScoreManager.Instance.Score -= 20;
            gameover.Setup(ScoreManager.Instance.Score);
        }

        // Grey never replaces a color
        else if (co == "grey")
        {
            SetColor(color);
        }

        // If no interaction takes place, just change the color of the tile
        else
        {
            SetColor(co);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!connected & !shift)
        {
            if (other.CompareTag("Face"))
            {
                //Debug.Log("whoo");
                script1 = (CreateFace)other.GetComponentInParent(typeof(CreateFace));

                if (script1 != null)
                {
                    //Debug.Log(script1.AskColor());

                    if (script1.AskColor() != "travel")
                    {
                        connected = true;
                        shift = true;
                        shiftto = script1.AskColor();
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("left");
        if (other.CompareTag("Face"))
        {
            connected = false;
        }
    }

    void Update()
    {
        if (connected && shift)
        {
            //ColorEffect(shiftto);
            shift = false;
        }
    }
}