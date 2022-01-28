using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, parallaxEffect;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        parallaxEffect = (9 - GetComponent<SpriteRenderer>().sortingOrder)*0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
