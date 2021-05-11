using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class CreateFace : MonoBehaviour
{
    public GameObject terrain;
    public Vector3 TerrainOffset;
    public Vector3 TerrainSize;

    bool ready;

    public string color = "grey";
    
    private Color yColor = new Color(0.914f, 0.788f, 0.263f);
    private Color rColor = new Color(0.871f, 0.376f, 0.141f);
    private Color bColor = new Color(0.275f, 0.451f, 0.773f);
    private Color gColor = new Color(0.545f, 0.545f, 0.545f);
    private Color grColor = new Color(0.016f, 0.612f, 0.346f);
    private Color cColor = new Color(0.604f, 0.914f, 0.961f);

    void Start()
    {
        ready = true;
        
        Create(color);
    }

    public string AskColor()
    {
        //method for the tiles to check
        if (ready)
        {
            return GetColor();
        }

        else
        {
            return "travel";
        }
    }

    public string GetColor()
    {
        //used by Player cube when coordinating movement
        return color;
    }

    public void Close()
    {
        //make unreadable by tiles
        ready = false;
    }

    public void Open()
    {
        //make readable by tiles
        ready = true;
    }

    public void Create(string co)
    {
        Debug.Log("created");
        color = co;
        
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

        //mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

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
}