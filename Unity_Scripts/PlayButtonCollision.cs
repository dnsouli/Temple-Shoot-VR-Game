using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "GameBullet")
        {
            print("hit play");
            SceneManager.LoadScene("GameLevelScene");
        }
    }
}
