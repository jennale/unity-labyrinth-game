using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Player object
	private Rigidbody rb;
	private Animator anim; //Reference the Animator component
	GameObject[] pickups;
    public const float WalkSpeed = 2f; //Making values public puts them in the Unity inspector, can set defaults
    public const float RunSpeed = 4f;
    private const float RotateSpeed = 100f;


    //Timer / score
    private bool gameStarted = false;
    private bool winStatus = false;
    private float score = 0.0f;
    public Text scoreText;

    //UI objects
    public GameObject endScreen;
    public GameObject activeUI;


    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		pickups = GameObject.FindGameObjectsWithTag ("Pick Up");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame, runs along with rendering
	void Update () {
        if (gameStarted) {
            score += Time.deltaTime;

            scoreText.text = "Score: " + score.ToTimestamp();
        }
	}

		
	// FixedUpdate fires each physics update
	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Reset ();
		}

		bool isRunning = Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift);
        HandleMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), isRunning);
	}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliding!");

        //START TIMER
        if (other.gameObject.CompareTag("StartTimer") && !gameStarted)
        {
            StartGame();
        }


        //END TIMER, END GAME
        if (other.gameObject.CompareTag("EndTimer") && gameStarted)
        {
            winStatus = true;
            EndGame();
        }
    }

    void EndGame() {
        gameStarted = false;
        endScreen.SetActive(true);

        EndGameController.EndScore endScore = new EndGameController.EndScore();

        endScore.score = this.score;
        endScore.winStatus = this.winStatus;

        endScreen.SendMessage("ToggleEndGame", endScore);
    }

    void StartGame() {
        gameStarted = true;

    }

    void HandleMovement(float HorizontalInput, float VerticalInput, bool isRunning) {
        float speed = (isRunning) ? RunSpeed : WalkSpeed;

        var x = HorizontalInput * Time.deltaTime * RotateSpeed;
        var z = VerticalInput * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        AnimateMovement(x, z, isRunning);
    }

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
}
