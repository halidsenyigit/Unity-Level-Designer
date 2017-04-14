using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (StateManager.instance.GetCurrentState() != States.Delete)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10) && Input.GetMouseButtonDown(0)) {
            if (hit.transform.tag == "Meteor" ||
                hit.transform.tag == "Monster" ||
                hit.transform.tag == "Coin" ||
                hit.transform.tag == "Box") {

                Destroy(hit.transform.gameObject);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            StateManager.instance.ChangeCurrentOperationState(States.Nothing);
        }

    }
}
