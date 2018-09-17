using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	[SerializeField] private GameObject startScreenUI;
	[SerializeField] private GameObject gameplayUI;
	[SerializeField] private Image[] ammoImages;
	[SerializeField] private Sprite fullAmmoSprite;
	[SerializeField] private Sprite emptyAmmoSprite;
	[SerializeField] private Text scoreText;

	private void Awake() {
		Assert.IsNotNull(startScreenUI);
		Assert.IsNotNull(gameplayUI);
		Assert.IsNotNull(ammoImages);
		Assert.IsNotNull(fullAmmoSprite);
		Assert.IsNotNull(emptyAmmoSprite);
		Assert.IsNotNull(scoreText);
	}

	// Use this for initialization
	void Start () {
		Assert.IsNotNull(GameManager.Instance);
	}
	
	// Update is called once per frame
	void Update () {
		SetScreen();
		if (gameplayUI.activeSelf) {
			UpdateAmmo();
			UpdateScore();
		}
	}

	private void SetScreen() {
		gameplayUI.SetActive(GameManager.Instance.GameRunning);
		startScreenUI.SetActive(!GameManager.Instance.GameRunning);
	}

	private void UpdateAmmo() {
		for (int i = 0; i < ammoImages.Length; i++) {
			if (i < ScreenCannon.Instance.CurrentAmmo) {
				ammoImages[i].sprite = fullAmmoSprite;
			}
			else {
				ammoImages[i].sprite = emptyAmmoSprite;
			}
		}
	}

	private void UpdateScore() {
		scoreText.text = GameManager.Instance.Score.ToString();
	}
}
