using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PatternData{
    // General
    public float speed;
    // For zig-zag
    public float radius;
}
/*
    Patterns are created by rotating the object
    Since fiering aways happens in set directions
*/

public abstract class Pattern : State {
    protected PatternData data;
}

public class Static : Pattern{
    public Static(GameObject root, PatternData pat){
        origin = root;
        data = pat;
    }
    public override void tick(float timeElapsed){
        // Does nothing!
    }
}

public class Spiral : Pattern{
    public Spiral(GameObject root, PatternData pat){
        origin = root;
        data = pat;
    }
    public override void tick(float timeElapsed){
        // Continuous rotation 
        origin.transform.Rotate(Vector3.forward * Time.deltaTime * data.speed);
    }
}

public class ZigZag : Pattern{
    public ZigZag(GameObject root, PatternData pat){
        origin = root;
        data = pat;
    }
    public override void tick(float timeElapsed){
        // Ocelating rotation
        origin.transform.Rotate(Vector3.forward * Time.deltaTime * data.speed * Mathf.Sin(timeElapsed));
    }
}