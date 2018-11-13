using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    public GameObject targetCircle;
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
        if (agente.remainingDistance <= agente.stoppingDistance) {
            animator.SetBool("Andando", false);
        }
    }

    private void ManageMouseClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rch;
        bool hasTouch = Physics.Raycast(ray, out rch);
        if (hasTouch) {
            targetCircle.transform.position = rch.point;
            targetCircle.transform.rotation = Quaternion.LookRotation(rch.normal);
            agente.destination = targetCircle.transform.position;
            animator.SetBool("Andando", true);
        }
    }

}
