using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BoxInteractionObject : InteractableObject
{
    [SerializeField] bool isGrab = false;
    [SerializeField] float force;
    public override void PerformAim(bool isShowOutLine)
    {
        base.PerformAim(isShowOutLine);
    }
    public override void PerformGrab()
    {
        base.PerformGrab();
        onStartGrab?.Invoke(0);
        isGrab = true;
        owner.parent = SelectorHandle.Instance.grabPoint;
        owner.GetComponent<Rigidbody>().useGravity = false;
        owner.GetComponent<Rigidbody>().isKinematic = true;
        owner.transform.DOLocalMove(Vector3.zero, .3f);
        owner.transform.DOLocalRotate(Vector3.zero, .3f);
    }
    public override void EndGrab()
    {
        base.EndGrab();
        owner.parent = parentOrigin;
        owner.GetComponent<Rigidbody>().useGravity = true;
        owner.GetComponent<Rigidbody>().isKinematic = false;
        owner.GetComponent<Rigidbody>().AddForce(owner.forward * force);

    }
    public override void Setup(int _id, ObjectInGame objectInGame)
    {
        base.Setup(_id, objectInGame);
        objInGame.OnTapObject = PerformGrab;
    }
}
