using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemText : MonoBehaviour
{
    playerControl player;

    private int stars = 0;

    Text starsCount;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<playerControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StarItem"))
        {
            stars = player.items.Count;
            starsCount.text = "Stars: " + stars;
        }
    }
}
