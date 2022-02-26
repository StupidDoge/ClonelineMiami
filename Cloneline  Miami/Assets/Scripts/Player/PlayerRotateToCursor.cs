using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateToCursor : MonoBehaviour
{
    private Vector3 _mousePosition;
    [SerializeField] private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        /*if (!CutsceneController.anyCutsceneDisplaying && !PauseMenu.gameIsPaused)
            PlayerRotation();*/
        RotatePlayerTowardsCursor();
    }

    void RotatePlayerTowardsCursor()
    {
        _mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - _camera.transform.position.z));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((_mousePosition.y - transform.position.y), (_mousePosition.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}
