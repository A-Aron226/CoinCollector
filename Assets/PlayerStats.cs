using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Player stats")]
public class PlayerStats : ScriptableObject
{
    public float maxHealth = 10;
    public float currentHealth = 10;
    public float coinCount = 0;
}
