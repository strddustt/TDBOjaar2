using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    [SerializeField] private GameObject listReference;
    private Transform pointHolder;
    private Queue<Transform> points = new Queue<Transform>();
    [SerializeField] private float speed;
    public Action reachedEnd;
    private EnemyStats stats;

    // Start is called before the first frame update
    void Start()
    {
        pointHolder = listReference.GetComponent<Transform>();
        // grabs every transform in the parent (excluding parent) from top to bottom as seen in the unity editor
        foreach (Transform child in pointHolder)
        {
            points.Enqueue(child);
        }
        stats = GetComponent<EnemyStats>();
        speed = stats.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count > 0)
        {
            //queue system used for moving between points. switch to list if knockback mechanics get used
            transform.position = Vector2.MoveTowards(transform.position, points.Peek().position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, points.Peek().position) <= 0.05f)
            {
                points.Dequeue();
            }
        }
        else if (points.Count == 0)
        {
            reachedEnd?.Invoke();
            Destroy(gameObject);
            stats.TakeDamage(stats.hp);
        }
    }
    public void SetList(Transform parentTransform)
    {
        listReference = parentTransform.gameObject;
    }
}
