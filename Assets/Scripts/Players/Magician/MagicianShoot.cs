using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicianShoot : MonoBehaviour
{
    Transform player;
    Vector3 destination;
    public GameObject projectile;
    public Transform firePoint; // da dove spara, per ora sarà il player stesso, ma ho messo pubblico per un futuro cambiamento
    public float projectileSpeed = 30f;
    public float arcRange = 1f;
    private int forceCharge = 0;
    GameObject projectileObj;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        //firePoint = player; // per ora
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if(forceCharge<1000)forceCharge++;
            InstantiateAndGrow();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            ShootProjectile();
            forceCharge = 0;
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    ShootProjectile();
        //}
    }

    void ShootProjectile()
    {
        Ray ray = new Ray(player.position, player.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        //InstantiateProjectile();
        throwProjectile();
    }

    void InstantiateAndGrow()
    {
        if (forceCharge == 1)
        {
            projectileObj = Instantiate(projectile, firePoint.position, transform.rotation) as GameObject;
            projectileObj.transform.SetParent(player.transform);
        }
        else
        {
            GameObject particleBullet = projectileObj.transform.GetChild(0).gameObject;
            ParticleSystem ps = particleBullet.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startSize = forceCharge / 50;
        }
    }

    void throwProjectile()
    {
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        projectileObj.GetComponent<ProjectileTuT>().force = forceCharge;

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2f));
        Destroy(projectileObj, 5);

    }

    //void InstantiateProjectile()
    //{
    //    projectileObj = Instantiate(projectile, firePoint.position + new Vector3(0f, 0f, 0.5f), Quaternion.identity) as GameObject;
    //    projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;

    //    iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2f));
    //}
}
