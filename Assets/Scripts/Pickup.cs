using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickupAble; // The item to pick up
    public GameObject pickupText; // The text to display when the player can pick up the item
    // Start is called before the first frame update

        // Range for random spawn positions in global coordinates
    public Vector3 spawnRangeMin = new Vector3(-10f, 0.5f, -10f);
    public Vector3 spawnRangeMax = new Vector3(10f, 0.5f, 10f);

    void Start()
    {
        // Set the object's global position to a random value within the specified range
        transform.position = GetRandomPosition();
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
                transform.position = GetRandomPosition();
                pickupAble.SetActive(true);
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




    Vector3 GetRandomPosition()
    {
        float x = Random.Range(spawnRangeMin.x, spawnRangeMax.x);
        float y = Random.Range(spawnRangeMin.y, spawnRangeMax.y);
        float z = Random.Range(spawnRangeMin.z, spawnRangeMax.z);
        return new Vector3(x, y, z);
    }
}
