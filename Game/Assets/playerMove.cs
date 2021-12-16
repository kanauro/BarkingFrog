using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    public float jumph;
    public float jumpforce;
    private Vector3 jump;
    private Rigidbody rigg;
    private bool is_grounded;
    private bool dir_left = true;

    public List<string> items;

    void Start()
    {
        items = new List<string>();
        jump = new Vector3(0f, jumph, 0f);
        rigg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && is_grounded)
        {
            rigg.AddForce(jump * jumpforce, ForceMode.Impulse);
            is_grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir_left = false;
            transform.rotation = new Quaternion(0f, 180, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir_left = true;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -1.1f); //debug
        if (dir_left)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        } else
        {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            is_grounded = true;
        }
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        if (!dir_left) move = -move;
        transform.Translate(move, 0f, 0f);
        transform.Rotate(-transform.rotation.x, 0f, -transform.rotation.z);  //debug
    }
}
