using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    MeshRenderer mesh;
    void Start()
    {
        if(gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
        {
            mesh = renderer;
        }
        else
        {
            Debug.Log("Object does not include a mesh renderer");
        }
    }

    public void ChangeMaterialFunction(Material material)
    {
        if(mesh != null)
        {
            mesh.material = material;
        }
        else
        {
            Debug.Log("Mesh is null");
        }
    }
}
