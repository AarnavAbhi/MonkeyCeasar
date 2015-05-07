using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {
	public static ShopManager Instance;
	public tk2dTextMesh CoinsText;

	// Use this for initialization
	void OnEnable () {
		CoinsText.text = DataManager.Instance.GetTotalCoins ().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
