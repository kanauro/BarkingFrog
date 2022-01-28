using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject left;
    public GameObject right;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start() => offset = this.transform.position - player.transform.position;

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null &&
            !(left != null && left.transform.position.x - left.GetComponent<SpriteRenderer>().bounds.size.x / 2 >
               player.transform.position.x - GetComponent<Camera>().orthographicSize*2) &&
            !(right != null && right.transform.position.x + right.GetComponent<SpriteRenderer>().bounds.size.x / 2 <
              player.transform.position.x + GetComponent<Camera>().orthographicSize*2))
        {
            this.transform.position = offset + player.transform.position;
        }

        this.transform.position = new Vector3(this.transform.position.x, (offset + player.transform.position).y,
            this.transform.position.z);
    }
}
