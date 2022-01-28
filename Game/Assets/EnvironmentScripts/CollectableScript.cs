using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public string itemType;
    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(0f, 0.5f, 0f);
    }
}
