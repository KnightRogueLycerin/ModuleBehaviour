using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    [Header("Bullet Settings")]
    [SerializeField]
    public float speed = 10f;
    public float lifetime = 15f;
    private float elapsedTime = 0f;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= lifetime){
            Destroy(gameObject);
        }
    }
}
