using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcheryShoot : MonoBehaviour
{
    [Range(50, 100)] public int chargeSpeed;
    Transform player;
    Vector3 destination;
    public GameObject projectile;
    public Transform firePoint; // da dove spara, per ora sarà il player stesso, ma ho messo pubblico per un futuro cambiamento
    private int forceCharge = 1;
    GameObject projectileObj;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        //firePoint = player; // per ora

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            
            forceCharge=(int)(forceCharge + Time.deltaTime *chargeSpeed);
            InstantiateAndGrow();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            ShootProjectile();
            forceCharge = 1;
        }
    }

    void ShootProjectile()
    {
        Ray ray = new Ray(player.position, player.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        throwProjectile();
    }

    void InstantiateAndGrow()
    {
        if (!animator.GetBool("carica"))//il caricamento si fa solo la prima volta
        {
            animator.SetBool("carica", true);
            projectileObj = Instantiate(projectile, firePoint.position , transform.rotation * Quaternion.AngleAxis(90, Vector3.up)) as GameObject;

            Physics.IgnoreCollision(projectileObj.GetComponent<MeshCollider>(), transform.root.GetComponent<CapsuleCollider>());
            projectileObj.transform.SetParent(firePoint.transform); // così da seguire il player

        }
        else
        {
            
        }
    }

    void throwProjectile()
    {
        animator.SetBool("carica", false);

        projectileObj.transform.parent = null;
        projectileObj.AddComponent<Rigidbody>();
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * forceCharge;
        projectileObj.GetComponent<BowTut>().force = forceCharge;
    }
}
