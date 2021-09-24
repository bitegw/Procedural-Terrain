using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {
    public Vector3Int coord;

    [HideInInspector]
    public Mesh mesh;
    public ChunkLOD lod;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    bool generateCollider;

    public void DestroyOrDisable () {
        if (Application.isPlaying) {
            mesh.Clear ();
            gameObject.SetActive (false);
        } else {
            DestroyImmediate (gameObject, false);
        }
    }

    // Add components/get references in case lost (references can be lost when working in the editor)
    public void SetUp (Material mat, bool generateCollider) {
        this.generateCollider = generateCollider;

        meshFilter = GetComponent<MeshFilter> ();
        meshRenderer = GetComponent<MeshRenderer> ();
        meshCollider = GetComponent<MeshCollider> ();

        if (meshFilter == null) {
            meshFilter = gameObject.AddComponent<MeshFilter> ();
        }

        if (meshRenderer == null) {
            meshRenderer = gameObject.AddComponent<MeshRenderer> ();
        }

        if (meshCollider == null && generateCollider) {
            meshCollider = gameObject.AddComponent<MeshCollider> ();
        }
        if (meshCollider != null && !generateCollider) {
            DestroyImmediate (meshCollider);
        }

        mesh = meshFilter.sharedMesh;
        if (mesh == null) {
            mesh = new Mesh ();
            mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            meshFilter.sharedMesh = mesh;
        }

        if (generateCollider) {
            if (meshCollider.sharedMesh == null) {
                meshCollider.sharedMesh = mesh;
            }
            // force update
            meshCollider.enabled = false;
            meshCollider.enabled = true;
        }

        meshRenderer.material = mat;
    }
}

[System.Serializable]
public class ChunkLOD
{
    public string name;
    public int step;

    [SerializeField]
    private float distance;

    public float Distance {
        get => distance;
        set {
            distance = value;
            UpdateSqrDst();
        }
    }

    public void UpdateSqrDst()
    {
        SqrDst = distance * distance;
    }

    public float SqrDst { get; private set; }

    public ChunkLOD(string _name, int _step, float _distance)
    {
        name = _name;
        step = _step;
        distance = _distance;
        SqrDst = distance * distance;
    }

    public bool Equals(ChunkLOD other)
    {
        return (step == other.step && distance == other.distance);
    }

    public static bool operator ==(ChunkLOD a, ChunkLOD b)
    {
        return a.Equals(b);
    }

    public static bool operator != (ChunkLOD a, ChunkLOD b)
    {
        return !a.Equals(b);
    }
}