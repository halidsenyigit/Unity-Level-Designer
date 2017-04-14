using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    public GameObject transparentCursor;
    public GameObject objects;
    public Material[] materials;

    GameObject transparentInstance;

    Vector3 mousePosition;
    Vector3 objPos;

    void Start () {
        objPos = new Vector3();
        mousePosition = new Vector3();
    }

    // Update is called once per frame
    void Update () {
        if (StateManager.instance.GetCurrentState() != States.Create) {
            if (transparentInstance != null)
                Destroy(transparentInstance.gameObject);
            return;
        }

        if (transparentInstance == null) {
            mousePosition = Input.mousePosition;
            mousePosition.z = 2;
            objPos = Camera.main.ScreenToWorldPoint(mousePosition);
            transparentInstance = Instantiate(transparentCursor, objPos, Quaternion.identity);
        } else {
            mousePosition = Input.mousePosition;
            mousePosition.z = 2;
            objPos = Camera.main.ScreenToWorldPoint(mousePosition);
            objPos.x = Mathf.FloorToInt(objPos.x * 100) / 100;
            objPos.y = Mathf.FloorToInt(objPos.y * 100) / 100;
            transparentInstance.transform.position = objPos;

            if (Input.GetMouseButtonDown(0)) {
                // create object
                CreateObj();
            } else if (Input.GetMouseButtonDown(1)) {
                // cancel the create operation
                Cancel();
            }
        }
    }

    void Cancel () {
        StateManager.instance.ChangeCurrentOperationState(States.Nothing);
        if (transparentInstance != null)
            Destroy(transparentInstance.gameObject);
    }

    void CreateObj () {
        if (transparentInstance.GetComponent<DoNotLetDoubles>().isTriggerWithAnyObjects)
            return;


        GameObject obj = Instantiate(objects);
        obj.transform.position = transparentInstance.transform.position;
        obj.transform.rotation = Quaternion.identity;

        switch (StateManager.instance.createObjectType) {
            case ObjectTypes.Monster:
                obj.transform.tag = "Monster";
                obj.GetComponent<Renderer>().material = materials[3];
                obj.transform.name = "monster";
                break;
            case ObjectTypes.Coin:
                obj.transform.tag = "Coin";
                obj.GetComponent<Renderer>().material = materials[1];
                obj.transform.name = "Coin";
                break;
            case ObjectTypes.Meteor:
                obj.transform.tag = "Meteor";
                obj.GetComponent<Renderer>().material = materials[2];
                obj.transform.name = "Meteor";
                break;
            case ObjectTypes.Box:
                obj.transform.tag = "Box";
                obj.GetComponent<Renderer>().material = materials[0];
                obj.transform.name = "Box";
                break;
            default:
                break;
        }
    }
}
