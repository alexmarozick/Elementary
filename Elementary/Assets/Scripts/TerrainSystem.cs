using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject face1;
    CreateTerrain script1;

    void Start()
    {
        script1 = (CreateTerrain)face1.GetComponent(typeof(CreateTerrain));

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
    }

    public bool Match(float x, float z, float y)
    {
        if((x < transform.position.x + 0.1f) && (z < transform.position.z + 0.1f) && (y < transform.position.y + 0.1f)&& (x > transform.position.x - 0.1f) && (z > transform.position.z - 0.1f) && (y > transform.position.y - 0.1f))
        {
            return true;
        }
        return false;
    }


    public float GetX()
    {
        return transform.position.x;
    }

    public float GetY()
    {
        return transform.position.y;
    }

    public float GetZ()
    {
        return transform.position.z;
    }

    //currently only set to get the top facing color
    public string GetColor()
    {
        return script1.GetColor();
    }
}
