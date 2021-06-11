using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Spawner spawner;

    public List<GameObject> nextTiles = new List<GameObject>();
    public Vector3 distanceToTile;
    public float rotation;

    public List<Transform> curve1;
    public List<Transform> curve2;
    public List<Transform> curve3;

    private void OnTriggerEnter(Collider other)
    {
        spawner.SpawnTile();
    }
}
