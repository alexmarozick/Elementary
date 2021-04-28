using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

/*
 * Citing these tutorial as a souce
 * http://ilkinulas.github.io/development/unity/2016/04/30/cube-mesh-in-unity3d.html
 * http://ilkinulas.github.io/development/unity/2016/05/06/uv-mapping.html
 */

public class CreateTerrain : MonoBehaviour
{
    public Vector3 TerrainOffset;
    public Vector3 TerrainSize;
    public string color = "grey";

	void Start()
	{
		Create(TerrainOffset, TerrainSize);
	}


    Vector2[] Recolor(string c)
    {
        Vector2[] uvs;
        if (c == "blue")
        {
            uvs = new Vector2[] {
                new Vector2(0, 0.50f),
                new Vector2(0.25f, 0.50f),
                new Vector2(0, 0.25f),
                new Vector2(0.25f, 0.25f),

                new Vector2(0.5f, 0.50f),
                new Vector2(0.5f, 0.25f),
                new Vector2(0.75f, 0.50f),
                new Vector2(0.75f, 0.25f),

                new Vector2(1, 0.50f),
                new Vector2(1, 0.25f),

                new Vector2(0.25f, 1),
                new Vector2(0.5f, 1),

                new Vector2(0.25f, 0),
                new Vector2(0.5f, 0),
            };

        }
        else if (c == "red")
        {
            uvs = new Vector2[] {
                new Vector2(0, 1.0f),
                new Vector2(0.25f, 1.0f),
                new Vector2(0, 0.75f),
                new Vector2(0.25f, 0.75f),

                new Vector2(0.5f, 1.0f),
                new Vector2(0.5f, 0.75f),
                new Vector2(0.75f, 1.0f),
                new Vector2(0.75f, 0.75f),

                new Vector2(1, 1.0f),
                new Vector2(1, 0.75f),

                new Vector2(0.25f, 1),
                new Vector2(0.5f, 1),

                new Vector2(0.25f, 0),
                new Vector2(0.5f, 0),
            };
        }
        else if (c == "yellow")
        {
            uvs = new Vector2[] {
                new Vector2(0, 0.75f),
                new Vector2(0.25f, 0.75f),
                new Vector2(0, 0.50f),
                new Vector2(0.25f, 0.50f),

                new Vector2(0.5f, 0.75f),
                new Vector2(0.5f, 0.50f),
                new Vector2(0.75f, 0.75f),
                new Vector2(0.75f, 0.50f),

                new Vector2(1, 0.75f),
                new Vector2(1, 0.50f),

                new Vector2(0.25f, 1),
                new Vector2(0.5f, 1),

                new Vector2(0.25f, 0),
                new Vector2(0.5f, 0),
            };
        }
        else
        {

            uvs = new Vector2[] {
                new Vector2(0, 0.75f),
                new Vector2(0.25f, 0.75f),
                new Vector2(0, 0.50f),
                new Vector2(0.25f, 0.50f),

                new Vector2(0.5f, 0.75f),
                new Vector2(0.5f, 0.50f),
                new Vector2(0.75f, 0.75f),
                new Vector2(0.75f, 0.50f),

                new Vector2(0.5f, 1.0f),
                new Vector2(0.5f, 0.75f),

                new Vector2(0.25f, 1),
                new Vector2(0.5f, 1),

                new Vector2(0.25f, 0),
                new Vector2(0.5f, 0),
            };
        }

        return uvs;
    }

    void Create(Vector3 offset, Vector3 cubescale)
    {
        float size = 1f;

        float x = offset.x;
        float y = offset.y;
        float z = offset.z;
        
        Vector3[] vertices = {
        new Vector3(0, size, 0),
			new Vector3(0, 0, 0),
			new Vector3(size, size, 0),
			new Vector3(size, 0, 0),

			new Vector3(0, 0, size),
			new Vector3(size, 0, size),
			new Vector3(0, size, size),
			new Vector3(size, size, size),

			new Vector3(0, size, 0),
			new Vector3(size, size, 0),

			new Vector3(0, size, 0),
			new Vector3(0, size, size),

			new Vector3(size, size, 0),
			new Vector3(size, size, size),
        };

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].Scale(cubescale);
            vertices[i] += offset;
        }

        int[] triangles = {
        0, 2, 1, // front
			1, 2, 3,
            4, 5, 6, // back
			5, 7, 6,
            6, 7, 8, //top
			7, 9 ,8,
            1, 3, 4, //bottom
			3, 5, 4,
            1, 11,10,// left
			1, 4, 11,
            3, 12, 5,//right
			5, 12, 13
        };



        Vector2[] uvs = Recolor(color);


        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();

        mesh.RecalculateNormals();
    }

    public void Changetile(string co)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.uv = Recolor(co);
        mesh.Optimize();

        mesh.RecalculateNormals();
    }
}