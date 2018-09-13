using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanState : MonoBehaviour {
    private bool state = false;
    public bool get(){
        return state;
    }
    public void set(bool setter){
        state = setter;
    }
    public void on(){
        state = true;
    }
    public void off(){
        state = false;
    }
}