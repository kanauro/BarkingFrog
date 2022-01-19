using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = 9.81f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    public Vector3 Drag;

    private CharacterController _controller;
    //private Vector3 _velocity;
    private bool _isGrounded = true;
    private bool dir_left = true;
    private int jump = 0;
    private Transform _groundChecker;

    private Animator animator;
    private List<string> items;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform;
        animator = GetComponent<Animator>();
        items = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        float dir = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
            if (dir > 0) dir *= -1;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            if (dir < 0) dir *= -1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
        {
            animator.SetBool("isJumping", true);
            jump = 1;
            //_velocity.y = JumpHeight;
        }
        Vector3 move = new Vector3(dir * Speed * Time.deltaTime, 0, JumpHeight * jump);
        print(move);
        _controller.Move(move);
        jump = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1.1f); //debug
        animator.SetBool("isRunning", Input.GetAxisRaw("Horizontal") != 0);
        animator.SetBool("isJumping", !_isGrounded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("detail"))
        {
            string itemType = other.gameObject.GetComponent<CollectableScript>().itemType;
            items.Add(itemType);
            print(items.Count);
            Destroy(other.gameObject);
        }
    }
}
