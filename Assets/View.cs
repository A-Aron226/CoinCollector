using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class View : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = stats.currentHealth / stats.maxHealth;
        score.text = "Coins: " + stats.coinCount.ToString();
    }
}
