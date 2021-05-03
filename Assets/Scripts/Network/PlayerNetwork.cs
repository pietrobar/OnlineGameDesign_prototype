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
            GetComponent<PlayerMovements>().enabled = true;//da fare sempre ma solo per il giocatore isMine
            //volevo abilitare tutti i componenti del player ma non riesco, quindi far' if a cascata
            string playerType = gameObject.name;
            if (playerType.Contains("Magician"))
                GetComponent<MagicianShoot>().enabled = true;
            if (playerType.Contains("ciccio"))
                GetComponent<ArcheryShoot>().enabled = true;
            if (playerType.Contains("Swordman"))
                GetComponent<SwordmanMovements>().enabled = true;
            GetComponent<PlayerAudio>().enabled = true;
            GetComponent<AudioSource>().enabled = true;//rumore dei passi
            gameObject.AddComponent<HeroHealth>().setHealthBar(GameObject.Find("HealthBar").GetComponent<HealthBar>());
        }
        else Destroy(cam); //se non sono io distruggo direttamente l'oggetto cam

    }

}
