using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
      if(col.tag == "Enemy")
      {
        print("hit enemy");
        GameManager.Instance.AddScore(5);
        var enemy = col.gameObject.GetComponent<Enemy>();
        enemy.Hide();
        Destroy(gameObject);
      }
    }
}
