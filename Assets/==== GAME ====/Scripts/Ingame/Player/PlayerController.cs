using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;
    [SerializeField] Joystick moveJoy;
    [SerializeField] Joystick rotJoy;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
#if UNITY_EDITOR
        moveJoy.gameObject.SetActive(false);
#endif

    }
    float mX, mY, rX, rY;
    void Update()
    {
#if UNITY_EDITOR

        mX = Input.GetAxis("Horizontal");
        mY = Input.GetAxis("Vertical");
#else
        mX = moveJoy.Horizontal;
        mY = moveJoy.Vertical;
#endif
        rX = rotJoy.Horizontal;
        rY = rotJoy.Vertical;
        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? walkSpeed * mY : 0;
        float curSpeedY = canMove ? walkSpeed * mX : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -rY * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, rX * lookSpeed, 0);
        }

        #endregion
    }
}


