using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject {

    [HideInInspector]
    public Controller Controller;
    public Transform transform { get { return Controller.transform; } }

    public virtual void Update() { }
    public virtual void Initialize(Controller owner) { }
    public virtual void Enter() { }
    public virtual void Exit() { }

    public virtual void FixedUpdate() { }
}
