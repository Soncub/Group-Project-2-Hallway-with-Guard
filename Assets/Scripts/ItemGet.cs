using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemGet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Macguffin")
        {
            Debug.Log("Worked");
            UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
        }
    }
}
