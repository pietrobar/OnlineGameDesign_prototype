using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : Photon.MonoBehaviour
{
    public GameObject cam;
    
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.isMine)
        {
            GetComponent<PlayerMovements>().enabled = true;
            GetComponent<MagicianShoot>().enabled = true;//TODO: bisogna attivare solo lo script dedicato ogni player
            gameObject.AddComponent<HeroHealth>().setHealthBar(GameObject.Find("HealthBar").GetComponent<HealthBar>());
        }
        else Destroy(cam); //se non sono io distruggo direttamente l'oggetto cam

    }

}
