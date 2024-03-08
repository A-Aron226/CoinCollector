using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    [SerializeField] PlayerStats stats;
    public void OnCollisionEnter(Collision collision)
    {
        stats.currentHealth -= 1;

        /*if (stats.currentHealth < 0)
        {
            stats.currentHealth = 10; //use for testing purposes
        }*/
    }
}
