using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Vector3 mPos;
    Vector3 firstPosition;

    GameObject obj;

    bool isMoving = false;


    void Start () {

    }

    void Update () {
        if (StateManager.instance.GetCurrentState() != States.Move)
            return;

        if (Input.GetMouseButtonDown(0) && isMoving) {
            FinishMoving();
            return;
        }

        if (obj == null) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10) && Input.GetMouseButtonDown(0)) {
                if (hit.transform.tag == "Meteor" ||
                   hit.transform.tag == "Monster" ||
                   hit.transform.tag == "Coin" ||
                   hit.transform.tag == "Box") {
                    obj = hit.transform.gameObject;
                    firstPosition = obj.transform.position;
                    isMoving = true;
                }

            }
        }


        if (obj == null)
            return;

        mPos = Input.mousePosition;
        mPos.z = 2;
        obj.transform.position = Camera.main.ScreenToWorldPoint(mPos);

        obj.transform.position = new Vector3(
            Mathf.FloorToInt(obj.transform.position.x * 100) / 100,
            Mathf.FloorToInt(obj.transform.position.y * 100) / 100,
            obj.transform.position.z);


        if (Input.GetMouseButtonDown(1)) {
            Cancel();
        }

    }

    void FinishMoving () {
        isMoving = false;
        obj = null;
    }

    void Cancel () {
        obj.transform.position = firstPosition;
        obj = null;
        isMoving = false;
    }
}
