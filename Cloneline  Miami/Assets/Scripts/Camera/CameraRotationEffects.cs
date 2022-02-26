using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationEffects : MonoBehaviour
{
    private const float MOD_VALUE = 0.02f;

    private PlayerMovement _playerMovement;
    private float _mod = MOD_VALUE;
    private float _zVal = 0.0f;

    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (_playerMovement.IsMoving)
            RotateCamera();
    }

    private void RotateCamera()
    {
        Vector3 rotation = new Vector3(0, 0, _zVal);
        transform.eulerAngles = rotation;

        _zVal += _mod;

        if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f)
            _mod = -MOD_VALUE;
        if (transform.eulerAngles.z > 350.0f && transform.eulerAngles.z < 355.0f)
            _mod = MOD_VALUE;
    }
}
