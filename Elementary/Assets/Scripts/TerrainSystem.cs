using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject face1, face2, face3, face4, face5, face6;
    CreateTerrain script1, script2, script3, script4, script5, script6;

    void Start()
    {
        script1 = (CreateTerrain)face1.GetComponent(typeof(CreateTerrain));
        script2 = (CreateTerrain)face2.GetComponent(typeof(CreateTerrain));
        script3 = (CreateTerrain)face3.GetComponent(typeof(CreateTerrain));
        script4 = (CreateTerrain)face4.GetComponent(typeof(CreateTerrain));
        script5 = (CreateTerrain)face5.GetComponent(typeof(CreateTerrain));
        script6 = (CreateTerrain)face6.GetComponent(typeof(CreateTerrain));
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

    public void SetColor(string color, string direction)
    {
        if (direction == "up")
        {
            script6.ColorEffect(color);
        }
        else if (direction == "down")
        {
            script1.ColorEffect(color);
        }
        else if (direction == "north")
        {
            script4.ColorEffect(color);
        }
        else if (direction == "east")
        {
            script5.ColorEffect(color);
        }
        else if (direction == "south")
        {
            script2.ColorEffect(color);
        }
        else if (direction == "west")
        {
            script3.ColorEffect(color);
        }
    }

    public string GetColor(string direction)
    {
        
        if (direction == "up")
        {
            return script1.GetColor();
        }
        else if (direction == "down")
        {
            return script6.GetColor();
        }
        else if (direction == "north")
        {
            return script2.GetColor();
        }
        else if (direction == "east")
        {
            return script3.GetColor();
        }
        else if (direction == "south")
        {
            return script4.GetColor();
        }
        else if (direction == "west")
        {
            return script5.GetColor();
        }

        
        return script1.GetColor();
    }
}
