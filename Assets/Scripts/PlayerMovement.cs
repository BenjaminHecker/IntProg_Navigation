using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private LayerMask ground;

        private NavMeshAgent nav;
        private Animator anim;

        private Vector3 prevPos;

        private void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            nav.speed = speed;

            anim = GetComponent<Animator>();

            prevPos = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f, ground.value))
                {
                    nav.SetDestination(hit.point);

                    Debug.DrawRay(hit.point, Vector3.up, Color.green, 1f);
                }
            }

            float move = (transform.position - prevPos).magnitude / Time.deltaTime;
            prevPos = transform.position;

            anim.SetFloat("speed", Mathf.InverseLerp(0, speed, move));
        }
    }
}
