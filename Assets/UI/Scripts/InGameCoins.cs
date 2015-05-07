using UnityEngine;
using System.Collections;

public class InGameCoins : MonoBehaviour {
	tk2dTextMesh textMesh;
	// Use this for initialization
	void Start () {
		textMesh = GetComponent<tk2dTextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = ""+ LevelManager.Instance.Coins ();
	
	}
}
