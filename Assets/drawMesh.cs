using UnityEngine;
using System.Collections;

public class drawMesh : MonoBehaviour {

    Mesh m;
    MeshFilter mf;

    // Use this for initialization
    void Start ()
    {
        mf = GetComponent<MeshFilter>();
        m = new Mesh();
        mf.mesh = m;
        drawTriangle();
	}
	
	//This draws a triangle
    void drawTriangle()
    {
        //We need two arrays one to hold the vertices and one to hold the triangles
        Vector3[] VerteicesArray = new Vector3[3];
        int[] trianglesArray = new int[3];

        //lets add 3 vertices in the 3d space
        VerteicesArray[0] = new Vector3(0, 1, 0);
        VerteicesArray[1] = new Vector3(-1, 0, 0);
        VerteicesArray[2] = new Vector3(1, 0, 0);

        //define the order in which the vertices in the VerteicesArray shoudl be used to draw the triangle
        trianglesArray[0] = 0;
        trianglesArray[1] = 1;
        trianglesArray[2] = 2;

        //add these two triangles to the mesh
        m.vertices = VerteicesArray;
        m.triangles = trianglesArray;
    }
}
