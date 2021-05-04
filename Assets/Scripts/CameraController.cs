using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Serialize params
    [SerializeField] Transform playerTransform;

    //State
    bool followingPlayer;

    //cached component reference

    private void Start()
    {
        followingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
