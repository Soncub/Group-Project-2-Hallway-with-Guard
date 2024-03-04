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
            Cursor.lockState = CursorLockMode.None;
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
            FindObjectOfType<AudioManager>().Play("GameOver");
        }
    }
}
