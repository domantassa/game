using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collectibles;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject lifePickup;

    //[SerializeField]
    //GameObject spaceWarpPickup;

    [SerializeField]
    private int count = 400;

    [SerializeField]
    private int countHealth = 15;


    [SerializeField]
    private Vector3 size = new Vector3(19.5f, 9.5f, 500f);

    Options a;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void CreateCollectibles()
    {
        for (var i = 0; i < countHealth; i++)
        {
            CreateCollectible(lifePickup);
        }
        for (var i = 0; i < count; i++)
        {
            CreateCollectible(enemy);
        }

    }

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(
            Random.Range(0, size.x),
            Random.Range(0, size.y),
            Random.Range(0, size.z)
       );

        return transform.position + volumePosition - size / 2;
    }

    private void CreateCollectible(GameObject collectible)
    {
        Instantiate(
            collectible,
            GetRandomPosition(),
            collectible.transform.rotation,
            gameObject.transform
            );
    }

    // Start is called before the first frame update
    void Start()
    {
        
        CreateCollectibles();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
