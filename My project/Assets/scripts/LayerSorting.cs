using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorting : MonoBehaviour
{
    private enum layer
    {
        Default,
        UI,
        MainObjects,
        BackgroundObjects
    }
    [SerializeField] private layer chosenlayer;

    // Start is called before the first frame update
    void Start()
    {
        string layerName = chosenlayer.ToString();
       Renderer renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = layerName;
    }
}
