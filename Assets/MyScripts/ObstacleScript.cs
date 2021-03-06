﻿using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	Rigidbody rigidBodyObstacle;
	BoxCollider boxCollider;
	public bool flyingObstacle,isSkunk;
	bool startMovingAnimals;
	public Vector3 initialPos;
	void OnEnable(){
		if (flyingObstacle) {
			transform.localPosition = initialPos;	
			//startMovingAnimals = false;
		}
	}
	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider> ();
		if(isSkunk)
			boxCollider.size = new Vector3 (1.0f, 1.0f, 22.8f);
		else
			boxCollider.size = new Vector3 (0.75f, 0.7f, 22.8f);
		boxCollider.isTrigger = true;
		rigidBodyObstacle = gameObject.GetComponent<Rigidbody> ();
		if(rigidBodyObstacle == null)
			rigidBodyObstacle = gameObject.AddComponent<Rigidbody> ();
		//if (flyingObstacle == false) {
			rigidBodyObstacle.isKinematic = true;	
			rigidBodyObstacle.useGravity = false;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (flyingObstacle) {
			if(startMovingAnimals)
				transform.localPosition  += new Vector3(5.0f*Time.deltaTime,0,0); 
		}
	
	}

	void OnTriggerEnter(Collider colli)
	{
		if (colli.gameObject.tag.Equals ("Player")) {
			if(!IsTesting.instance.isTesting)
			{
				if(flyingObstacle)
				{
					foreach (Transform childTransform in transform)
					{
						if(childTransform.GetComponent<MovingAnimals>()!=null)
						{
							print ("FlyingDead");
							childTransform.GetComponent<MeshRenderer>().enabled = false;
						}
					}
				}
				#if UNITY_5
				PlayerManager.Instance.ObstacleCollided(gameObject.GetComponent<Collider>());	
				#else
				PlayerManager.Instance.ObstacleCollided(gameObject.collider);	
				#endif

			}
		}
		if (colli.gameObject.tag.Equals ("Weapon")) {
			Transform expParent = transform;
			Transform weaponTransform = colli.transform;
			if (expParent.name == "Torpedo")
			{
				//Notify torpedo manager
				expParent.transform.parent.gameObject.GetComponent<Torpedo>().TargetHit(true);
				LevelManager.Instance.TorpedoExplodedSetter();
			}
			//If the sub collided with something else
			else
			{
				if(flyingObstacle)
				{
					foreach (Transform childTransform in transform)
					{
						if(childTransform.GetComponent<MovingAnimals>()!=null)
						{
							childTransform.GetComponent<MeshRenderer>().enabled = false;
							//if(childTransform.gameObject.name == "SkunkBody")
							//	LevelManager.Instance.SkunkExplodedSetter();
							//if(childTransform.gameObject.name == "CrocodileBody")
							//	LevelManager.Instance.CrocodileExplodedSetter();
						}
					}
					if(expParent.name== "Skunk")
						LevelManager.Instance.SkunkExplodedSetter();
					if(expParent.name== "Crocodile")
						LevelManager.Instance.CrocodileExplodedSetter();
				}
				//Find the particle child, and play it
				ParticleSystem explosion = expParent.FindChild("ExplosionParticle").gameObject.GetComponent("ParticleSystem") as ParticleSystem;
				explosion.Play();
				//Disable the object's renderer and collider
				#if UNITY_5
				expParent.GetComponent<Renderer>().enabled = false;
				expParent.GetComponent<Collider>().enabled = false;
				#else
				expParent.renderer.enabled = false;
				expParent.collider.enabled = false;
				#endif

			}
			#if UNITY_5
			weaponTransform.GetComponent<Renderer>().enabled = false;
			weaponTransform.GetComponent<Collider>().enabled = false;
			#else
			weaponTransform.renderer.enabled = false;
			weaponTransform.collider.enabled = false;
			#endif
		}
	}

	public void AnimalMovementSetter(bool temp)
	{
		startMovingAnimals = temp;
		foreach (Transform childTransform in transform)
		{
			if(childTransform.GetComponent<MovingAnimals>()!=null)
			{
				print ("FlyingDead");
				childTransform.GetComponent<MeshRenderer>().enabled = true;
			}
		}
	}

	/* void PlayerCollidedWithTop()
	{
		print("Calling------------");
		Transform expParent = transform;
		if(flyingObstacle)
		{
			foreach (Transform childTransform in transform)
			{
				if(childTransform.GetComponent<MovingAnimals>()!=null)
				{
					childTransform.GetComponent<MeshRenderer>().enabled = false;
				}
			}
		}
		//Find the particle child, and play it
		ParticleSystem explosion = expParent.FindChild("ExplosionParticle").gameObject.GetComponent("ParticleSystem") as ParticleSystem;
		explosion.Play();
		//Disable the object's renderer and collider
		#if UNITY_5
		expParent.GetComponent<Renderer>().enabled = false;
		expParent.GetComponent<Collider>().enabled = false;
		#else
		expParent.renderer.enabled = false;
		expParent.collider.enabled = false;
		#endif

	}*/

	public void AnimalExplosion(){
		Transform expParent = transform;
		//Transform weaponTransform = colli.transform;
		if (expParent.name == "Torpedo")
		{
			//Notify torpedo manager
			expParent.transform.parent.gameObject.GetComponent<Torpedo>().TargetHit(true);
			LevelManager.Instance.TorpedoExplodedSetter();
		}
		//If the sub collided with something else
		else
		{
			if(flyingObstacle)
			{
				foreach (Transform childTransform in transform)
				{
					if(childTransform.GetComponent<MovingAnimals>()!=null)
					{
						childTransform.GetComponent<MeshRenderer>().enabled = false;
						//if(childTransform.gameObject.name == "SkunkBody")
						//	LevelManager.Instance.SkunkExplodedSetter();
						//if(childTransform.gameObject.name == "CrocodileBody")
						//	LevelManager.Instance.CrocodileExplodedSetter();
					}
				}
				if(expParent.name== "Skunk")
					LevelManager.Instance.SkunkExplodedSetter();
				if(expParent.name== "Crocodile")
					LevelManager.Instance.CrocodileExplodedSetter();
			}
			//Find the particle child, and play it
			ParticleSystem explosion = expParent.FindChild("ExplosionParticle").gameObject.GetComponent("ParticleSystem") as ParticleSystem;
			explosion.Play();
			//Disable the object's renderer and collider
			#if UNITY_5
			expParent.GetComponent<Renderer>().enabled = false;
			expParent.GetComponent<Collider>().enabled = false;
			#else
			expParent.renderer.enabled = false;
			expParent.collider.enabled = false;
			#endif
			
		}
	}
}
