using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemText : MonoBehaviour
{
    playerControl player;

    private int stars = 0;

    Text starsCount; 

    void Start()
    {
        starsCount = GetComponent<Text>();
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<playerControl>();
    }


    void Update()
    { 
        starsCount.text = "Stars:" + player.items.Count;
    }

}
