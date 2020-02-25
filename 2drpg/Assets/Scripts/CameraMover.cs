using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private PlayerMovement player;
    public float Speed => cameraMovingSpeed;
    [SerializeField] private float cameraMovingSpeed = 5f;

    private Vector3 startPos;
    private Vector3 endPos;

    private float time;

    void Start()
    {
        player = playerObject.GetComponent<PlayerMovement>();
    }

    public void Movement()
    {
        Vector3 viewPosition = GetComponent<Camera>().WorldToViewportPoint(playerObject.transform.position);

        if (viewPosition.x > 0.9f)
        {
            StartCoroutine(Move(transform, Camera.main.orthographicSize, 0));
        }
        else if (viewPosition.x < 0.1f)
        {
            StartCoroutine(Move(transform, -Camera.main.orthographicSize, 0));
        }
        else if (viewPosition.y > 0.9f)
        {
            StartCoroutine(Move(transform, 0, Camera.main.orthographicSize));
        }
        else if (viewPosition.y < 0.1f)
        {
            StartCoroutine(Move(transform, 0, -Camera.main.orthographicSize));
        }

    }

    private IEnumerator Move(Transform entity, float xFloat, float yFloat)
    {
        player.canMove = false;

        startPos = entity.position;
        time = 0;

        endPos = new Vector3(startPos.x + xFloat, startPos.y + yFloat, startPos.z);

        while (time < 1f)
        {
            time += Time.deltaTime * Speed;
            entity.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }

        yield return 0;

        player.canMove = true;
    }
}
