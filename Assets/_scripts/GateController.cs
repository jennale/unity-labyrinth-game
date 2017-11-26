using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {
    public int RotateToOpen = 90;
    public bool opened = false;
    public int requiresKeys = 1;
    private float rotated = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (opened) {
            if ((int)rotated < RotateToOpen) {
				transform.Rotate(0, 5, 0);
                rotated += 5f;
                Debug.Log(rotated);
            }
        }
	}

    public void Unlock() {
        opened = true;
    }
}
