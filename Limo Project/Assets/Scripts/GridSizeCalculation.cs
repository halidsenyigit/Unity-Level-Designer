using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSizeCalculation : MonoBehaviour {

    public GameObject gridSizeObject;
    public Transform gridParent;

    const float gridUnit = 5;
    void Start () {
        for (int i = -1; i < 19; i++) {
            GameObject go = Instantiate(gridSizeObject, gridParent);
            go.transform.position = new Vector3(gridUnit * i, -5, 0);
            go.GetComponentInChildren<Text>().text = (gridUnit * i).ToString();
            go.name = "X > " + (gridUnit * i).ToString();


            GameObject goTop = Instantiate(gridSizeObject, gridParent);
            goTop.transform.position = new Vector3(gridUnit * i, 5, 0);
            goTop.GetComponentInChildren<Text>().text = (gridUnit * i).ToString();
            goTop.name = "X > " + (gridUnit * i).ToString();
        }

        for (int i = -5; i < 7; i++) {
            GameObject go = Instantiate(gridSizeObject, gridParent);
            go.transform.position = new Vector3(-9.7f, i, 0);
            go.GetComponentInChildren<Text>().text = i.ToString();
            go.GetComponentInChildren<Text>().color = Color.red;
            go.name = "Y > " + i.ToString();
        }
    }

}
