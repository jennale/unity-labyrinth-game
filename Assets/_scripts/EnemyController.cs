using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private const float RotateSpeed = 100f;
    private int rotateRange;
    private int rotated = 0;
    public bool isMoving = false;

    private GameObject spotted;

    //private Collider collider;

	// Use this for initialization
	void Start () {
        InvokeRepeating("RandomlyTurn", (int)UnityEngine.Random.Range(0.0f, 5.0f), 5.0f);
        spotted = GameObject.Find("Spotted");

        spotted.SetActive(false);
    }
    
    // Update is called once per frame
    void Update () {
        isMoving = false;
        Rotate();
	}

    void RandomlyTurn () {
        rotateRange = (int)UnityEngine.Random.Range(-4.0f, 4.0f) * 90;
        rotated = 0;
    }

    void Rotate () {
        if (Math.Abs(rotated) < Math.Abs(rotateRange)) {
            int rotateSpeed = 10;
            if (rotateRange < 0) {
                rotateSpeed = rotateSpeed * -1;
            } else {
                
            }
            rotated+= Mathf.Abs(rotateSpeed);
            transform.Rotate(0, rotateSpeed, 0);
            isMoving = true;
        }
    }

    void Spotted() {
        spotted.SetActive(true);
    }
}
