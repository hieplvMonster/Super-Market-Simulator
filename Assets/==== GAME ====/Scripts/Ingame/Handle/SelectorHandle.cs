using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorHandle : MonoBehaviour
{
    private static SelectorHandle instance;
    public static SelectorHandle Instance { get => instance; }
    [SerializeField] Camera playerCamera;
    [SerializeField] public Transform grabPoint;
    [SerializeField] public Transform furniturePoint;
    [SerializeField] float detectRange;
    [SerializeField] InteractableObject currentAim;
    [SerializeField] InteractableObject currentGrab;
    private void Awake()
    {
        if (instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void Update()
    {
        if (isAimInteractable)
        {
            currentAim = hitAim.collider.GetComponent<ObjectInGame>().interactableObject;
            currentAim?.PerformAim(true);
        }
        else
        {
            currentAim?.ShowOutLine(false);
            currentAim = null;
        }
    }
    Ray aimRay, tapRay;
    void FixedUpdate()
    {
        isAimInteractable = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitAim, detectRange, whatIsInteractable);
        if (IsTap())
        {
            if (currentGrab) return;
            CheckTap();
        }
    }
    bool IsTap()
    {
        return Input.GetMouseButtonDown(0) || Input.touchCount > 0;
    }
    Vector2 tapPos;
    void CheckTap()
    {

        tapPos =
#if UNITY_EDITOR
           Input.mousePosition;
#else
                Input.touches[0].position;
#endif
        Ray ray = playerCamera.ScreenPointToRay(tapPos);
        if (Physics.Raycast(ray, out hitTap, detectRange, whatIsInteractable))
        {
            if (hitTap.collider == hitAim.collider)
            {
                currentGrab = hitTap.collider.GetComponent<ObjectInGame>().interactableObject;
                currentGrab.PerformGrab();
                currentAim.EndAim();
                currentAim = null;
            }
        }

    }
    [ContextMenu("Throw")]
    public void Throw()
    {
        currentGrab.PerformGrab();
    }
    [SerializeField] public LayerMask whatIsInteractable;
    [SerializeField]bool isAimInteractable = false;
    RaycastHit hitAim;
    RaycastHit hitTap;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * detectRange);

    }
}
