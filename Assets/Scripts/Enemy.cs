﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        // AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // void AddNonTriggerBoxCollider()
    // {
    //     Collider boxCollider = gameObject.AddComponent<BoxCollider>();
    //     boxCollider.isTrigger = false;
    // }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hits <= 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;

        //TODO consider hit FX 
    }

    void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
