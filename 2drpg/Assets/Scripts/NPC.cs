using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IMove
{
    public float Speed => speed;
    private float speed = 2;

    private float time;

    private Vector2 direction;

    private Player player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f);

        if (hit.collider.tag == "Player")
        {
            player.canMove = false;

            Movement();
        }
    }

    public void Movement()
    {

    }
}