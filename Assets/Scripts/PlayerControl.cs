using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 25.0f;
    private Rigidbody rbPlayer;
    private GameObject direction;
    private GameManager gameManager;
    private FollowPlayer gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        direction = GameObject.Find("Direction1");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameCamera = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!gameManager.isGameActive)
        {
            MovePlayer();

            if (gameManager.sceneName == "Level1")
            {
                if (gameManager.point == 96)
                {
                    GoDirection();
                    gameCamera.MoveCamera();
                }
            }
            else if (gameManager.sceneName == "Level2")
            {
                if (gameManager.point == 20)
                {
                    GoDirection();
                    gameCamera.MoveCamera();
                }
            }
        }
    }

    //Move player with arrow keys:
    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        rbPlayer.AddForce(Vector3.forward * speed * verticalInput);
        rbPlayer.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Move player automatically expected locations:
    public void GoDirection()
    {
        var step = (speed/5.0f) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction.transform.position, step);
       
        if(transform.position == direction.transform.position)
        {
            direction = GameObject.Find("Direction2");

            if(transform.position != direction.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, direction.transform.position, step);
            }
            else
            {
                transform.position = direction.transform.position;
                direction.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            Destroy(collision.gameObject);
            gameManager.AddPoint();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BridgeEnemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
