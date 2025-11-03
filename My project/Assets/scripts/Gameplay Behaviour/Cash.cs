using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cash : MonoBehaviour
{
    private int totalCash = 300;
    public int Cash
    {
        get { return totalCash; }
        private set { totalCash = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setcash(int value)
    {
        Cash += value;
    }
}
