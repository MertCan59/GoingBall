using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
        void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if(player!=null)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition = new Vector3(
                player.position.x,
                player.position.y,
                -10f
                );
            transform.position = cameraPosition;
        }        
    }
}
