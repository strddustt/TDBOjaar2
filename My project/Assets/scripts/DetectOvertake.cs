using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DetectOvertake : MonoBehaviour
{
    EnemyStats thisEnemy;
    GameObject otherEnemy;
    public Action<GameObject, GameObject> switchTarget;
    private float timeToWait;
    private void Start()
    {
        thisEnemy = GetComponent<EnemyStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats stats = collision.GetComponent<EnemyStats>();
            float speedDifference = stats.speed - thisEnemy.speed;
            timeToWait = speedDifference * 0.5f;
            otherEnemy = collision.gameObject;
            if (speedDifference > 0)
            {
                StartCoroutine(WaitForSwitch());
            }
        }
    }
    private IEnumerator WaitForSwitch()
    {
        yield return new WaitForSeconds(timeToWait);
        switchTarget?.Invoke(otherEnemy, gameObject);
    }
}
