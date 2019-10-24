using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour, IMove
{
    public float Speed => moveSpeed;
    [SerializeField] private float moveSpeed = 3f;
    private bool isMoving = false;
    public bool canMove = true;

    private Vector2 input;
    private Vector3 startPos;
    private Vector3 endPos;

    private float time;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0f;
            }
            else
            {
                input.x = 0f;
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, input, 1f);

            if (hit.collider == null && input != Vector2.zero && canMove)
            {
                StartCoroutine(Move(transform));
            }
            else if (hit.collider.tag == "NPC" && input != Vector2.zero && canMove)
            {
                hit.collider.GetComponent<NPC>().TriggerDialogue();
            }

        }
    }

    private IEnumerator Move(Transform entity)
    {
        isMoving = true;
        startPos = entity.position;
        time = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (time < 1f)
        {
            time += Time.deltaTime * Speed;
            entity.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}
