using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderCollision : MonoBehaviour
{
    public float CountHit => _count;
    private float _count = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _count++;
        }
    }
}
