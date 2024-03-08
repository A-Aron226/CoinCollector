using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] GameObject obj; //uses coin object

    private void OnTriggerEnter(Collider other)
    {
        Destroy(obj); //destroys coin object
        stats.coinCount += 1;
    }
}
