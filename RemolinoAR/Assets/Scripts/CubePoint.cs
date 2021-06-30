using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePoint : MonoBehaviour
{
    [SerializeField] private int points;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.PlayPoints(points >= 0);
            gameManager.AddPoints(points);
            Destroy(gameObject, 0.2f);
        }
    }
}
