using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private Text _pickupText;

    [SerializeField]
    private GameObject _coin;

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void DisplayPickupMessage(GameObject obj)
    {
        _pickupText.text = "Press (E) to pickup " + obj.name;
    }

    public void HidePickupMessage()
    {
        _pickupText.text = "";
    }
    public void UpdateInventory(bool active) => _coin.SetActive(active);



}
