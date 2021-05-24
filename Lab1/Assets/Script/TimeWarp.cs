using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{
    [SerializeField]
    private string timeWarp = "SpaceWarpTag";

    [SerializeField]
    private GameObject text;

    [SerializeField]
    GameObject postProccesingTimeWarp;


    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag(timeWarp))
        {
            postProccesingTimeWarp.SetActive(true);
            player.powerupsPicked += 1;
            text.SetActive(true);
            FindObjectOfType<AudioManager>().Play("GreenPillSound");
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            player.BlueCylinder();
        }
    }

}
