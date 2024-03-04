using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateText : MonoBehaviour
{
    public EnemyAI guard;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (guard.playerInSightRange == true)
        {
            text.text = "Guard State: No sweets for you!";
        }
        else
        {
            text.text = "Guard State: Searching!";
        }
    }
}
