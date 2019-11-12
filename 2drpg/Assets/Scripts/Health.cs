﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private int deafaultHealth;

    private Transform bar;

    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void TakeDamage()
    {


        SetHealthBarSize(health);
    }

    private void SetHealthBarSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);

        SetHealthBarColor();
    }

    private void SetHealthBarColor()
    {
        if (health >= deafaultHealth % 80 || health < deafaultHealth % 80)
        {
            bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (health >= deafaultHealth % 40 || health < deafaultHealth % 40)
        {
            bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
