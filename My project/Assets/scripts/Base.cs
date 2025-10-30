using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private float hp = 100;
    private ChangeScene change;
    public static Action<float> takenDamage;
    public float Hp
    {
        get { return hp; }
    }
    private void Start()
    {
        change = FindObjectOfType<ChangeScene>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyStats stats = collision.gameObject.GetComponent<EnemyStats>();
            hp -= stats.hp * stats.damageMultiplier;
            takenDamage.Invoke(hp);
        }
        if (hp <= 0)
        {
            change.SwitchScene();
        }
    }
}
