using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    [Header("Colors")]
    [SerializeField]
    public Color OnColor;
    public Color OffColor;

    [Header("Buttons")]
    [SerializeField]
    public List<GameObject> panel = new List<GameObject>();

    private bool uncheckedId;
    public bool newId(){
        if (uncheckedId){
            bool awnser = uncheckedId;
            uncheckedId = false;
            return awnser;
        }
        return uncheckedId;
    }
    private string selfIdientity = null;
    public string getIdentity()
    {
        return selfIdientity;
    }
    private string activeIdientity = null;
    public string getActiveID(){
        return activeIdientity;
    }

    private void Start(){
        // Get own ID
        selfIdientity = gameObject.GetComponent<ButtonIdentity>().get();
        // Turn on a random button
        panel[Random.Range(0,panel.Count)].GetComponent<BooleanState>().on();
        panelUpdate();
    }
    public void resetPanel(){
        // Set entire panel to off
        foreach(GameObject go in panel){
            go.GetComponent<BooleanState>().off();
        }
    }
    public void panelUpdate(){
        // Uppdate panel, send signals
        foreach (GameObject go in panel)
        {
            if (go.GetComponent<BooleanState>().get())
            {
                // Button is on
                go.GetComponent<Image>().color = OnColor;
                activeIdientity = go.GetComponent<ButtonIdentity>().get();
                uncheckedId = true;
            }
            else
            {
                // Button is off
                go.GetComponent<Image>().color = OffColor;
            }
        }
    }
}
