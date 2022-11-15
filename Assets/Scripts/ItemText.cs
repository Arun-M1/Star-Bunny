using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemText : MonoBehaviour
{
    private int stars = 0;

    [SerializeField] private Text starsCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StarItem"))
        {
            stars++;
            starsCount.text = "Stars: " + stars;
        }
    }
}
