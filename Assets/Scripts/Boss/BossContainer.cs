using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContainer : MonoBehaviour {
    [Header("Controls")]
    private State Movement;
    [SerializeField]
    MovementData MoveControls;

    private State Pattern;
    [SerializeField]
    PatternData PatternControl;

    private State Projectile;
    [SerializeField]
    ProjectileData ProjectileControl;

    [Header("Controls")]
    [SerializeField]
    public List<ButtonManager> controllers = new List<ButtonManager>();

    // Time tracking
    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update () {
        checkChange();
        elapsedTime += Time.deltaTime;
        tick();
    }
    private void tick(){
        Movement.tick(elapsedTime);
        Pattern.tick(elapsedTime);
        Projectile.tick(elapsedTime);
    }
    private void checkChange(){
        foreach (ButtonManager bm in controllers)
        {
            if (bm.newId())
            {
                // Something have changed!
                if (bm.getIdentity() == "Movement")
                {
                    changeMovement(bm.getActiveID());
                }
                else if (bm.getIdentity() == "Pattern")
                {
                    changePattern(bm.getActiveID());
                }
                else if (bm.getIdentity() == "Projectile")
                {
                    changeProjectile(bm.getActiveID());
                }
            }
        }
    }
    private void changeMovement(string to){
        if(to == "Wave"){
            Movement = new Wave(gameObject, MoveControls);
        }else if (to == "Tangent"){
            Movement = new Tangent(gameObject , MoveControls);
        }else{
            // Something went wrong, state not defined!
            Debug.Log("Undefined movement state: " + to);
            Debug.Break();
        }
        Debug.Log("New movement: " + to);
    }
    private void changePattern(string to){
        if (to == "Static"){
            Pattern = new Static(gameObject, PatternControl);
        }else if (to == "Spiral"){
            Pattern = new Spiral(gameObject, PatternControl);
        }else if (to == "Zig-Zag"){
            Pattern = new ZigZag(gameObject, PatternControl);
        }else {
            // Something went wrong, state not defined!
            Debug.Log("Undefined pattern state: " + to);
            Debug.Break();
        }
        Debug.Log("New pattern: " + to);
    }
    private void changeProjectile(string to){
        if (to == "Small"){
            Projectile = new Small(gameObject, ProjectileControl);
        }else if (to == "Large"){
            Projectile = new Large(gameObject, ProjectileControl);
        }else{
            // Something went wrong, state not defined!
            Debug.Log("Undefined projectile state: " + to);
            Debug.Break();
        }
        Debug.Log("New projectile: " + to);
    }
}
