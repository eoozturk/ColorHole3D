using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private float xLoc, yLoc, zLoc;
    public GameObject player;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        xLoc = 0;
        yLoc = 26.801f;
        zLoc = -32.7f;
        player = GameObject.Find("Player");
        offset = new Vector3(0, 25.8f, -48.7f);
    }

    //Move camera with player:
    public void MoveCamera()
    {
        if (transform.position.z != zLoc)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            transform.position = new Vector3(xLoc, yLoc, zLoc);
        }
    }
}
