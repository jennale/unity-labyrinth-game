using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
	
	private Rigidbody rb;
	private float startX;
	private float startY;
	public float walkSpeed = 2f; //Making values public puts them in the Unity inspector, can set defaults
	public float runSpeed = 4f;
	private float rotateSpeed = 100f;
	private int score = 0;
	public Text scoreText;
	Animator anim; //Reference the Animator component
	GameObject[] pickups;

	//Awake is similar to start, gets called whether script is enabled or not, good for references
	void Awake()
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		pickups = GameObject.FindGameObjectsWithTag ("Pick Up");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame, runs along with rendering
	void Update () {
	}
		
	// FixedUpdate fires each physics update
	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Reset ();
		}

		bool isRunning = Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift);
		float speed = (isRunning) ? runSpeed : walkSpeed;

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		AnimateMovement (x, z, isRunning );

	}

	/// <summary>
	/// Reset this instance.
	/// </summary>
	void Reset() {
		transform.rotation = new Quaternion (0, 0, 0, 0);
		transform.position = new Vector3(0, 0, 0);

		foreach (GameObject pickup in pickups)
		{
			pickup.SetActive (true);
		}
	}

	/// <summary>
	/// Animates the movement.
	/// </summary>
	/// <param name="h">The horizontal movement.</param>
	/// <param name="v">The vertical movement</param>
	/// <param name="running">If set to <c>true</c> running.</param>
	void AnimateMovement(float h, float v, bool running)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);

		if (v < 0f)
			running = false;
		else
			running = walking && running;
		
		anim.SetBool ("IsRunning", running);
	}
		
	/// <summary>
	/// Raises the trigger enter event upon collisions.
	/// </summary>
	/// <param name="other">Other object's collider</param>
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			score++;
			scoreText.text = "Score: " + score;
		}
	}
}
