using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MeshRenderer mesh;
    [SerializeField]
    private AudioClip hitSound;
    private float curHideTime;
    private float hideTime = 3;
    private bool isHidden;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
      if(isHidden)
      {
        curHideTime += Time.deltaTime;
        if(curHideTime >= hideTime)
        {
          mesh.enabled = true;
          isHidden = false;
        }
      }
    }

    public void Hide()
    {
        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
      mesh.enabled = false;
      isHidden = true;
      curHideTime = 0;
    }
}
