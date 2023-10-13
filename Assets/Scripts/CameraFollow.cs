using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 cameraPosition= transform.position;
        cameraPosition =new Vector3(
            player.position.x,
            player.position.y,
            -10f
            );
        transform.position= cameraPosition;
    }
}
