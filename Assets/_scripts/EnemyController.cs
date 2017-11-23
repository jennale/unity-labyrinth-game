using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private const float RotateSpeed = 100f;
    //private int rotateTo

	// Use this for initialization
	void Start () {
		InvokeRepeating("RandomlyTurn", 5.0f, 5.0f);
        
    }
    
    // Update is called once per frame
    void Update () {
	}

    int RandomlyTurn () {
        var x = (int)Random.Range(0.0f, 4.0f) * 90;
        //transform.Rotate(0, x, 0);
        return x;
    }
}
