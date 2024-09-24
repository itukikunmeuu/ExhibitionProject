using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alalal : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Vector3[] verts = new Vector3[10];
        int[] trinangles = { 0, 1, 9, 1, 2, 3, 3, 4, 5, 5, 6, 7, 7, 8, 9, 1, 3, 9, 3, 7, 9, 3, 5, 7 };

        verts[0] = new Vector3(-8, 2, 5);
        verts[1] = new Vector3(-2, 2, 5);
        verts[2] = new Vector3(0, 7, 5);
        verts[3] = new Vector3(2, 2, 5);
        verts[4] = new Vector3(8, 2, 5);
        verts[5] = new Vector3(3, -1, 5);
        verts[6] = new Vector3(5, -7, 5);
        verts[7] = new Vector3(0, -3, 5);
        verts[8] = new Vector3(-5, -7, 5);
        verts[9] = new Vector3(-3, -1, 5);

        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = trinangles;
        mesh.RecalculateNormals();

        mf.sharedMesh = mesh;
        mr.sharedMaterial = material;
    }
}
