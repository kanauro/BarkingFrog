using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch: MonoBehaviour
{
    public string sceneToLoad;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            print("ook");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
