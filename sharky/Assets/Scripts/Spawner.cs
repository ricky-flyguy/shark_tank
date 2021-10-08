using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject goodfishObject;
    public GameObject badFishObject;

    public int maxFishOnScreen = 12;
    private int numFishOnScreen;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    public float spawnPadding = 25f;

    public float maxX = 500;
    public float maxY = 500;


    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Spawn());
     }

    private IEnumerator Spawn() {

        // Idle phase
        float waitTime = Random.Range(minSpawnTime, maxSpawnTime);

        yield return new WaitForSeconds(waitTime);


        // Fish Count Check
        if (numFishOnScreen >= maxFishOnScreen) {

            while(true) {
                if (numFishOnScreen < maxFishOnScreen) {
                    break;
                }

                waitTime = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(waitTime);
            }
        }

        // Spawn
        float x = Random.Range(0, maxX);
        float y = Random.Range(0, maxY);

        Vector3 spawnPosition = new Vector3(x,y, 0);

        spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
        spawnPosition.Set(spawnPosition.x, spawnPosition.y, 0);

        if (Random.Range(1, 6) == 3){
            GameObject tempObject = Instantiate(badFishObject, spawnPosition, Quaternion.identity);
            numFishOnScreen++;
        }
        else {
            GameObject tempObject = Instantiate(goodfishObject, spawnPosition, Quaternion.identity);
            numFishOnScreen++;
        }

        StartCoroutine(Spawn());
    }

    public void RemoveFish() {
        numFishOnScreen --;
    }

}
