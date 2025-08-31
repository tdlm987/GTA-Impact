using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : TrungMonoBehaviour
{
    public Transform target;
    public float sensitivity = 2f;

    private float yaw;
    private float pitch;

    private PlayerInputHandler input;

    protected override void Start()
    {
        input = target.GetComponent<PlayerInputHandler>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        Vector2 look = input.LookInput;
        yaw += look.x * sensitivity;
        pitch -= look.y * sensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 70f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = target.position - transform.forward * 5f + Vector3.up * 2f;
    }
}
