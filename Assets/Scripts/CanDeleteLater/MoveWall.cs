using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

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
        //StopAllCoroutines();
        if (!doorOpen)
        {
            Vector3 xPos = startPos + transform.right * moveX;

            Vector3 yPos = startPos + transform.up * moveY;

            Vector3 zPos = startPos + transform.forward * moveZ;

            if (moveX != 0)
            {
                Debug.Log("start coroutine X");
                yield return StartCoroutine(MoveDoorX(xPos));
            }

            if (moveY != 0)
            {
                Debug.Log("start coroutine Y");
                yield return StartCoroutine(MoveDoorY(yPos));
            }

            if (moveZ != 0)
            {
                Debug.Log("start coroutine Z");
                yield return StartCoroutine(MoveDoorZ(zPos));
            }
        }
        else
        {
            StartCoroutine(MoveDoor(startPos));
        }
        doorOpen = !doorOpen;

        yield return null;
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        Debug.Log("Moving X");

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
        Debug.Log("Moving X");

        float timeElapsed = 0;
        Vector3 startPosition = transform.position;

        while (timeElapsed < duration)
        {
            Debug.Log("Moving X2");

            if (Vector3.Distance(startPosition, targetPosition) > snapDistance)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                Debug.Log("Moving X3");

            }
            yield return null;
        }
        newPos = transform.position;

        Debug.Log("Stopping X");
    }

    IEnumerator MoveDoorY(Vector3 targetPosition)
    {
        Debug.Log("moving Y");

        float timeElapsed = 0;
        //Vector3 startPosition = transform.position;
        //newPos = transform.position;

        while (timeElapsed < duration)
        {
            Debug.Log("moving Y2");
            if (Vector3.Distance(newPos, targetPosition) > snapDistance)
            {
                Debug.Log("moving Y3");
                transform.position = Vector3.Lerp(newPos, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            yield return null;
        }
        //newPos = transform.position;
        Debug.Log("start coroutine Z");
    }

    IEnumerator MoveDoorZ(Vector3 targetPosition)
    {
        Debug.Log("Moving Z");

        float timeElapsed = 0;
        //Vector3 startPosition = transform.position;

        while (timeElapsed < duration)
        {
            Debug.Log("Moving Z2");

            if (Vector3.Distance(newPos, targetPosition) > snapDistance)
            {
                Debug.Log("Moving Z3");
                transform.position = Vector3.Lerp(newPos, targetPosition, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
            }
            yield return null;
        }
        //newPos = transform.position;
    }
}