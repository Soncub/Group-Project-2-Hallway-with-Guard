using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caught : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            Debug.Log("Worked");
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
        }
    }
}
