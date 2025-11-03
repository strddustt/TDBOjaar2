using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Xml.Schema;

public class WaveSystem : MonoBehaviour
{
    private int wave;
    private bool wavespawner = false;
    private Queue<GameObject> totalenemies = new Queue<GameObject>();
    private int enemiesThisWave;
    private int enemiesLeft = 0;
    private int currentwave = 0;
    private cash Cash;

    [SerializeField] private GameObject weakestenemy;
    [SerializeField] private GameObject fastweakenemy;
    [SerializeField] private GameObject weakenemy;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject fastenemy;
    [SerializeField] private GameObject fasterenemy;
    [SerializeField] private GameObject strongenemy;
    [SerializeField] private GameObject boss1;

    private Dictionary<string, GameObject> enemyTypes;

    private void Start()
    {
        Cash = FindObjectOfType<cash>();
        enemyTypes = new Dictionary<string, GameObject>
        {
            { "weakestenemy", weakestenemy },
            { "fastweakenemy", fastweakenemy },
            { "weakenemy", weakenemy },
            { "enemy", enemy },
            { "fastenemy", fastenemy },
            { "fasterenemy", fasterenemy },
            { "strongenemy", strongenemy },
            { "boss1", boss1 }
        };

    }

    private void Update()
    {

    }

    public IEnumerator normal()
    {
        wavespawner = true;
        for (int i = 1; i <= 16; i++)
        {
            
            currentwave = i;
            float timepassed = 0;
            yield return StartCoroutine(SpawnWave(i));
            Debug.Log("hi :3");
            while (enemiesLeft > 0) //waits for 10 seconds, or until the while condition is false
            {
                yield return new WaitForSeconds(0.2f);
                timepassed += 0.2f;
                Debug.Log(enemiesLeft);
                if (timepassed > 10f)
                {
                    break;
                }
            }
        }
    }

    private IEnumerator SpawnWave(int waveNumber)
    {
        switch (waveNumber)
        {
            case 1:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(3, 0, 5), 10);
                break;
            case 2:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(2, 0, 5), 10);
                yield return SpawnEnemies("weakestenemy", new SpawnerState(0.5f, 0, 3), 10);
                break;
            case 3:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(2, 0, 6), 10);
                yield return SpawnEnemies("weakestenemy", new SpawnerState(3, 0, 6), 10);
                break;
            case 4:
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1.5f, 0, 8), 7);
                break;
            case 5:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(1, 0, 10), 10);
                break;
            case 6:
                yield return SpawnEnemies("weakenemy", new SpawnerState(4, 0, 3), 10);
                break;
            case 7:
                yield return SpawnEnemies("weakestenemy", new SpawnerState(5, 0, 3), 10);
                yield return SpawnEnemies("weakestenemy", new SpawnerState(2, 0, 10), 10);                                     
                break;
            case 8:
                yield return SpawnEnemies("weakenemy", new SpawnerState(2, 0, 6), 10);
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(3, 0, 3), 10);
                break;
            case 9:
                yield return SpawnEnemies("weakenemy", new SpawnerState(3, 0, 5), 10);
                yield return SpawnEnemies("weakestenemy", new SpawnerState(1, 0, 8), 10);
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1, 0, 5), 10);
                break;
            case 10:
                yield return SpawnEnemies("enemy", new SpawnerState(6, 0, 1), 10);
                yield return SpawnEnemies("weakenemy", new SpawnerState(0.5f, 0, 8), 10);
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1, 0, 8), 10);
                break;
            case 11:
                yield return SpawnEnemies("enemy", new SpawnerState(5, 0, 2), 10);
                yield return SpawnEnemies("weakenemy", new SpawnerState(2, 0, 8), 10);
                yield return SpawnEnemies("weakestenemy", new SpawnerState(0.2f, 0, 8), 10);
                break;
            case 12:
                yield return SpawnEnemies("enemy", new SpawnerState(2, 0, 1), 10);
                yield return SpawnEnemies("weakenemy", new SpawnerState(1, 0, 8), 10);
                break;
            case 13:
                yield return SpawnEnemies("fastenemy", new SpawnerState(7, 0, 1), 10);
                yield return SpawnEnemies("weakenemy", new SpawnerState(1, 0, 8), 10);
                yield return SpawnEnemies("enemy", new SpawnerState(3, 0, 5), 10);
                break;
            case 14:
                yield return SpawnEnemies("fasterenemy", new SpawnerState(6, 0, 2), 10);
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(1, 0, 7), 10);
                yield return SpawnEnemies("weakenemy", new SpawnerState(1.5f, 0, 5), 10);
                break;
            case 15:
                yield return SpawnEnemies("enemy", new SpawnerState(1, 0, 3), 10);
                yield return SpawnEnemies("fastenemy", new SpawnerState(8, 0, 2), 10);
                yield return SpawnEnemies("weakenemy", new SpawnerState(1, 0, 12), 10);
                yield return SpawnEnemies("fastweakenemy", new SpawnerState(0.5f, 0, 15), 10);
                break;
            case 16:
                yield return SpawnEnemies("strongenemy", new SpawnerState(1, 0, 1), 10);
                break;
        }
        wave++;
        Cash.setcash(100 * wave);
        Debug.Log("wave finished " + wave.ToString());
    }

    private IEnumerator SpawnEnemies(string enemyType, SpawnerState state, int wavetime)
    {
        enemiesThisWave = state.Total;
        if (!enemyTypes.ContainsKey(enemyType))
        {
            Debug.LogError("Enemy type not found: " + enemyType);
            yield break;
        }

        GameObject enemyPrefab = enemyTypes[enemyType];

        while (state.CurrentAmount < state.Total)
        {
            GameObject newEnemyObject = Instantiate(enemyPrefab);
            newEnemyObject.transform.position = gameObject.transform.position;
            state.CurrentAmount++;
            EnemyStats stats = newEnemyObject.GetComponent<EnemyStats>();
            stats.Died += CountAlive;

            if (newEnemyObject == null)
            {
                Debug.LogError("Failed to instantiate enemy prefab");
                yield break;
            }

            Enemymovement newEnemy = newEnemyObject.GetComponent<Enemymovement>();
            Transform parent = transform.parent;
            if (newEnemy == null)
            {
                Debug.LogError("Enemy component not found on instantiated prefab");
                yield break;
            }
            newEnemy.SetList(parent);
            Debug.Log("enemy spawn amount: " + state.CurrentAmount.ToString() + " of total: " + state.Total.ToString());
            enemiesLeft++;
            yield return new WaitForSeconds(state.Timer);
        }
    }
    private void CountAlive()
    {
        enemiesLeft -= 1;
    }
}

public class SpawnerState
{
    public float Timer { get; }
    public int CurrentAmount { get; set; }
    public int Total { get; }

    public SpawnerState(float timer, int currentAmount, int total)
    {
        Timer = timer;
        CurrentAmount = currentAmount;
        Total = total;
    }
}