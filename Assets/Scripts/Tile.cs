using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<GameObject> nextTiles = new List<GameObject>();
    public Vector3 distanceToTile;
    public Spawner spawner;
}
