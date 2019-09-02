using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Tilemap obstaclesTilemap;
    [SerializeField] public Tilemap groundTilemap;

    [SerializeField] public float moveTime;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Movement()
    {
        float Xinput = Input.GetAxisRaw("Horizontal");
        float Yinput = Input.GetAxisRaw("Vertical");

        if (Xinput != 0f)
        {
            Yinput = 0f;
        }


        //Vector3 newPosition = new Vector3.MoveTowards()
    }
}
