using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SCRIPT BY PAULO

public class BounceObjectComponent : MonoBehaviour
{
    [SerializeField] float bounceUp;
    [SerializeField] float bounceSpeed;
    [SerializeField] float loop;
    
    private float startAmpPosY;

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
