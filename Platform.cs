using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
      print(col.gameObject.name);
      if(col.gameObject.tag.ToLower().Contains(GameManager.Instance.CurPlatform.ToLower()))
      {
        GameManager.Instance.EnterPlatform(col.gameObject.GetComponent<PlatformAction>());
      }

      if(col.tag == "EnemySword")
        {
            print("Hit by sword - taking 5 points");
            GameManager.Instance.AddScore(-5);
        }
    }
}
