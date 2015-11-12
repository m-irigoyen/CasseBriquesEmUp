using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnnemySpawner : MonoBehaviour {

    public List<Pattern> patterns;
    public List<int> patternProbabilities;

    public float spawnRate;

    private float timer = 0.0f;
    private int totalProbs = 0;

    // Use this for initialization
    void Start () {
        foreach(int p in patternProbabilities)
        {
            totalProbs += p;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > spawnRate)
        {
            timer = 0.0f;

            int randomSpawn = Random.Range(0, totalProbs);
            int i = 0;
            int currentSum = 0;
            bool found = false;

            while (i <= patterns.Count && found == false)
            {
                currentSum += patternProbabilities[i];
                
                if(currentSum >= randomSpawn)
                {
                    Instantiate(patterns[i]);
                    found = true;
                }
                i++;
            }
            
        }
	}
}
