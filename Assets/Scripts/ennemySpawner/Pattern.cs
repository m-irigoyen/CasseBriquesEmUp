using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pattern : MonoBehaviour {

    public List<CommonEnemy> possibleBlocks;
    public List<int> possibleBlocksProbabilities;

    private int totalProbs = 0;
    // Use this for initialization
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

            if (currentSum >= randomSpawn)
            {
                // We instantiate those enemies
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
      Destroy(this.gameObject);
    }
    
}
