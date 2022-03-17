using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour, IChangeMeshColor
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] Color color;

    public MeshRenderer Mesh { get => mesh; }
    public Color MeshColor { get => color; }

    private void Start()
    {
        ChangeMeshColor();
    }

    public void ChangeMeshColor()
    {
        if (Mesh != null) Mesh.material.color = MeshColor;
    }
}
