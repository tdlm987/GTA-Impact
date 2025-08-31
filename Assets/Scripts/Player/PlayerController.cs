using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PersonController
{
    [SerializeField] protected PlayerInputHandler playerInputHandler;
    //[SerializeField] protected Transform cameraRoot;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerInputHandler();
    }


    #region Load Components


    protected virtual void LoadPlayerInputHandler()
    {
        if (this.playerInputHandler != null) return;
        this.playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    #endregion

    private void Update()
    {
        this.PlayerHandleMovement();
    }

    protected virtual void PlayerHandleMovement()
    {
        Vector2 move = this.playerInputHandler.MoveInput;

        if (move.sqrMagnitude > 0.01f)
        {
            // Lấy hướng camera (chỉ tính XZ)
            Vector3 camForward = Camera.main.transform.forward;
            camForward.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(camForward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 10f);
        }

        this.Move(move, playerInputHandler.SprintPressed, playerInputHandler.JumpPressed);
    }
}
