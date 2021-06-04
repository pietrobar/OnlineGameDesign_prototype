using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private int countPlayer;
    private GameObject endLevelPanel;

    // Start is called before the first frame update
    void Start()
    {
        countPlayer = 0;
        endLevelPanel = GameManager.instance.endLevelPanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
        if (other.tag == "Player")
        {
            countPlayer++;
            if (countPlayer == players.Length)
            {
                GameManager.inGame = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                endLevelPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            countPlayer--;
    }
}
