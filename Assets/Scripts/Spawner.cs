using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> platforms;
    GameObject tilePlatform;

    private void Start()
    {
        tilePlatform = platforms[platforms.Count - 1];
        //SpawnTile();
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnTile();

        RotationLeft rotationLeft = platforms[1].gameObject.GetComponent<RotationLeft>();
        if (rotationLeft != null)
        {
            rotationLeft.rotate = true;
        }
        RotationRight rotationRight = platforms[1].gameObject.GetComponent<RotationRight>();
        if (rotationRight != null)
        {
            rotationRight.rotate = true;
        }

        rotationLeft = platforms[0].gameObject.GetComponent<RotationLeft>();
        if (rotationLeft != null)
        {
            rotationLeft.rotate = false;
        }
        rotationRight = platforms[0].gameObject.GetComponent<RotationRight>();
        if (rotationRight != null)
        {
            rotationRight.rotate = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        SpawnTile();
    }

    void SpawnTile()
    {
        //удаляем лишнюю платформу
        if (platforms.Count > 3)
        {
            Destroy(platforms[0]);
            platforms.RemoveAt(0);
        }

        for (int i = 0; platforms.Count <= 3 && i <= 3; i++)
        {
            //Получаем последний созданный тайл (или platforms[platforms.Count - 1])
            Tile tile = tilePlatform.GetComponent<Tile>();
            int randomInt = Random.Range(0, tile.nextTiles.Count - 1);
            //int randomInt = randomFloat % 1;
            //Создаём таил из возможных последующих и на определённом для этого тайла растоянии, сохраняя его углы
            tilePlatform = Instantiate(tile.nextTiles[randomInt], (tilePlatform.transform.position + tile.distanceToTile), tile.nextTiles[randomInt].transform.rotation);
            //Помещаем в родительский объект
            tilePlatform.transform.SetParent(transform);
            platforms.Add(tilePlatform);
        }
    }
}
