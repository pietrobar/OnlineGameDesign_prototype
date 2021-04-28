using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    GameObject[] targetPlayers;

    Transform target;
    NavMeshAgent agent;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayers = GameManager.instance.GetInstantiatedPlayers();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayers[0])
        {
            target = targetPlayers[0].transform;//TODO: si deve scegliere un personaggio random, o meglio ancora, quello piu' vicino
            if (target)
            {
                float distance = Vector3.Distance(target.position, transform.position);
                if (distance <= lookRadius && !animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit"))//vedo il player nel mio campo visivo
                {
                    agent.isStopped = false;
                    agent.SetDestination(target.position);//vado verso quella direzione

                    animator.SetBool("walk", true);
                    if (distance <= agent.stoppingDistance)//sono vicino al player
                    {
                        animator.SetBool("walk", false);
                        
                        animator.SetTrigger("attack");
                        FaceTarget();
                    }
                }else if (animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit"))
                {
                    agent.isStopped = true;
                    
                }
            }

            
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
