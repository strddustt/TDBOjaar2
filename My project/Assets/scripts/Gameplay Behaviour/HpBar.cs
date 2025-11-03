using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Transform greenBar;
    private Text text;
    private Base basereference;
    private float maxHp;
    private void Start()
    {
        basereference = FindObjectOfType<Base>();
        maxHp = basereference.Hp;
        Base.takenDamage += UpdateUI;
        text = GetComponentInChildren<Text>();
        text.text = maxHp.ToString() + " / " + maxHp.ToString();
    }

    private void UpdateUI(float hp)
    {
        float healthPercent = hp / maxHp;
        greenBar.localScale = new Vector3(healthPercent, 1f, 1f);
        text.rectTransform.localScale = new Vector3(1 / healthPercent, 1f, 1f);
        text.text = Mathf.RoundToInt(hp).ToString() + " / " + maxHp.ToString();
    }
}
