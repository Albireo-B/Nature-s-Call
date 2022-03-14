using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject rat;
    public bool playerStatus;
    private bool ratStatus;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rat = GameObject.FindGameObjectWithTag("Rat");
        playerStatus = true;
        ratStatus = false;
    }

    public void ChangeStatus(int activeStatus)
    {
        /**
         * 0 : player active
         * 1 : Rat is active
         */
        if (activeStatus == 0)
        {
            playerStatus = true;
            ratStatus = false;
            return;
        }
        if (activeStatus == 1)
        {
            playerStatus = false;
            ratStatus = true;
        }
    }

    public void SwitchPlayerRat()
    {
        // Player's camera
        player.transform.GetChild(0).GetChild(0).gameObject.SetActive(playerStatus);

        // Rat's camera
        rat.transform.parent.GetChild(0).gameObject.SetActive(ratStatus);
    }
}
