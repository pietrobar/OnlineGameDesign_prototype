using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CastSpell : MonoBehaviour
{
    Transform player;
    Vector3 destination;
    public GameObject projectile;
    public Transform firePoint; // da dove spara, per ora sarà il player stesso, ma ho messo pubblico per un futuro cambiamento
    public float projectileSpeed = 30f;
    public float arcRange = 1f;
    private int forceCharge = 0;
    GameObject projectileObj;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        //firePoint = player; // per ora
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("carica"))
        {
            if (forceCharge < 1000) forceCharge++;
            InstantiateAndGrow();
        }
        else if (!anim.GetBool("carica"))
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
        destination = ray.GetPoint(1000);
        //InstantiateProjectile();
        throwProjectile(); ;
    }

    void InstantiateAndGrow()
    {
        if (forceCharge == 1)
        {
            projectileObj = Instantiate(projectile, firePoint.position, transform.rotation * Quaternion.AngleAxis(90, Vector3.up)) as GameObject;
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
