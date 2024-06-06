using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    public static int TotalDiamonds = 0;
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInvetory playerInvetory)
    {
        diamondText.text = playerInvetory.NumberOfDiamonds.ToString();
        TotalDiamonds = playerInvetory.NumberOfDiamonds;
    }
}
