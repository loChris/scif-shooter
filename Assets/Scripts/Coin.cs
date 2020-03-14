using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip _coinPickupSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null && Input.GetKeyDown(KeyCode.E))
            {
                player.hasCoin = true;
                AudioSource.PlayClipAtPoint(_coinPickupSound, transform.position, 1f);
                UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                if (uiManager != null)
                {
                    uiManager.UpdateInventory();
                }
                Destroy(this.gameObject);
            }
        } 
    }
}