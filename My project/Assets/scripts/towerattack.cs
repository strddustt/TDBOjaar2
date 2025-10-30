using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerattack : MonoBehaviour
{
    private EnemyList enemyList;
    private Projectile[] projectiles;
    private Transform target;
    private TowerStats stats;
    private ShootProjectile shootProjectile;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private bool calledCoroutine = false;
    void Start()
    {
        enemyList = GetComponent<EnemyList>();
        shootProjectile = GetComponent<ShootProjectile>();
        projectiles = GetComponentsInChildren<Projectile>(); //works via projectile pooling
        stats = GetComponent<TowerStats>();
        
    }
    public void GiveTarget(Transform target)
    {
        this.target = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && !calledCoroutine)
        {
            StartCoroutine(ShootProjectile(stats.attackSpeed));
        }
    }
    private IEnumerator ShootProjectile(float attackspeed)
    {
        while (target != null)
        {
            calledCoroutine = true;
            shootProjectile.EnableProjectile(target.gameObject);
            yield return new WaitForSeconds(attackspeed);
        }
        calledCoroutine = false;
        yield break;
    }

}
