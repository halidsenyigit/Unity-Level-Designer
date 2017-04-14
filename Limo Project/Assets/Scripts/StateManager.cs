using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {

    public static StateManager instance { get; set; }
    public Text currStateText;
    public GameObject errorHandle;
    States currentState;

    float currentTime = 0;
    public Text[] objectCounts;

    public ObjectTypes createObjectType;

    void Start () {
        instance = this;
        currentState = States.Nothing;
        currentTime = Time.time;
    }

    void Update () {
        switch (currentState) {
            case States.Create:

                break;
            case States.Delete:

                break;
            case States.Move:

                break;
            case States.Nothing:

                break;
            default:
                break;
        }

        if(Time.time - currentTime > 1) {
            // update somethings every one second=> for performance
            objectCounts[0].text = "Monsters: " + GameObject.FindGameObjectsWithTag("Monster").Length;
            objectCounts[1].text = "Coins: " + GameObject.FindGameObjectsWithTag("Coin").Length;
            objectCounts[2].text = "Meteors: " + GameObject.FindGameObjectsWithTag("Meteor").Length;
            objectCounts[3].text = "Boxes: " + GameObject.FindGameObjectsWithTag("Box").Length;
            currentTime = Time.time;
        }

    }

    public void ShowError () {
        errorHandle.GetComponent<Dissapear>().last = Time.time;
        errorHandle.SetActive(true);
    }

    public void ChangeCurrentOperationState (States state) {
        currentState = state;

        switch (state) {
            case States.Create:
                currStateText.text = "Create";
                break;
            case States.Delete:
                currStateText.text = "Delete";
                break;
            case States.Move:
                currStateText.text = "Move";
                break;
            case States.Save:
                currStateText.text = "Save";
                break;
            case States.Load:
                currStateText.text = "Load";
                break;
            case States.Nothing:
                currStateText.text = "Nothing";
                break;
            default:
                break;
        }
    }

    public States GetCurrentState () {
        return currentState;
    }
}

public enum States {
    Create,
    Delete,
    Move,
    Save,
    Load,
    Nothing
}
