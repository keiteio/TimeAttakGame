using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class Wireframe : MonoBehaviour {

    public Mesh Mesh;
    public Material Material;

    private Mesh drawMesh;

	// Use this for initialization
	void Start () {
        drawMesh = new Mesh();
        drawMesh.vertices = new Vector3[this.Mesh.vertexCount];
        for(int i = 0; i < this.Mesh.vertexCount; i++){
            Vector3 v = new Vector3();
            v.x = this.Mesh.vertices[i].x;
            v.y = this.Mesh.vertices[i].y;
            v.z = this.Mesh.vertices[i].z;
            drawMesh.vertices[i] = v;
        }
        for (int i = 0; i < this.Mesh.subMeshCount; i++)
        {
            drawMesh.SetIndices(Mesh.GetIndices(i), MeshTopology.Lines, i);
            drawMesh.SetTriangles(Mesh.GetTriangles(i), i);
        }
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
                Graphics.DrawMeshNow(drawMesh, this.transform.localToWorldMatrix);
            }
        }
    }
}
