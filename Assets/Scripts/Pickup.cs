using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickupAble; // The item to pick up
    public GameObject pickupText; // The text to display when the player can pick up the item
    public GameObject panelSuperado; //Panel de victoria
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                pickupAble.SetActive(false);
                pickupText.SetActive(false);
                panelSuperado.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupText.SetActive(false);
        }
    }
}
