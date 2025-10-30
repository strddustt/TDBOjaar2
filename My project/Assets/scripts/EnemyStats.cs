using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Action Died;

    [SerializeField] private float Hp = 5;
    [SerializeField]  private float Speed = 2;
    [SerializeField] private float DamageMultiplier = 1;
    private float totalhp;
    public float hp
    {
        get { return Hp; }
        private set { Hp = value; if (hp <= 0) { Died?.Invoke(); } }
    }
    public float speed
    {
        get { return Speed; }
    }
    public float damageMultiplier
    {
        get { return DamageMultiplier; }
    }
    public float totalHp
    {
        get { return totalhp; }
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
    private void Start()
    {
        totalhp = hp;
    }
}
