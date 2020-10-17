using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int affiliation;
    public Transform aimPoint;
    public ActorManager manager;

    // Start is called before the first frame update
    void Start()
    {

      // manager = GameObject.FindObjectOfType<ActorManager>();
      // DebugUtility.HandleErrorIfNullFindObject<ActorManager, Actor>(manager, this);
      if(!manager.actors.Contains(this))
      {
        manager.actors.Add(this);
      }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
      if(manager)
      {
        manager.actors.Remove(this);
      }
    }
}
