using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMan : MonoBehaviour
{
    [SerializeField] private AudioClip _victorySound;

    //check for player collision
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null && Input.GetKeyDown(KeyCode.E))
            {
                if (player.hasCoin)
                {
                    AudioSource.PlayClipAtPoint(_victorySound, transform.position, 1f);
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    player.EnableWeapon();
                    if (uiManager != null)
                    {
                        player.hasCoin = false;
                        uiManager.RemoveCoinFromInventory();
                    }
                }
                else
                {
                    Debug.Log("Get outta here, chump. Come back with some coin!");
                }
            }
        }
    }
}
