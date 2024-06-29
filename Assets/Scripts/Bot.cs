using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Rigidbody player;

    [SerializeField] private Transform checkGround;

    [SerializeField] private LayerMask ground;

    [SerializeField] private float radius;

    [SerializeField]  private bool isGrounded;

    [SerializeField] private GameObject PlatformPref;

    void Update()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, radius, ground);

        if(Random.Range(1, 50) == 2 && isGrounded)
        {
            player.velocity = Vector2.up * 7f;
            Vector3 spawnPosition = transform.position + Vector3.up * -0.5f;
        }
    }
}
