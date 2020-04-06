using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // print("Player triggered something");
        StartDeathSequence();
    }

    void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath");
    }
}
