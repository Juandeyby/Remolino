using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    [SerializeField] private GameObject groupRailPrefab;
    [SerializeField] private GameObject[] groupRails;
    private float _speedUp = 30f;
    private float _speedRotation = 1.5f;

    private void Start()
    {

    }

    void Update()
    {
        Move();
        Rotation();
        NextRail();
    }

    private void Move()
    {
        foreach (GameObject rail in groupRails)
        {
            rail.transform.localPosition += Vector3.up * Time.deltaTime * _speedRotation;
        }
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speedUp);
    }

    private void NextRail()
    {
        for (int i = 0; i < groupRails.Length; i++)
        {
            if (groupRails[i].transform.localPosition.y >= 15f)
            {
                Destroy(groupRails[i]);
                groupRails[i] = Instantiate(groupRailPrefab, transform);
                groupRails[i].transform.localPosition = Vector3.down * 15f;
            }
        }        
    }
}