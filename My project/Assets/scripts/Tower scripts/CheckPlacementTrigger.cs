using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacementTrigger : MonoBehaviour
{
    private PlaceTower button;
    public void ReferenceButton(PlaceTower parent)
    {
        button = parent;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hitbox")
        {
            button.Collisions.Add(collision.gameObject);
        }
        else if (collision.tag == "placable")
        {
            button.Collisions.Add(collision.gameObject);
        }
    }
}
