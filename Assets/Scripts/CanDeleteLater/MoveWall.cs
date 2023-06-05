using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class MoveWall : MonoBehaviour
{
    #region
    //[SerializeField] GameObject wall;
    ////[SerializeField] Transform wallPos;
    //[SerializeField] Vector3 wallPos;
    //[SerializeField] Vector3 newWallPos;

    //float transitionSpeed;

    //private void Awake()
    //{
    //    wall.transform.position = wallPos;
    //    //wallPos = wall.transform.position;
    //}

    //void ChangeWallPos()
    //{
    //    //wallPos.transform.position = newWallPos;
    //    wall.transform.position = wall.transform.position(Vector3.Lerp(transform.position, newWallPos, Time.deltaTime * transitionSpeed);

    //}

    ////private void OnTriggerEnter(Collider other)
    ////{

    ////}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        //Vector3 newPos = new Vector3(transform.position.x, posY, transform.position.z);
    //        ChangeWallPos();
    //    }
    //}
    #endregion

    // Transforms to act as start and end markers for the journey.
    public Vector3 startMarker;
    public Vector3 endMarker;
    public Vector3 endMarker2;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    // Move to the target end position.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            StartCoroutine(AnimateWall1());
            StartCoroutine(AnimateWall2());

            return;
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
        }
    }

    private IEnumerator AnimateWall1()
    {
        while (true)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);

            if(Vector3.Distance(transform.position, endMarker) == 0)
            {
                Debug.Log("kitsune");
                journeyLength = Vector3.Distance(endMarker, endMarker2);
                transform.position = endMarker;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator AnimateWall2()
    {
        while (true)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(endMarker, endMarker2, fractionOfJourney);

            if (Vector3.Distance(transform.position, endMarker2) == 0)
            {
                Debug.Log("senko");
                transform.position = endMarker2;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
