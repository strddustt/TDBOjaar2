using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TowerStats))]
public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject currentPrefab;
    private TowerStats stats;
    private cash Cash;
    private WaveSystem waves;
    [SerializeField] private CircleCollider2D thisCollider;
    [SerializeField] private Text starttext;

    [SerializeField] private int requiredcash;
    private bool placing = false;
    private bool allowed = false;
    private bool firsttower = true;

    [SerializeField] private List<GameObject> collisions = new List<GameObject>();
    public List<GameObject> Collisions {  get { return collisions; } }
    private List<Component> components = new List<Component>();
    void Start()
    {
        stats = prefab.GetComponent<TowerStats>();
        Cash = FindObjectOfType<cash>();
        waves = FindObjectOfType<WaveSystem>();
        thisCollider.gameObject.GetComponent<CheckPlacementTrigger>().ReferenceButton(this);
    }
    private void OnClick()
    {
        StartCoroutine(Click());
    }
    public IEnumerator Click()
    {
        if (Cash.Cash >= requiredcash)
        {
            yield return new WaitForEndOfFrame();
            currentPrefab = Instantiate(prefab);
            DisableTower();
            placing = true;

        }
    }
    private void Update()
    {
        if (placing)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                placing = false;
                currentPrefab = null;
            }
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = -1f;
            currentPrefab.transform.position = mouseWorldPos;
            if (Input.GetMouseButtonDown(0))
            {
                thisCollider.gameObject.transform.position = mouseWorldPos;
                thisCollider.radius = stats.range;
                StartCoroutine(CheckPlacement());
            }
            if (allowed)
            {

                
            }
        }
    }
    private IEnumerator CheckPlacement()
    {
        yield return new WaitForEndOfFrame();
        allowed = true;
        Debug.Log("checking placement");
        foreach (GameObject item in collisions)
        {
            if (item.tag == "Tower" && item != currentPrefab)
            {
                Debug.Log("placement disallowed");
                allowed = false;
                break;
            }
            else if (item.tag == "placable")
            {
                Debug.Log("maybe allowed");
            }
            else
            {
                collisions.Remove(item);
            }
            
        }
        if (collisions.Count > 0 & allowed == true)
        {
            Debug.Log("trying to place");
            allowed = false;
            Place();
        }
    }
    private void Place()
    {
        EnableTower();
        Cash.setcash(-requiredcash);
        currentPrefab = null;
        allowed = false;
        placing = false;
        if (firsttower)
        {
            firsttower = false;
            StartCoroutine(waves.normal());
            Destroy(starttext);
        }
    }
    private void DisableTower()
    {

        foreach (Component item in currentPrefab.GetComponents<Component>())
        {
            if (item is SpriteRenderer)
            {

            }
            else if (item is Behaviour b)
            {
                components.Add(b);
                b.enabled = false;
            }
        }
    }
    private void EnableTower()
    {
        foreach(Behaviour b in components)
        {
            b.enabled = true;
        }
    }
}
