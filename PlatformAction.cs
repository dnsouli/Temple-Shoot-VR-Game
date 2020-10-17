using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAction : MonoBehaviour
{
  [SerializeField]
  private GameObject[] platformObjects;

    public void SetActivePlatformObjects(bool active)
    {
      foreach(var obj in platformObjects)
      {
        obj.SetActive(active);
      }
    }
}
