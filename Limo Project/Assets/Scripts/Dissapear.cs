using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour {

    public float last = 0;
	// Use this for initialization
	void Start () {
        last = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - last > 2) {
            gameObject.SetActive(false);
            last = Time.time;
        }
	}
}
