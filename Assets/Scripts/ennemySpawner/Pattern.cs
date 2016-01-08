using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
* A pattern spawns a given number of enemies in a given configuration
*/
public class Pattern : MonoBehaviour {

    public List<CommonEnemy> possibleBlocks;
	//possibleBlocksProbabilities[i] is the relative probability of spawning possibleBlocks[i]
    public List<int> possibleBlocksProbabilities;

    private int totalProbs = 0;
	
    void Start () {

	    foreach(int prob in possibleBlocksProbabilities)
        {
            totalProbs += prob;
        }

        int randomSpawn = Random.Range(0, totalProbs);
        int i = 0;
        int currentSum = 0;
        bool found = false;

        while (i <= possibleBlocks.Count && found == false)
        {
            currentSum += possibleBlocksProbabilities[i];

			//If randomSpawn is overpassed, we have found the random enemy type at index i
            if (currentSum >= randomSpawn)
            {
                // We instantiate one enemy at each spot
                for (int s = 0; s < this.transform.childCount; s++) {
                    CommonEnemy newBlock = Instantiate(possibleBlocks[i]);
                    newBlock.transform.position = new Vector3(  this.transform.GetChild(s).position.x,
                                                                this.transform.GetChild(s).position.y,
                                                                this.transform.GetChild(s).position.z);
                    Destroy(this.transform.GetChild(s).gameObject);
                }
                
                found = true;
            }
            i++;
        }
	// The pattern just spawns the enemies; it is destroyed right afterwards
      Destroy(this.gameObject);
    }
    
}
