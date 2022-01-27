using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rigg;
/*    Health healthScript = otherGameObject.GetComponent<Health>();*/
    // Start is called before the first frame update
    void Start()
    {
        rigg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(speed, 0f, 0f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            speed *= -1;
        }
/*        if (other.gameObject.tag == "Player")
        {
            healthScript.damageHealth(10);
        }*/
    }
}
