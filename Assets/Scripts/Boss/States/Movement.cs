using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MovementData{
    public float radius;
    public float speed;
    public float depth;
}

public abstract class Movement : State {
    protected MovementData data;
}
public class Wave : Movement{
    public Wave(GameObject root, MovementData moveControlls){
        origin = root;
        data = moveControlls;
    }
    public override void tick(float timeElapsed){
        origin.transform.position = new Vector3(
            Mathf.Sin(timeElapsed * data.speed) * data.radius,
            0f,
            data.depth);

    }
}
public class Tangent : Movement{
    public Tangent(GameObject root, MovementData moveControlls){
        origin = root;
        data = moveControlls;
    }
    public override void tick(float timeElapsed){
        origin.transform.position = new Vector3(
            Mathf.Tan((timeElapsed * data.speed) / 2f) * data.radius,
            0f,
            data.depth);
    }
}