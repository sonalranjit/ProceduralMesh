using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBasicTriangle : MonoBehaviour {
    Mesh mesh;
	// Use this for initialization
	void Start () {

        mesh = new Mesh();

        //assign points
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(-1, -1, 0);
        vertices[1] = new Vector3(0, 0.8f, 0);
        vertices[2] = new Vector3(1, -1, 0);
        mesh.vertices = vertices;

        //assign triangles
        int[] triangles = new int[] { 0, 1, 2 };
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] normals = new Vector3[3];
        normals[0] = Vector3.back; normals[1] = Vector3.back; normals[2] = Vector3.back;

        mesh.normals = normals;
	}

    [SerializeField] float speed = 90f;

	// Update is called once per frame
	void Update () {
        Color[] colors = new Color[3];

        float offset = Time.time * speed;

        colors[0] = ColorFromHue(0 + offset);
        colors[1] = ColorFromHue(120 + offset);
        colors[2] = ColorFromHue(240 + offset);

        mesh.colors = colors;
	}

    Color32 ColorFromHue(float h)
    {
        h = Mathf.Repeat(h, 360f);

        h /= 60;            // sector 0 to 5
        float s = 1; float v = 1; //saturation and value is both set to max
        float c = s * v;

        //HSV to RGB conversion
        Color32 returnCol = new Color32();
        returnCol.a = 255;

        int i;
        float f, p, q, t;

        if (s == 0)
        {
            // achromatic (grey)
            returnCol.r = (byte)(v * 255);
            returnCol.g = (byte)(v * 255);
            returnCol.b = (byte)(v * 255);
            return returnCol;
        }

        i = (int)System.Math.Floor((double)h);
        f = h - i;          // factorial part of h
        p = v * (1 - s);
        q = v * (1 - s * f);
        t = v * (1 - s * (1 - f));
        switch (i)
        {
            case 0:
                returnCol.r = (byte)(v * 255);
                returnCol.g = (byte)(t * 255);
                returnCol.b = (byte)(p * 255);
                break;
            case 1:
                returnCol.r = (byte)(q * 255);
                returnCol.g = (byte)(v * 255);
                returnCol.b = (byte)(p * 255);
                break;
            case 2:
                returnCol.r = (byte)(p * 255);
                returnCol.g = (byte)(v * 255);
                returnCol.b = (byte)(t * 255);
                break;
            case 3:
                returnCol.r = (byte)(p * 255);
                returnCol.g = (byte)(q * 255);
                returnCol.b = (byte)(v * 255);
                break;
            case 4:
                returnCol.r = (byte)(t * 255);
                returnCol.g = (byte)(p * 255);
                returnCol.b = (byte)(v * 255);
                break;
            default:        // case 5:
                returnCol.r = (byte)(v * 255);
                returnCol.g = (byte)(p * 255);
                returnCol.b = (byte)(q * 255);
                break;
        }

        return returnCol;
    }
}
