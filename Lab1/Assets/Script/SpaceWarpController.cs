using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class SpaceWarpController : MonoBehaviour
{
    [SerializeField]
    private string spaceWarpTag = "SpaceWarpTag";

    [SerializeField]
    private GameObject explosionPrefab;


    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(spaceWarpTag))
        {
            player.powerupsPicked += 1;
            CreateExplosionEffect(otherGameObject.transform.position);
            FindObjectOfType<AudioManager>().Play("SpaceWarpSound");
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            player.doSpaceWarp();
        }
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab, position + Vector3.forward * 10, Quaternion.identity);
    }
}
