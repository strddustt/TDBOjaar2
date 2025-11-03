using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2? targetposition;
    private Vector3 startposition;
    private GameObject target;
    private ShootProjectile tower;
    [SerializeField] private float speed = 5;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetposition = target.transform.position;
        }
        if (target == null) // resets if enemy dies before projectile hits
        {
            targetposition = null;
            transform.position = startposition;
            gameObject.SetActive(false); 
        }
        if (targetposition is Vector2 position) 
        {
            transform.position = Vector2.MoveTowards(transform.position, position, Time.deltaTime * speed); //target reached
        }

    }
    public void MoveToTarget(GameObject target)
    {
        startposition = transform.position;
        this.target = target;
        targetposition = this.target.transform.position;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>(); //references enemy, does damage, then resets to the position of the tower and disables itself through shootprojectile
            enemy.TakeDamage(damage);
            transform.position = startposition;
            tower.enqueue(gameObject); 
        }

    }
    public void AssignTower(GameObject tower)
    {
        this.tower = tower.GetComponent<ShootProjectile>();
        damage = tower.gameObject.GetComponent<TowerStats>().damage; //convoluted ass code
    }

}
