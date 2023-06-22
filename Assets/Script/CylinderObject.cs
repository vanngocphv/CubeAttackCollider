using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderObject : MonoBehaviour
{
    public event System.Action<float> OnHitCountChanged;

    [SerializeField] private GameObject _cylinder;
    [SerializeField] private float _rollingSpeed = 10f;

    private float currentRollDeg;
    private float currentHitCount = 0f;


    // Start is called before the first frame update
    private void Start()
    {
        currentRollDeg = _cylinder.transform.localRotation.eulerAngles.y;
    }

    // Update is called once per frame
    private void Update()
    {
        RollingAroundObject();
    }
    private void FixedUpdate()
    {
        CylinderHitCount();
    }


    private void RollingAroundObject()
    {
        currentRollDeg += _rollingSpeed;
        currentRollDeg = ClampAngle(_rollingSpeed);

        _cylinder.transform.localEulerAngles += new Vector3(0f, currentRollDeg, 0f);

    }
    private float ClampAngle(float angle)
    {
        if (angle > 180f) angle -= 180f;
        else if (angle < -180f) angle += 180f;

        return angle;
    }

    private void CylinderHitCount()
    {
        _cylinder.gameObject.TryGetComponent(out CylinderCollision collision);
        float currentHit = collision.CountHit;
        if (currentHit != currentHitCount)
        {
            OnHitCountChanged?.Invoke(currentHit);
            currentHitCount = currentHit;
        }
    }

    
}
