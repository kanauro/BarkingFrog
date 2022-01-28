using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float jumpHeight = 10f;
    public float groundDistance = 0.2f;
    public LayerMask ground;
    
    private bool _isGrounded = true;
    private int _isRunning = 0;
    private int _direction = -1;
    private int _jump = 0;
    private Transform _groundChecker;

    private Animator _animator;
    private List<string> _items;
    private Rigidbody _rigidbody;
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    void Start()
    {
        _groundChecker = transform;
        _animator = GetComponent<Animator>();
        _items = new List<string>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);

        float x = 0;
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
            _direction = -1;
            _isRunning += 1;
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            _direction = 1;
            _isRunning += 1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) 
        {
            _isRunning -= 1;
        }
        if (_isRunning > 0)
        {
            x = _direction * speed * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + new Vector3(x, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _animator.SetBool(IsJumping, true);
            _rigidbody.AddForce(transform.up * jumpHeight);
        }
        _animator.SetBool(IsRunning, _isRunning > 0);
        _animator.SetBool(IsJumping, !_isGrounded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemTag"))
        {
            string itemType = other.gameObject.GetComponent<CollectableScript>().itemType;
            _items.Add(itemType);
            Destroy(other.gameObject);
        }
       
    }
}
