using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isControllingAnAnimal;
    GameObject gameManager;
    //public float rayCastRadius;
    public float rayCastRange;
    private Transform previousSelection;
    InputDeviceCharacteristics rightHandDevice;
    private InputDevice targetDevice;

    public GameObject rightHand;
    private int Aimed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        isControllingAnAnimal = false;
        Aimed = 0;

        // Setup for VR
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevices(devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<PossessionPower>().resetPreviousSelectionHighlight(previousSelection);
        Aimed = gameObject.GetComponent<PossessionPower>().LaunchRayCast(rightHand, rayCastRange, ref previousSelection);
    }

    private void OnTrigger()
    {
        if (!isControllingAnAnimal)
        {
            // If the player is aiming at the rat and he presses Left Click, then we control the rat
            if (Aimed == 1)
            {
                // We reset the highlight of the rat
                gameObject.GetComponent<PossessionPower>().resetPreviousSelectionHighlight(previousSelection);
                gameManager.GetComponent<GameManager>().ChangeStatus(1);
                gameManager.GetComponent<GameManager>().SwitchPlayerRat();
                isControllingAnAnimal = true;
            }
        }
        else if (isControllingAnAnimal)
        {

            isControllingAnAnimal = false;
            gameManager.GetComponent<GameManager>().ChangeStatus(0);
            gameManager.GetComponent<GameManager>().SwitchPlayerRat();
        }
    }

    

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(rightHand.transform.position, rightHand.transform.position + rightHand.transform.forward * rayCastRange);
        Gizmos.DrawWireSphere(rightHand.transform.position + rightHand.transform.forward * rayCastRange, rayCastRadius);
    }*/
}
