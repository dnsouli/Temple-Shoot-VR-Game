using UnityEngine;
using System.Collections;
using Valve.VR;

public class Flaregun : MonoBehaviour {

	public Rigidbody flareBullet;
	public Transform barrelEnd;
	// public GameObject muzzleParticles;
	public AudioClip flareShotSound;
	public AudioClip noAmmoSound;
	public AudioClip reloadSound;
	public int bulletSpeed = 2000;
	public int maxSpareRounds = 5;
	public int spareRounds = 3;
	public int currentRound = 0;
	public int reticalDistance = 30;

    public SteamVR_Action_Boolean m_TriggerPress = null;

    //public GameObject retical;


    // Update is called once per frame
    void Update ()
	{

		RaycastHit hit;

		/*
		if (Physics.Raycast(barrelEnd.position, barrelEnd.forward, out hit))
        {
						//ContactPoint contact = collision.contacts[0];
						//Vector3 position = contact.point;
            Debug.DrawRay(barrelEnd.position, barrelEnd.forward * reticalDistance, Color.yellow);
						// retical.gameObject.Transform = position;
						Vector3 reticalPosition = barrelEnd.position + barrelEnd.forward * reticalDistance;

						// TODO: find which is nearer to the user hit.point or reticalPosition
						// and update reticalPosition to hit.point if it's nearer

						retical.transform.position = reticalPosition;

            // Debug.Log("Did Hit");
        }
		*/

		//if(Input.GetButtonDown("Fire1") && !GetComponent<Animation>().isPlaying)
        if (m_TriggerPress.GetStateDown(SteamVR_Input_Sources.RightHand) && !GetComponent<Animation>().isPlaying)
		{
			if(currentRound > 0){
				Shoot();
			}else{
				GetComponent<Animation>().Play("noAmmo");
				GetComponent<AudioSource>().PlayOneShot(noAmmoSound);
			}
		}
        //if(Input.GetKeyDown(KeyCode.R) && !GetComponent<Animation>().isPlaying)
        if (m_TriggerPress.GetStateDown(SteamVR_Input_Sources.LeftHand) && !GetComponent<Animation>().isPlaying)
        {
			Reload();

		}

	}

	void Shoot()
	{
			currentRound--;
		if(currentRound <= 0){
			currentRound = 0;
		}

			GetComponent<Animation>().CrossFade("Shoot");
			GetComponent<AudioSource>().PlayOneShot(flareShotSound);


			Rigidbody bulletInstance;
			bulletInstance = Instantiate(flareBullet,barrelEnd.position,barrelEnd.rotation) as Rigidbody; //INSTANTIATING THE FLARE PROJECTILE

			bulletInstance.useGravity = false;

			bulletInstance.AddForce(barrelEnd.forward * bulletSpeed); //ADDING FORWARD FORCE TO THE FLARE PROJECTILE

			// Instantiate(muzzleParticles, barrelEnd.position,barrelEnd.rotation);	//INSTANTIATING THE GUN'S MUZZLE SPARKS
	}

	void Reload()
	{
		if(spareRounds >= 1 && currentRound == 0){
			GetComponent<AudioSource>().PlayOneShot(reloadSound);
			spareRounds--;
			currentRound++;
			GetComponent<Animation>().CrossFade("Reload");
		}

	}
}
