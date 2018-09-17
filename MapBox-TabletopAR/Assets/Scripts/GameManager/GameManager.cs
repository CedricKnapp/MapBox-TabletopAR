using System.Collections;
using System.Collections.Generic;
using UnityARInterface;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameStarted = false;
    private bool gameRunning = false;
    private int score = 0;
    private static GameManager instance;

    public bool GameStarted { get {return gameStarted;}}
    public bool GameRunning { get { return gameStarted; } }
    public int Score { get { return score; } }
    public static GameManager Instance { get { return instance; } }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        ARInterface.planeAdded += HandlePlaneAdded;
        ARInterface.planeRemoved += HandlePlaneRemoved;
	}
	
    public void EnemyHit() {
        score++;
    }

    public void BuildingHit() {
        score = Mathf.Max(0, score - 5);
    }

    private void HandlePlaneAdded(BoundedPlane plane) {
        gameStarted = true;
        gameRunning = true;
    }

    private void HandlePlaneRemoved(BoundedPlane plane) {
        gameRunning = false;
    }
}
