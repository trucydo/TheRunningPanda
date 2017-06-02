using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
	public float speedMultiplier; //Toc do tang dan

	public float speedIncreaseMilestone; //Milestone tang dan
	private float speedMilestoneCount;

	//GameManager
	private float moveSpeedStore;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;

    public float jumpForce;

	public float jumpTime; //tgian Character tiep tuc nhay
	private float jumpTimeCounter;

	private bool stoppedJumping;
	private bool canDoubleJump; //Khi cham dat, dc double jump

	private Rigidbody2D myRigidbody;


	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

    // Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> (); // Tim Rigidbody gan voi Character

		//myCollider = GetComponent<Collider2D> (); // Tim Collider gan voi Character

		myAnimator = GetComponent<Animator> (); // Tim Animator gan voi Character
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
		//GameManager
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCountStore;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Kiem tra nhan vat co dang tren mat dat khong (true)
		//grounded = Physics2D.IsTouchingLayers(myCollider,whatIsGround); //nhan vat va dat
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed + speedMultiplier;
		}

		// Vector 2 --> Vector (x,y) giu nhan vat chay 2d
		myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);

		// Neu nhap nut Z hoac nhap chuot trai (dung de test) hoac *nhap vao icon JUMP*
		if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
		{
			if(grounded)//Neu cham dat thi moi nhay
			{ 
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce); //Giu toa do x, nang y de nhay
				stoppedJumping = false;
				jumpSound.Play ();
			}
			// Kiem tra double jump
			if (!grounded && canDoubleJump) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce); //Giu toa do x, nang y de nhay
				jumpTimeCounter = jumpTime; //Set thoi gian tren khong
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play ();
			}
		}
		// Neu nut bam van dang duoc nhan
		if ((Input.GetKey(KeyCode.Z) || Input.GetMouseButton(0)) && !stoppedJumping)
		{
			if (jumpTimeCounter > 0)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Z) || Input.GetMouseButtonUp(0))
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool("Grounded",grounded);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox")
		{
			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
		}
	}
}
