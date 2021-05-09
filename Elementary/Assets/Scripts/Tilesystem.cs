using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilesystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
