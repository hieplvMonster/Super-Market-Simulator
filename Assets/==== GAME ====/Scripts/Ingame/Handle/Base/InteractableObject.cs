using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ObjectInGame), typeof(Outline))]
public class InteractableObject : MonoBehaviour
{
    #region OLD
    //[SerializeField] protected Transform owner;
    //[SerializeField] protected bool canGrab = false;
    //public bool canTapWithinHover = false;

    //protected Outline outlineObj;
    //public Action onTapObject = null;
    //protected SelectorHandle selector;
    //protected Transform parentOrigin;
    //protected Rigidbody rb;
    //public bool _isHovering = false;
    //public bool IsHovering => _isHovering;
    //protected virtual void Awake()
    //{
    //    outlineObj = GetComponent<Outline>();
    //    parentOrigin = owner.parent;
    //    rb = owner.GetComponentInChildren<Rigidbody>();
    //}

    //public void Init(SelectorHandle selectorHandle)
    //{
    //    selector = selectorHandle;
    //}
    //public virtual InteractableObject OnEnterHover()
    //{
    //    outlineObj.enabled = true;
    //    _isHovering = true;
    //    return this;
    //}

    //public virtual void UnHover()
    //{
    //    outlineObj.enabled = false;
    //    _isHovering = false;
    //}

    //public virtual void OnTap()
    //{
    //    onTapObject?.Invoke();
    //}

    //public virtual void OnGrab()
    //{

    //}

    //public virtual void OnEndGrab()
    //{

    //}
    #endregion
    int id;
    protected Transform parentOrigin;
    [SerializeField] protected Transform owner;
    public bool canGrab = false;
    public bool canInteractWithoutAim = false;
    public bool supprtoLongClick = false;
    protected float clickTime;
    [SerializeField] Outline outline;

    #region Action
    protected Action<int> onAimAction = null;
    protected Action onEndAim = null;
    // Action invoke 0 - when grab box, 1- grab funiture, 2 - ....
    protected Action<int> onStartGrab = null;
    protected Action onEndGrab = null;
    protected ObjectInGame objInGame = null;
    #endregion
    public virtual void Setup(int _id, ObjectInGame objectInGame)
    {
        id = _id;
        objInGame = objectInGame;
        parentOrigin = owner.parent;
    }
    public bool isAim = false;
    public virtual void PerformAim(bool isShowOutLine)
    {
        ShowOutLine(isShowOutLine);
        isAim = true;
        onAimAction?.Invoke(id);
    }
    public virtual void EndAim()
    {
        isAim = false;
        onEndAim?.Invoke();
    }

    public virtual void PerformGrab()
    {
        onEndAim?.Invoke();
    }

    public virtual void EndGrab()
    {
    }
    public void ShowOutLine(bool isShow) => outline.enabled = isShow;
}
//public enum Action_Type
//{
//    Show_Outline,
//    Grab,
//    Nothing,
//    Throw,
//}
