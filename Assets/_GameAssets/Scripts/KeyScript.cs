using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    [SerializeField] GameObject Puerta;
    [SerializeField] GameObject generadorItem;
    [SerializeField] ParticleSystem ItemDestroy;
    [SerializeField] GameObject generadorPuerta;
    [SerializeField] ParticleSystem psPuerta;
    [SerializeField] AudioSource audioBoom;
    public Animator animatorPuerta;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            AbrirPuerta();
            audioBoom.Play();
            ParticleSystem psItem = Instantiate(ItemDestroy, generadorItem.transform.position, Quaternion.identity);
            ParticleSystem psDoor = Instantiate(psPuerta, generadorPuerta.transform.position, Quaternion.identity);
            psItem.Play();
            psDoor.Play();
            Destroy(this.gameObject);
        }        
    }

    private void AbrirPuerta() {
        animatorPuerta.SetBool("AbreteSesamo", true);
    }
}
