﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] enemyGroups;
    public float[] timeSpanBetweenGroupSpawn;
    public Transform[] enemyGroupSpawningPoints;
    public int currentSpawningEnemyGroupIndex;
    bool isReadyToSpawn = true;
    float timer = 0;

    void Start() {
        this.currentSpawningEnemyGroupIndex = 0;
    }

    void FixedUpdate() {
        if(this.currentSpawningEnemyGroupIndex < this.enemyGroups.Length && this.isReadyToSpawn) {
            this.isReadyToSpawn = false;
            StartCoroutine(this.spawnGroup());
        }
    }

    private IEnumerator spawnGroup() {
        yield return new WaitForSeconds(this.timeSpanBetweenGroupSpawn[this.currentSpawningEnemyGroupIndex]);
        this.isReadyToSpawn = true;
        Instantiate (this.enemyGroups[this.currentSpawningEnemyGroupIndex], this.enemyGroupSpawningPoints[this.currentSpawningEnemyGroupIndex].position, this.enemyGroupSpawningPoints[this.currentSpawningEnemyGroupIndex].rotation);
        this.currentSpawningEnemyGroupIndex++;
    }
}
