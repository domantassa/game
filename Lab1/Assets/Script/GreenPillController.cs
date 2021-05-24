using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class GreenPillController : MonoBehaviour
{
    [SerializeField]
    private string greenPillTag = "GreenPill";

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    GameObject postProccesingGreenPill;


    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(greenPillTag))
        {
            postProccesingGreenPill.SetActive(true);
            text.SetActive(true);
            player.powerupsPicked += 1;
            CreateExplosionEffect(otherGameObject.transform.position);
            FindObjectOfType<AudioManager>().Play("GreenPillSound");
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            player.GainMovementAbilities();
        }
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }
}
