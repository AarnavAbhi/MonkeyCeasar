using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {
	public static GameOverManager Instance;
	public tk2dTextMesh[] finishTexts; 
	public GameObject Timer;
	public GameObject GameOver;
	// Use this for initialization
	void Awake () {
		Instance = this;
	}

	void OnEnable() {
		Timer.SetActive (true);
		GameOver.SetActive (true);
		int currentDist = (int)LevelGenerator.Instance.distance;
		int currentCoins = LevelManager.Instance.Coins();
		finishTexts[0].text = currentDist + "M";
		finishTexts[1].text = currentCoins.ToString();
		finishTexts[2].text = LevelManager.Instance.TorpedoExplodedGetter().ToString ();
		finishTexts[3].text = (currentDist + currentCoins + LevelManager.Instance.TorpedoExplodedGetter()).ToString ();
	}

	public void HideTimer() {
		Timer.SetActive (false);
		GameOver.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
