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
    
    public string color = "grey";
    int counter = 0;

    private Color yColor = new Color(0.914f, 0.788f, 0.263f);
    private Color rColor = new Color(0.871f, 0.376f, 0.141f);
    private Color bColor = new Color(0.275f, 0.451f, 0.773f);
    private Color gColor = new Color(0.545f, 0.545f, 0.545f);


    void Start()
    {
        
        counter = -1;
        Create(color);

    }

    public string GetColor()
    {
        return color;
    }

    public void Create(string co)
    {
        Debug.Log("created");
        color = co;
        counter = counter + 1;
       if (counter >= 4)
        {
            counter = 0;
        }
        /*if (counter == 1)
        {
            color = "yellow";
        }
        else if (counter == 2)
        {
            color = "red";
        }
        else if (counter == 3)
        {
            color = "blue";
        }
        else
        {
            color = "grey";
        }*/


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
        else
        {
            r.material.color = gColor;
        }



    }


    void Update()
    {
        
    }
}
