using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Spawner spawner;

    public float minWanderTime = 0f;
    public float maxWanderTime = 0f;

    public float speed = 0.5f;
    public float maxDisplacement = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wander());
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wander(){


        // Idle phase
        float waitTime = Random.Range(minWanderTime, maxWanderTime);

        yield return new WaitForSeconds(waitTime);

        // Move phase

        float x = transform.position.x + Random.Range(-maxDisplacement/2, maxDisplacement);
        float y = transform.position.y + Random.Range(-maxDisplacement/2, maxDisplacement);

        Vector3 destination = new Vector3(x, y, 0);


        while (true) {

            Vector3 displacementVector = destination - transform.position;
            Vector3 finalPosition = transform.position + displacementVector.normalized * speed * Time.deltaTime;

            transform.position = new Vector3(finalPosition.x, finalPosition.y, transform.position.z);

            if (destination.x > transform.position.x){
                this.spriteRenderer.flipX  = true;
            } else {
                this.spriteRenderer.flipX  = false;
            }

            if (Vector3.Distance(transform.position, destination) < 2f) {
                break;
            }

            yield return new WaitForFixedUpdate();
        }
        
        StartCoroutine(Wander());
    }

    public void Eat(){
        CleanUp();
    }

    void OnBecameInvisible() {
        CleanUp();
    }

    private void CleanUp() {
        spawner.RemoveFish();
        Destroy(gameObject);
    }
}
