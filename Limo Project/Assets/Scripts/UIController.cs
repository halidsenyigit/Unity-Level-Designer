using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text currentOperationText;

    public InputField fileLocation;
    public InputField loadFileLocation;

    public GameObject savePanel;
    public GameObject loadPanel;

    public Button[] buttons; // to enable or disable while we are in saving panel

    public Material[] objMaterials;
    public GameObject objects;

    public void OnCreateButtonsClicked (int id) {
        switch (id) {
            case 1:
                // monster clicked
                StateManager.instance.createObjectType = ObjectTypes.Monster;
                break;

            case 2:
                // box clicked
                StateManager.instance.createObjectType = ObjectTypes.Box;
                break;

            case 3:
                // coin clicked
                StateManager.instance.createObjectType = ObjectTypes.Coin;
                break;
            case 4:
                // meteor clicked
                StateManager.instance.createObjectType = ObjectTypes.Meteor;
                break;
        }


        StateManager.instance.ChangeCurrentOperationState(States.Create);
    }


    public void OnMoveButtonClicked () {
        StateManager.instance.ChangeCurrentOperationState(States.Move);
    }

    public void OnDeleteButtonClicked () {
        StateManager.instance.ChangeCurrentOperationState(States.Delete);
    }

    // load actions
    public void OnLoadButtonClicked () {
        StateManager.instance.ChangeCurrentOperationState(States.Load);
        if (!loadPanel.activeInHierarchy) {
            loadPanel.SetActive(true);
            foreach (var button in buttons) {
                button.interactable = false;
            }
        }
    }

    public void LoadOnCancelButtonClicked () {
        loadFileLocation.text = "";
        loadPanel.SetActive(false);
        foreach (var button in buttons) {
            button.interactable = true;
        }

        StateManager.instance.ChangeCurrentOperationState(States.Nothing);
    }

    public void LoadOnOpenButtonClicked () {
        if (loadFileLocation.text == "")
            return;
        Helper h = new Helper();
        List<XmlModel> list = h.DeserializeXML(Application.dataPath + "/" + loadFileLocation.text + ".xml");
        foreach (var obj in list) {
            Material m = objMaterials[0];
            string uname = "";
            switch (obj.ObjectType) {
                case ObjectTypes.Monster:
                    m = objMaterials[0];
                    uname = "Monster";
                    break;
                case ObjectTypes.Coin:
                    m = objMaterials[1];
                    uname = "Coin";
                    break;
                case ObjectTypes.Meteor:
                    m = objMaterials[2];
                    uname = "Meteor";
                    break;
                case ObjectTypes.Box:
                    m = objMaterials[3];
                    uname = "Box";
                    break;
                default:
                    break;
            }

            foreach (var item in obj.Location) {
                GameObject g = Instantiate(objects);
                g.transform.position = new Vector3(item.X, item.Y, 0);
                g.GetComponent<Renderer>().material = m;
                g.transform.name = uname;
                g.transform.tag = uname;
            }
        }

        loadFileLocation.text = "";
        loadPanel.SetActive(false);
        foreach (var button in buttons) {
            button.interactable = true;
        }
        StateManager.instance.ChangeCurrentOperationState(States.Nothing);
    }

    // load actions
    // save actions
    public void OnSaveButtonClicked () {
        StateManager.instance.ChangeCurrentOperationState(States.Save);
        if (!savePanel.activeInHierarchy) {
            savePanel.SetActive(true);
            foreach (var button in buttons) {
                button.interactable = false;
            }
        }
    }

    public void OnSaveFileClicked () {
        Helper h = new Helper();


        List<XmlModel> model = new List<XmlModel>();
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");


        /////////////////////////////////////////////////// BOXES

        List<Vector2D> boxLocations = new List<Vector2D>();
        foreach (var box in boxes) {
            boxLocations.Add(new Vector2D() {
                X = box.transform.position.x,
                Y = box.transform.position.y
            });
        }
        model.Add(new XmlModel() {
            ObjectType = ObjectTypes.Box,
            Location = boxLocations
        });

        /////////////////////////////////////////////////// METEORS

        List<Vector2D> meteorLocations = new List<Vector2D>();
        foreach (var meteor in meteors) {
            meteorLocations.Add(new Vector2D() {
                X = meteor.transform.position.x,
                Y = meteor.transform.position.y
            });
        }
        model.Add(new XmlModel() {
            ObjectType = ObjectTypes.Meteor,
            Location = meteorLocations
        });

        /////////////////////////////////////////////////// MONSTERS

        List<Vector2D> monsterLocations = new List<Vector2D>();
        foreach (var monster in monsters) {
            monsterLocations.Add(new Vector2D() {
                X = monster.transform.position.x,
                Y = monster.transform.position.y
            });
        }
        model.Add(new XmlModel() {
            ObjectType = ObjectTypes.Monster,
            Location = monsterLocations
        });

        /////////////////////////////////////////////////// COINS

        List<Vector2D> coinLocations = new List<Vector2D>();
        foreach (var coin in coins) {
            coinLocations.Add(new Vector2D() {
                X = coin.transform.position.x,
                Y = coin.transform.position.y
            });
        }
        model.Add(new XmlModel() {
            ObjectType = ObjectTypes.Coin,
            Location = coinLocations
        });

        if (model.Count == 0)
            return;

        string xml = h.CreateXML(model);

        if (h.SaveFile(Application.dataPath + "/" + fileLocation.text + ".xml" , xml)) {
            fileLocation.text = "";
            savePanel.SetActive(false);
            foreach (var button in buttons) {
                button.interactable = true;
            }
        }
        StateManager.instance.ChangeCurrentOperationState(States.Nothing);
    }

    public void OnCancelSavingClicked () {
        fileLocation.text = "";
        savePanel.SetActive(false);
        foreach (var button in buttons) {
            button.interactable = true;
        }

        StateManager.instance.ChangeCurrentOperationState(States.Nothing);
    }
    // save actions //


    public void OnClearButtonClicked () {
        foreach (var item in GameObject.FindGameObjectsWithTag("Monster")) {
            Destroy(item.gameObject);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Coin")) {
            Destroy(item.gameObject);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Meteor")) {
            Destroy(item.gameObject);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Box")) {
            Destroy(item.gameObject);
        }
    }

    public void OnExitButtonClicked () {
        Application.Quit();
    }
}
