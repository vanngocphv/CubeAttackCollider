using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Enemy : MonoBehaviour
{
    const string const_string_LastHitTime = "_LastHitTime";
    static readonly int shader_LastHitTime = Shader.PropertyToID(const_string_LastHitTime);
    Material _enemyMaterial;

    private void Awake()
    {
        _enemyMaterial = this.GetComponentInChildren<MeshRenderer>().material;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _enemyMaterial.SetFloat(shader_LastHitTime, Time.time);
        }
        
    }
}
