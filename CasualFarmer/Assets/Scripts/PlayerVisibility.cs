using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Material _transparentMaterial;
    [SerializeField] private Material _originMaterial;
    
    private MeshRenderer _currentMesh;
    
    void FixedUpdate()
    {
        var heading = _playerPosition.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            MeshRenderer Mesh = hit.collider.gameObject.GetComponent<MeshRenderer>();

            if (Mesh)
            {
                if (_currentMesh && _currentMesh != Mesh)
                {
                    _currentMesh.material = _originMaterial;
                }

                _currentMesh = Mesh;
                _currentMesh.material = _transparentMaterial;
            }
            else if (_currentMesh)
            {
                _currentMesh.material = _originMaterial;
                _currentMesh = null;
            }
            
            
        }
        else if (_currentMesh)
        {
            _currentMesh.material = _originMaterial;
            _currentMesh = null;
        }

    }
}
