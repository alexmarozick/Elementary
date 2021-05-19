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

    public bool Match(float x, float z)
    {
        if((x == transform.position.x) && (z == transform.position.z)){
            return true;
        }
        return false;
    }


    public float GetX()
    {
        return transform.position.x;
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
