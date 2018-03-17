using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BehaviourMovement : MonoBehaviour {

    [Range(1, 10)]
    public float Speed = 5f;
    [Range(1, 10)]
    public float JumpHeight = 2f;
	public float GroundDistance = 0.2f;
	public float DashDistance = 5f;
	public LayerMask Ground;
    Animator anim;

	private Rigidbody rb;
	private Vector3 _inputs = Vector3.zero;	
	private bool _isGrounded = true;
	private Transform groundChecker;


	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody> ();

		groundChecker = transform.GetChild (0);
	}

    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        Animation(_inputs.x);
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = true;
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            _isGrounded = false;
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
