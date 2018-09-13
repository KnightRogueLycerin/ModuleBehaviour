using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIdentity : MonoBehaviour {
    [Header("State call")]
    [SerializeField]
    private string identity = "State";

    // Use this for initialization
    void Awake () {
        gameObject.GetComponentInChildren<Text>().text = identity;
	}
	public string get(){
        return identity;
    }
}
