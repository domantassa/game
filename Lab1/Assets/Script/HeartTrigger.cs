using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class HeartTrigger : MonoBehaviour
{

    [SerializeField]
    private string heartTag = "Heart";

    [SerializeField]
    private GameObject explosionPrefab;

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
        if (otherGameObject.CompareTag(heartTag))
        {
            CreateExplosionEffect(otherGameObject.transform.position);
            FindObjectOfType<AudioManager>().Play("HeartSound");
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            player.AddLives(1);
        }
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }
}