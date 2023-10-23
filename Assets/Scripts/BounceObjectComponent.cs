using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObjectComponent : MonoBehaviour
{
    [SerializeField] float bounceUp;
    [SerializeField] float bounceSpeed;
    [SerializeField] float loop;
    private float startAmpPosY;

    //public float bounceUpper { get => bounceUp; set => bounceUp = value; }

    public void Awake()
    {
        startAmpPosY = transform.position.y;
    }

    void Update()
    {
        float y = Mathf.Sin(loop * (Mathf.PI * 2) * bounceSpeed) * bounceUp;

        transform.position = new Vector3(transform.position.x, startAmpPosY + y, transform.position.z);
        loop += Time.deltaTime;
    }
}
