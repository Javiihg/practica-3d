using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5.0f;
    private UnityEngine.Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 desiredPosition = player.position + offset;

        UnityEngine.Vector3 smoothedPosition = UnityEngine.Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}
