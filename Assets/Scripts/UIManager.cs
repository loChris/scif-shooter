using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    [SerializeField] private Image _coinImage;

    private void Start()
    {
        _coinImage.gameObject.SetActive(false);
    }

    public void UpdateAmmo(int ammoCount)
    {
        _ammoText.text = "Ammo: " + ammoCount;
    }

    public void UpdateInventory()
    {
        _coinImage.gameObject.SetActive(true);
    }
}
