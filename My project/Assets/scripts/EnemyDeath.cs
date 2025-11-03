using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private EnemyStats stats;
    private Enemymovement movement;
    private bool scheduleDeath;
    private cash Cash;
    // Start is called before the first frame update
    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        movement = GetComponent<Enemymovement>();
        movement.reachedEnd += EndReached;
        stats.Died += OnDeath;
        Cash = FindObjectOfType<cash>();
        
    }
    private void EndReached()
    {
        
    }
    private void OnDeath()
    {
        Destroy(gameObject, 0.01f);
        Cash.setcash(Mathf.RoundToInt(stats.totalHp));
    }
}
