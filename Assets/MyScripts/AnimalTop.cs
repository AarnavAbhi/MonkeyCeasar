using UnityEngine;
using System.Collections;

public class AnimalTop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider colli){
		if (colli.gameObject.tag == "Player" && PlayerManager.Instance.amIAlive && gameObject.renderer.enabled) {
			transform.parent.GetComponent<ObstacleScript>().AnimalExplosion();	
		}
	}
}
