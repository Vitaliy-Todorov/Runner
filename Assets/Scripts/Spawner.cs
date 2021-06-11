using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> platforms;
    [SerializeField]
    GameObject tilePlatform;

    private void Start()
    {
        //tilePlatform = platforms[platforms.Count - 1];
        //SpawnTile();
    }

    public void SpawnTile()
    {
        for (int i = 0; platforms.Count <= 3 && i <= 3; i++)
        {
            // Получаем последний созданный тайл (или platforms[platforms.Count - 1])
            Tile tile = tilePlatform.GetComponent<Tile>();
            tile.spawner = this;
            int randomInt = Random.Range(0, tile.nextTiles.Count);
            // Складываем то, насколько уже повёрнута платформа с тем, насколько нужно ещё повернуть
            float rotation = tile.rotation + tilePlatform.transform.rotation.eulerAngles.y;
            Quaternion rotationQ = Quaternion.AngleAxis(rotation, Vector3.up);
            Quaternion q = Quaternion.AngleAxis(tile.rotation, Vector3.up);
            Vector3 position = tilePlatform.transform.position + rotationQ * tile.distanceToTile;
            tilePlatform = Instantiate(tile.nextTiles[randomInt], position, rotationQ);
            // Сохраняется
            platforms.Add(tilePlatform);
        }

        Destroy(platforms[0]);
        platforms.RemoveAt(0);
        //удаляем лишнюю платформу
        if (platforms.Count > 3)
        {
            Destroy(platforms[0]);
            platforms.RemoveAt(0);
        }
    }
}
