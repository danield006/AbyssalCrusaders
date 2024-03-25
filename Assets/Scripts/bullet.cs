using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float reloadTimer = 5f;
    private float bulletTime;
    public GameObject projectile;
    public Transform spawnPoint;

    public Input input;
    public float bulletSpeed = 5f;

    [SerializeField] private ReloadBar reloadBar;

    // Start is called before the first frame update
    void Start()
    {
        bulletTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        reloadBar.UpdateReloadBar(reloadTimer, reloadTimer - bulletTime);
    }

    void Shoot() {
        if(bulletTime > 0) {
            bulletTime -= Time.deltaTime;
        }
        if(Input.GetMouseButton(0) && bulletTime <= 0) {
            GameObject bulletObj = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            bulletTime = reloadTimer;
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
            Destroy(bulletObj, 3f);

        }
    }

}
