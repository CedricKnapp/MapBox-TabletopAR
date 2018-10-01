using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class ScreenCannon : MonoBehaviour {

    [SerializeField] private GameObject projectile;
    [SerializeField] private int maxAmmo = 3;
    [SerializeField] private float replenishTime = 5.0f;
    [SerializeField] private float shotForce = 750.0f;

    private int currentAmmo = 0;
    private static ScreenCannon instance;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~GETTERS~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public int MaxAmmo{
        get { return maxAmmo; }
    }

    public int CurrentAmmo{
        get { return currentAmmo; }
    }

    public static ScreenCannon Instance
    {
        get { return instance; }
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void Awake()
    {
        Assert.IsNotNull(projectile);
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }




    // Use this for initialization
    void Start () {
        StartCoroutine(ReplenishAmmo());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            FireShot();
        }
	}

    private IEnumerator ReplenishAmmo(){
        while (true) {
            currentAmmo = Mathf.Min(currentAmmo + 1, maxAmmo);
            yield return new WaitForSeconds(replenishTime);
        }
    }

    private void FireShot() {
        if (currentAmmo > 0 /*&& !EventSystem.current.IsPointerOverGameObject()*/){
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody projBody = newProjectile.GetComponent<Rigidbody>();
            projBody.AddForce(transform.forward * shotForce);
            currentAmmo--;
        }
    }
}
