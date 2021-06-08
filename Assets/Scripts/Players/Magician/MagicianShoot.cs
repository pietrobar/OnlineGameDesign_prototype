using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicianShoot :Photon. MonoBehaviour
{
    Transform player;
    Vector3 destination;
    public GameObject projectile;
    public Transform firePoint; // da dove spara, per ora sarà il player stesso, ma ho messo pubblico per un futuro cambiamento
    public float projectileSpeed = 30f;
    public float arcRange = 1f;
    private int forceCharge = 0;
    GameObject projectileObj;
    private bool fire1Pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        //firePoint = player; // per ora
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inGame)
        {
            if (Input.GetButton("Fire1"))
            {
                fire1Pressed = true;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                fire1Pressed = false;
                ShootProjectile();
                forceCharge = 0;
            }
        } 
    }

    private void FixedUpdate()
    {
        if (fire1Pressed)
        {
            if (forceCharge < 1000) forceCharge++;
            InstantiateAndGrow();
        }
    }

    void ShootProjectile()
    {
        Ray ray = new Ray(player.position, player.forward);
        destination = ray.GetPoint(1000);
        //InstantiateProjectile();
        throwProjectile();
    }

    void InstantiateAndGrow()
    {
        //todo: si dovra' aggiungere l'animazione qui 
        photonView.RPC("InstantiateAndGrowRPC", PhotonTargets.All, forceCharge);
    }

    [PunRPC]
    void InstantiateAndGrowRPC(int forceCharge)
    {
        if (forceCharge == 1)
        {
            projectileObj = Instantiate(projectile, firePoint.position, transform.rotation) as GameObject;
            projectileObj.transform.SetParent(firePoint.transform);//per fare seguire il player mentre si muove
        }
        else
        {
            if (projectileObj) // se collide mentre l'abbiamo ancora in mano (magari siamo troppo vicino ad un nemico)
            {
                projectileObj.transform.position = firePoint.position;

                GameObject particleBullet = projectileObj.transform.GetChild(0).gameObject;
                ParticleSystem ps = particleBullet.GetComponent<ParticleSystem>();
                ParticleSystem.MainModule psmain = ps.main;
                psmain.startSize = forceCharge / 50;
            }

        }
    }

    void throwProjectile()
    {
        //todo: si dovra' aggiungere l'animazione qui 
        object[] ps = { destination, forceCharge };
        photonView.RPC("ThrowProjectileRPC", PhotonTargets.All, ps);
    }

    [PunRPC]
    void ThrowProjectileRPC(Vector3 dest, int forceCharge)
    {
        if (projectileObj) // se collide mentre l'abbiamo ancora in mano (magari siamo troppo vicino ad un nemico)
        {
            projectileObj.GetComponent<Rigidbody>().velocity = (dest - firePoint.position).normalized * projectileSpeed;
            projectileObj.GetComponent<ProjectileTuT>().force = forceCharge;

            iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2f));
            Destroy(projectileObj, 5);
        }

    }
}
