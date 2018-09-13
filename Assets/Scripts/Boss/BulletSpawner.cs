using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public void shoot(GameObject projectile, Transform origin){
        GameObject go = Instantiate(
            projectile,
            origin.transform.position,
            origin.transform.rotation 
            );
    }
}
