using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform pointA;  // Premier point de patrouille
    public Transform pointB;  // Deuxième point de patrouille
    private Transform targetPoint;
    [SerializeField] float moveSpeed = 2f;
    Rigidbody MyRigidbody;

    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        MyRigidbody.freezeRotation = true;
        targetPoint = pointB;  // Commence par aller vers B
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        MyRigidbody.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);

        // Si l'ennemi est proche d'un point, il change de direction
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;  // Alterne entre A et B
            transform.Rotate(0f, 180f, 0f); // Retourne l'ennemi
        }
    }
}