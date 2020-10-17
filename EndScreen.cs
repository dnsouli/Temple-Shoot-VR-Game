using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro scoreText;

    // Start is called before the first frame update
    void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Final Score: " + score;
    }
}
