using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    enum Estado { Idle, Andando, Corriendo, Saltando, Disparando};
    Estado estado = Estado.Idle;

    public GameObject targetCircle;
    //Filtro de capas
    public LayerMask walkableLayer;

    Animator animator;
    NavMeshAgent agente;
        
    private void Start() {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            ManageMouseClick();
        }

        switch (estado) {
            case Estado.Idle:
                //NO HAGO NADA
                break;
            case Estado.Andando:
                ComprobarDestino();
                break;
            case Estado.Saltando:

                break;
            case Estado.Corriendo:

                break;
            case Estado.Disparando:

                break;
        }
    }

    private void ComprobarDestino() {
        if (!agente.pathPending) {
            if (agente.remainingDistance <= agente.stoppingDistance) {
                animator.SetBool("Andando", false);
                estado = Estado.Idle;
            }
        }     
    }

    private void ManageMouseClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rch;
        bool hasTouch = Physics.Raycast(ray, out rch, Mathf.Infinity, walkableLayer);
        if (hasTouch) {
            switch (estado) {
                case Estado.Idle:
                    Andar(rch);
                    break;
                case Estado.Andando:

                    break;
                case Estado.Saltando:

                    break;
                case Estado.Corriendo:

                    break;
                case Estado.Disparando:

                    break;
            }            
        }
    }
    private void Andar(RaycastHit rch) {
        targetCircle.transform.position = rch.point;
        targetCircle.transform.rotation = Quaternion.LookRotation(rch.normal);
        agente.destination = targetCircle.transform.position;
        animator.SetBool("Andando", true);
        estado = Estado.Andando;
    }
}
