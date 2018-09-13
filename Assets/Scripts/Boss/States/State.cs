using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    protected GameObject origin;
    public abstract void tick(float timeElapsed);
}