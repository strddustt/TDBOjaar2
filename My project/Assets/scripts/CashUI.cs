using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashUI : MonoBehaviour
{
    private Text text;
    private cash Cash;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        Cash = FindObjectOfType<cash>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "$ " + Cash.Cash.ToString();
    }
}
