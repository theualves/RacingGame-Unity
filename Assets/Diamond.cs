using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInvetory playerInvetory = other.GetComponent<PlayerInvetory>();

        if (playerInvetory != null )
        {
            playerInvetory.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}
