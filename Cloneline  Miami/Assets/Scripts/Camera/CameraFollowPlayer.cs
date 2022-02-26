using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject _player;
    private Camera _camera;

    public bool CanFollowPlayer { get; set; } = true;

    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            CanFollowPlayer = false;
        else
            CanFollowPlayer = true;

        if (CanFollowPlayer)
            FollowPlayer();
        else
            LookAhead();
    }

    private void FollowPlayer()
    {
        Vector3 newPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    private void LookAhead()
    {
        Vector3 cameraPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        cameraPosition.z = -10;
        Vector3 direction = cameraPosition - transform.position;
        transform.Translate(direction * 2 * Time.deltaTime);
    }
}
