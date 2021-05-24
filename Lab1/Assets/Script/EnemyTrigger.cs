using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]
    private string enemyTag = "Enemy";
    private string wallTag = "Wall";

    [SerializeField]
    private GameObject explosionPrefab;

    private Rigidbody rb;
    private Player player;

    private void Awake()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
       player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if(otherGameObject.CompareTag(enemyTag))
        {
            CreateExplosionEffect(otherGameObject.transform.position);
           
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            player.TakeDamage();
        }
        else if(otherGameObject.CompareTag(wallTag))
        {
            player.LoseGame();
        }
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }
}
