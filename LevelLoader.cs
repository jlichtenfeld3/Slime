using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

    private bool playerInZone;

    public string levelToLoad;

    void Start()
    {
        playerInZone = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            Application.LoadLevel(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }

    }
}