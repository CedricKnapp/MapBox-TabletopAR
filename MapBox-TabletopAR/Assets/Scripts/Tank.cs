using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject spawnPlaceHolder;
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private float fireRate = 5.0f;
    [SerializeField] private float shotForce = 1500.0f;
    [SerializeField] private float moveSpeed = 0.2f;
    [SerializeField] private float travelTime = 0.01f;
    [SerializeField] private float killHeight = -10.0f;

    [SerializeField] private int ROTATION_STEPS = 8; //Num of rotation steps in each direction 
    private int rotateCounter;
    private RotationDir randRotDir = RotationDir.None;

    enum RotationDir {Clockwise, CounterClockwise, None}

    void Start () {
        rotateCounter = ROTATION_STEPS;

        StartCoroutine(FireProjectile());
        StartCoroutine(Move());
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= killHeight) {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Projectile")) {
            StartCoroutine(DestroySelf());
        }
    }

    private IEnumerator FireProjectile() {
        yield return new WaitForSeconds(fireRate);
        while (true) {
            GameObject bullet = Instantiate(projectile,
                spawnPlaceHolder.transform.transform.position,
                spawnPlaceHolder.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = (bullet.transform.up * -1 * shotForce);
            Destroy(bullet, 8.0f);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private IEnumerator DestroySelf() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator Move() {
        float time = 0.0f;
        while (time < travelTime) {
            time += Time.deltaTime;
            transform.Translate(transform.forward * -1 * moveSpeed * Time.deltaTime);
            yield return null;
        }

        //transform.Rotate(rotationAxis, Random.Range(0, 360));

        if (randRotDir == RotationDir.Clockwise) {
            transform.Rotate(rotationAxis,
                Mathf.Max(transform.eulerAngles.z + Random.Range(3, 7), -360));
        } else if (randRotDir == RotationDir.CounterClockwise) {   
            transform.Rotate(rotationAxis,
                Mathf.Min(transform.eulerAngles.z - Random.Range(3, 7), 360));
        }

        //Regenerate the rotation direction
        if (rotateCounter <= 0) {
            randRotDir = GenerateRandRotNum();
            rotateCounter = ROTATION_STEPS;
        }

        rotateCounter--;
        StartCoroutine(Move());
    }

    private RotationDir GenerateRandRotNum() {
        switch(Random.Range(0, 3)) {
            case 0:
                return RotationDir.None;
            case 1:
                return RotationDir.Clockwise;
            case 2:
                return RotationDir.CounterClockwise;
            default:
                return RotationDir.None;
        }
    }
}
