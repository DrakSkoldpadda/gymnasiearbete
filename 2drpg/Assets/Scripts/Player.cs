using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private bool isMoving = false;

    private Vector2 input;
    private Vector3 startPos;
    private Vector3 endPos;

    private float time;

    [SerializeField] private Collider2D leftCollider;
    [SerializeField] private Collider2D topCollider;
    [SerializeField] private Collider2D rightCollider;
    [SerializeField] private Collider2D bottomCollider;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            CheckMove();

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0f;
            }
            else
            {
                input.x = 0f;
            }

            if (input != Vector2.zero)
            {
                StartCoroutine(Move(transform));
            }
        }
    }

    private void CheckMove()
    {

    }

    private IEnumerator Move(Transform entity)
    {
        isMoving = true;
        startPos = entity.position;
        time = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (time < 1f)
        {
            time += Time.deltaTime * moveSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}
