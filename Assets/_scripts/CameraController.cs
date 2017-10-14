using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;


	// Use this for initialization
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	/// <summary>
	/// Update this instance. (Once per frame)
	/// </summary>
	void Update () {
	}
		
	/// <summary>
	/// Runs at end of update, makes sure user has moved before moving cam
	/// </summary>
	void LateUpdate() {
		transform.position = player.transform.position + offset;			
	}
}
	