using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInGame : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] public InteractableObject interactableObject;

    public Action OnTapObject = null;
    void Start()
    {
        interactableObject.Setup(id, this);
    }
}
