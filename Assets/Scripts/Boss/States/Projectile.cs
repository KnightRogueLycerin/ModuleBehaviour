using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProjectileData{
    // Time to fire
    public float cooldown;
    // Bullet types
    public GameObject small;
    public GameObject large;
}

public abstract class Projectile : State {
    protected ProjectileData data;
    protected float realod = 0f;
}

public class Small : Projectile{
    public Small(GameObject root, ProjectileData weaponery){
        origin = root;
        data = weaponery;
    }
    public override void tick(float timeElapsed){
        // ...
        realod += Time.deltaTime;
        if(realod >= data.cooldown){
            realod = 0f;
            origin.GetComponent<BulletSpawner>().shoot(data.small, origin.transform);
        }
    }
}

public class Large : Projectile{
    public Large(GameObject root, ProjectileData weaponery){
        origin = root;
        data = weaponery;
    }
    public override void tick(float timeElapsed){
        // ...
        realod += Time.deltaTime;
        if (realod >= data.cooldown){
            realod = 0f;
            origin.GetComponent<BulletSpawner>().shoot(data.large, origin.transform);
        }
    }
}
