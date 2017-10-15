using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class CreateCircle : MonoBehaviour
{

    Mesh m;
    MeshFilter mf;

    List<Vector3> circleVerteices = new List<Vector3>();
    List<Vector2> uvs = new List<Vector2>();
    List<int> triangles = new List<int>();
    
    // Use this for initialization
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        m = new Mesh();
        mf.mesh = m;
        drawCircle();

        //gameObject.GetComponent<MeshCollider>().sharedMesh = m;
        //gameObject.GetComponent<MeshCollider>().convex = true;
        //AssetDatabase.CreateAsset(m, "Assets/smallCircle.asset");
    }

    void drawCircle()
    {
        float val = 3.14285f / 180f;//one degree = val radians
        float radius = 1.0f;
        int deltaAngle = 15;

        Vector3 center = Vector3.zero;
        circleVerteices.Add(center);
        uvs.Add(new Vector2(0.5f, 0.5f));
        int triangleCount = 0;

        float x1 = radius * Mathf.Cos(0);
        float y1 = radius * Mathf.Sin(0);
        float z1 = 0;
        Vector3 point1 = new Vector3(x1, y1, z1);
        circleVerteices.Add(point1);
        uvs.Add(new Vector2((x1 + radius) / 2 * radius, (y1 + radius) / 2 * radius));

        for (int i = 0; i < 359; i = i + deltaAngle)
        {
            float x2 = radius * Mathf.Cos((i + deltaAngle) * val);
            float y2 = radius * Mathf.Sin((i + deltaAngle) * val);
            float z2 = 0;
            Vector3 point2 = new Vector3(x2, y2, z2);
            
            circleVerteices.Add(point2);
           
            uvs.Add(new Vector2((x2 + radius)/ 2 * radius, (y2 +radius)/ 2 * radius));

            triangles.Add(0);
            triangles.Add(triangleCount  + 2);
            triangles.Add(triangleCount  + 1);

            triangleCount++;
            point1 = point2;
        }
        



        m.vertices = circleVerteices.ToArray();
        m.triangles = triangles.ToArray();
        m.uv = uvs.ToArray();

    }
}
