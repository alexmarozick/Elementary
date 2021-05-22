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
    
    

    public GameObject tracker;
    private ColorTracker basecolor;

    void Start()
    {
        ready = true;

        if (tracker != null)
        {
            basecolor = (ColorTracker)tracker.GetComponent(typeof(ColorTracker));
        }

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

        r.material.color = basecolor.GetColor(color);
        

        //mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    public void SetColor(string co)
    {
        MeshRenderer r = GetComponent<MeshRenderer>();

        color = co;



        r.material.color = basecolor.GetColor(co);
    }
}
