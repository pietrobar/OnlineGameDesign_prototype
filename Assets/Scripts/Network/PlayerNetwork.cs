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
            GetComponent<SwordmanMovements>().enabled = true;//TODO: bisogna attivare solo lo script dedicato ogni player

        }
        else Destroy(cam); //se non sono io distruggo direttamente l'oggetto cam

    }

}
