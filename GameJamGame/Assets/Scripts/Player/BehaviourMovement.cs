using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody),typeof(AudioSource))]
public class BehaviourMovement : MonoBehaviour {

    [Range(1, 10)]
    public float Speed = 5f;
    [Range(1, 10)]
    public float JumpHeight = 2f;
	public float GroundDistance = 0.2f;
	//public float DashDistance = 5f;
	public LayerMask Ground;
    public Transform groundCheck;
    public AudioClip jumpSound;
    Animator anim;

	private Rigidbody rb;
	private Vector3 _inputs = Vector3.zero;	
	private bool _isGrounded = true;
    private bool isJumping = false;
	//private Transform groundChecker;
    private int max_jumps;

	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody> ();
        
		//groundChecker = transform.GetChild (0);
	}

    void Update()
    {
        _isGrounded = Physics.Linecast(transform.position, groundCheck.position, 1<< LayerMask.NameToLayer("Ground"));


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        Animation(_inputs.x);
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && max_jumps > 0)
        {
            isJumping = true;
        }
        if (_isGrounded) {
            max_jumps = 2;
        }
       // if (Input.GetButtonDown("Dash"))
        //{
         //   Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
           // rb.AddForce(dashVelocity, ForceMode.VelocityChange);
        //}

       }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + _inputs * Speed * Time.fixedDeltaTime);
        if (isJumping) {
            _isGrounded = true;
            anim.SetTrigger("isJumping");
            max_jumps--;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            GetComponent<AudioSource>().PlayOneShot(jumpSound);
            rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            _isGrounded = false;
            isJumping = false;
        }
    }

    void Animation(float x)
    {
        if (x != 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("isIdle", true);
        }

    }


}
