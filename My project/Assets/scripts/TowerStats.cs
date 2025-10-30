using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    private float AttackSpeed = 1;
    private float Damage = 2;
    private float Range = 3;

    private CircleCollider2D circlecollider;
    private void Start()
    {
        circlecollider = GetComponent<CircleCollider2D>();
        circlecollider.radius = Range;
    }

    public float attackSpeed
    {
        get { return AttackSpeed; }
        private set { AttackSpeed = value; }
    }
    public float range
    {
        get { return Range; }
        private set { Range = value; }
    }
    public int damage
    {
        get { return Mathf.RoundToInt(Damage); }
        private set { Damage = value; }
    }

    public void ChangeStat(ref float stat, float newvalue)
    {
        stat = newvalue;
    }
}
