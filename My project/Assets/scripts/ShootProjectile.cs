using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Queue<GameObject> projectiles = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 6; i++) // pool instantiation
        {
            projectiles.Enqueue(Instantiate(prefab, gameObject.transform.position, Quaternion.identity));
        }
        foreach (GameObject projectile in projectiles)
        {
            projectile.SetActive(false);
        }
        
    }
    public void EnableProjectile(GameObject target)
    {
        Projectile projectile = projectiles.Peek().GetComponent<Projectile>();
        projectile.gameObject.SetActive(true);
        projectile.MoveToTarget(target);
        projectile.AssignTower(gameObject);
        projectiles.Dequeue();
        
    }
    public void enqueue(GameObject toAdd)
    {
        projectiles.Enqueue(toAdd);
        toAdd.SetActive(false);
    }
}
