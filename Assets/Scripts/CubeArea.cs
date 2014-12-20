using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class CubeArea : MonoBehaviour {

    public Material Material;

    private Vector3[] vertices;
    private int[] indices;

    private Mesh mesh;

	// Use this for initialization
	void Start () {
        vertices = new Vector3[8];
        vertices[0] = new Vector3(0.5f, 0.5f, 0.5f);
        vertices[1] = new Vector3(0.5f, -0.5f, 0.5f);
        vertices[2] = new Vector3(-0.5f, -0.5f, 0.5f);
        vertices[3] = new Vector3(-0.5f, 0.5f, 0.5f);
        vertices[4] = new Vector3(0.5f, 0.5f, -0.5f);
        vertices[5] = new Vector3(0.5f, -0.5f, -0.5f);
        vertices[6] = new Vector3(-0.5f, -0.5f, -0.5f);
        vertices[7] = new Vector3(-0.5f, 0.5f, -0.5f);

        indices = new int[]{
            0, 1,
            1, 2,
            2, 3,
            3, 0,
            4, 5,
            5, 6,
            6, 7,
            7, 4,
            0, 4,
            1, 5,
            2, 6,
            3, 7
        };
        
        mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.SetIndices(indices, MeshTopology.Lines, 0);

	}

    Vector3 ToWorld(Vector3 vec)
    {
        return gameObject.transform.TransformPoint(vec);
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnRenderObject()
    {
        for (int i = 0; i < this.Material.passCount; i++)
        {
            if (this.Material.SetPass(i))
            {
                Graphics.DrawMeshNow(mesh, this.transform.localToWorldMatrix);
            }
        }
    }
}