using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    float xRangeLeft = -8.5f;
    float xRangeRight = -1;
    GameManager gameManager = new GameManager();
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGamePlaying())
        {
            //horizontal input from player
            transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);
            if (transform.position.x < xRangeLeft)
                transform.position = new Vector3(xRangeLeft, transform.position.y, transform.position.z);
            else if (transform.position.x > xRangeRight)
                transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            
            //check for lives
            if (gameManager.getLife() <= 1)
            {
                Debug.Log("Time slowed");
                
                //end game
                gameManager.disableGame();
                //show UI
                gameOverScreen.SetActive(true);
                Time.timeScale = 0.0f;  //stop game
            }
            if (Time.timeScale != 0.0f)
            {
                Time.timeScale = 0.1f;
                Invoke("RestoreTime", 0.1f);
            }
            gameManager.reduceLife();
        }
        else if (collision.gameObject.name == "Capsule(Clone)") //bonus object
        {
            Debug.Log("Bonus Collected");
            gameManager.addBonus();
            Destroy(collision.gameObject);
        }
    }

    void RestoreTime()
    {
        Debug.Log("Restore time called...");
        Time.timeScale = 1;
    }
}
