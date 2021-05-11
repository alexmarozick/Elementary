using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilesystem : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject face1;
    Terrain2 script1;

    void Start()
    {

        script1 = (Terrain2)face1.GetComponent(typeof(Terrain2));

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
    }

    //currently only set to get the top facing color
    public string GetColor()
    {
        return script1.GetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
