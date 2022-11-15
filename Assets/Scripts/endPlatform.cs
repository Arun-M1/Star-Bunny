using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endPlatform : MonoBehaviour
{
    //public GameObject player; 

    private bool levelCompleted = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
            //CompleteLevel();
        }
    }

    //trying to fix, reference player object
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(player.inventory.size() == 3)
            {
                if(!levelCompleted)
                {
                    levelCompleted = true;
                    Invoke("CompleteLevel", 2f);
                    //CompleteLevel();
                }
            }
        }
    }*/

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
