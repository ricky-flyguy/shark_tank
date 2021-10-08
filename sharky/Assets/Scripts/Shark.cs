using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    
    GameManager gameManager;

    bool isTouchDown = false;

    public float speed; 

    Vector3 cachedPosition;

    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void HandleTouch(){
        if (Input.GetMouseButtonDown(0)) {
            isTouchDown = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isTouchDown = false;
        }

        if (isTouchDown) {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 displacementVector = touchPosition - transform.position;
            Vector3 finalPosition = transform.position + displacementVector.normalized * speed * Time.deltaTime;

            transform.position = new Vector3(finalPosition.x, finalPosition.y, transform.position.z);

            if (touchPosition.x > transform.position.x){
                this.spriteRenderer.flipX  = true;
            } else {
                this.spriteRenderer.flipX  = false;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "good_fish"){
            other.gameObject.GetComponent<Fish>().Eat();
            gameManager.IncrementCaughtFish();
            Debug.Log("good");
        }
        else if (other.gameObject.tag == "bad_fish"){
            other.gameObject.GetComponent<Fish>().Eat();
            gameManager.Decrementhearts();
            Debug.Log("bad");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        HandleTouch();
        
    }
}
