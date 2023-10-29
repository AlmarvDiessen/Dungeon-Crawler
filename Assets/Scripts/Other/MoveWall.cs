using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField] float moveX;
    [SerializeField] float moveY;
    [SerializeField] float moveZ;
    [SerializeField] float duration;

    [SerializeField] KeyCode keyCode;

    [SerializeField] float snapDistance;

    bool doorOpen;

    private Vector3 startPos;
    private Vector3 newPos;
    private Vector3 newPos2;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            StartCoroutine(OperateDoor());
        }
    }

    IEnumerator OperateDoor()
    {
        //if (!doorOpen)
       // {
            Vector3 xPos = startPos + transform.right * moveX;

            Vector3 yPos = xPos + transform.up * moveY;

            Vector3 zPos = yPos + transform.forward * moveZ;

            if (moveX != 0)
            {
                yield return StartCoroutine(MoveDoorX(xPos));
            }

            if (moveY != 0)
            {
                yield return StartCoroutine(MoveDoorY(yPos));
            }

            if (moveZ != 0)
            {
                yield return StartCoroutine(MoveDoorZ(zPos));
            }
       // }
        //else
        //{
        //    StartCoroutine(MoveDoor(startPos));
        //}
        //doorOpen = !doorOpen;

        yield return null;
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration).normalized;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MoveDoorX(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < duration)
        {
            if (Vector3.Distance(startPosition, targetPosition) > snapDistance)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;

            }
            yield return null;
        }
        newPos = transform.position;
    }

    IEnumerator MoveDoorY(Vector3 targetPosition)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            if (Vector3.Distance(newPos, targetPosition) > snapDistance)
            {
                transform.position = Vector3.Lerp(newPos, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            yield return null;
        }
    }

    IEnumerator MoveDoorZ(Vector3 targetPosition)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            if (Vector3.Distance(newPos, targetPosition) > snapDistance)
            {
                transform.position = Vector3.Lerp(newPos, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            yield return null;
        }
    }
}