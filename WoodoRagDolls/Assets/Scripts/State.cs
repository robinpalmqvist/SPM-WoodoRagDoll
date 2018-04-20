using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject {
    
    [HideInInspector]public Controller Controller;

    public abstract void Update();
    public abstract void Initialize(Controller owner);
    public virtual void Enter() { }
    public virtual void Exit() { }

    public virtual void FixedUpdate() { }
}
