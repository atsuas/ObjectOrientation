using UnityEngine;

public interface IChangeMeshColor
{
    MeshRenderer Mesh { get; }
    Color MeshColor { get; }
    void ChangeMeshColor();
}



