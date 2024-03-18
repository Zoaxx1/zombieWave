using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject playerFollowing;

    [SerializeField] float offset = 11;

    void Update()
    {
        transform.position = playerFollowing.transform.position + new Vector3(0, offset, 0);
    }
}
