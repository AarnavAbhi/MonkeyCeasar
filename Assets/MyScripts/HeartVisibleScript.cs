using UnityEngine;
using System.Collections;

public class HeartVisibleScript : MonoBehaviour {
	public Texture2D[] hearttexture = new Texture2D[7];
	// Use this for initialization
	void Start () {
		StartCoroutine ("StartHeartAnimation");
	}
	
	// Update is called once per frame
	void Update () {
		//print ("gameObject.renderer.enabled--------" + PlayerManager.Instance.amIAlive);
		if (PlayerManager.Instance.amIAlive)
						gameObject.transform.localScale = new Vector3 (10.2f, 9.1f, 1.0f);
		else
			gameObject.transform.localScale = new Vector3 (0f, 9.1f, 1.0f);
	}


	IEnumerator StartHeartAnimation()
	{
		//print ("gameObject.renderer.enabled--------" + PlayerManager.Instance.amIAlive);
		for(int i=0;i<hearttexture.GetLength(0);i++)
		{
			//print ("gameObject.renderer.enabled--------" + i);
			#if UNITY_5
			GetComponent<Renderer>().material.mainTexture = monkeyBananaThrowAnimation[monkeyBananaThrowCount];
			#else
			renderer.material.mainTexture = hearttexture[i];
			#endif
			yield return new WaitForSeconds(0.05f);
			if(i >= (hearttexture.GetLength(0)-1))
			{
				i=0;
			}
		}
	}

	//public void HeartVisibility
}
