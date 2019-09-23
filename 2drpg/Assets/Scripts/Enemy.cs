using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IMove
{
    public float Speed => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Movement()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, input, 1f);
    }
}
