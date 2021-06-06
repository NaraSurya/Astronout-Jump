using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Sprite cloud;
    public Sprite ground;
    private bool isCloud;

    public int numberOfPlatform = 50;
    public float levelWidht = 3f;
    public float levelHeight = 1.5f;
    public int probability = 10;

    private float min_speed = 0.05f;
    private float max_speed = 0.1f;

    Vector3 spawnPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SlowUpdate", 5.0f, 10.0f);
        
        for(int i = 0; i <= numberOfPlatform; i++){
            this.isCloud = Random.Range(1 ,11) % probability == 0;
            if(isCloud){
                platformPrefab.GetComponent<SpriteRenderer>().sprite = cloud;
                platformPrefab.GetComponent<Transform>().localScale =  new Vector3(0.1f,0.1f,1);
                platformPrefab.GetComponent<platform>().isCloud = true;
            }else {
                 platformPrefab.GetComponent<SpriteRenderer>().sprite = ground;
                 platformPrefab.GetComponent<Transform>().localScale =  new Vector3(0.2f,0.2f,1);
                 platformPrefab.GetComponent<platform>().isCloud = false;
            }
            platformPrefab.GetComponent<platform>().speed = min_speed;
            spawnPosition.y += levelHeight;
            spawnPosition.x = Random.Range(-levelWidht , levelWidht);
            Instantiate(platformPrefab,spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void SlowUpdate()
    {
            probability = Mathf.CeilToInt(probability/2.0f);
            min_speed = (min_speed == max_speed)? max_speed : min_speed + 0.01f;
           
            int count = 0;
            for(int i = 0; i <= numberOfPlatform; i++){
                this.isCloud = Random.Range(1 ,11) % probability == 0;
                if(isCloud){
                    count = count + 1;
                    platformPrefab.GetComponent<SpriteRenderer>().sprite = cloud;
                    platformPrefab.GetComponent<Transform>().localScale =  new Vector3(0.1f,0.1f,1);
                    platformPrefab.GetComponent<platform>().isCloud = true;
                }else {
                        platformPrefab.GetComponent<SpriteRenderer>().sprite = ground;
                        platformPrefab.GetComponent<Transform>().localScale =  new Vector3(0.2f,0.2f,1);
                        platformPrefab.GetComponent<platform>().isCloud = false;
                }
                platformPrefab.GetComponent<platform>().speed = min_speed;
                spawnPosition.y += levelHeight;
                spawnPosition.x = Random.Range(-levelWidht , levelWidht);
                Instantiate(platformPrefab,spawnPosition, Quaternion.identity);
            }
             Debug.Log("dibuat " + count.ToString());

       }
}
