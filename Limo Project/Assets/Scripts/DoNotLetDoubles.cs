using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotLetDoubles : MonoBehaviour {

    public bool isTriggerWithAnyObjects;

    private void OnTriggerStay (Collider other) {
        if (other.transform.tag == "Monster" ||
               other.transform.tag == "Coin" ||
               other.transform.tag == "Meteor" ||
               other.transform.tag == "Box") {
            isTriggerWithAnyObjects = true;
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.transform.tag == "Monster" ||
               other.transform.tag == "Coin" ||
               other.transform.tag == "Meteor" ||
               other.transform.tag == "Box") {
            isTriggerWithAnyObjects = false;
        }
    }
}
