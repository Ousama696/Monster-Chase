using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollector : MonoBehaviour
{

    private string ENEMIES_TAG = "Enemies";

    private string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ENEMIES_TAG) || collision.CompareTag(PLAYER_TAG) )
            Destroy(collision.gameObject);
    }

}
