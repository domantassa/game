using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class TargetController : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "Target";


    private Rigidbody rb;
    private Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(targetTag))
        {
            FindObjectOfType<AudioManager>().Play("YouWonSound");
            player.WinGame();
        }
    }
}
