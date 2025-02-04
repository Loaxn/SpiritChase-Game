using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectiblesUI : MonoBehaviour
{
    private TextMeshProUGUI crystalstext;

    // Start is called before the first frame update
    void Start()
    {
        crystalstext = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCrystalsText(PlayerCollectibles playerCollectibles)
    {
        crystalstext.text=playerCollectibles.NumberCristals.ToString();
    }
}
