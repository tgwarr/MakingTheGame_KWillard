using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject bgCratePrefab;
	public GameObject obstaclePrefab;
	private Vector3 spawnLocation = new Vector3 (30, 0, 0);
	private float initialWait = 2;
	private float periodRep = 2;
	private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnObstacle", initialWait, periodRep);
		int bgBoxCount = 10;
		float bgWidth = GameObject.Find("Background").GetComponent<BoxCollider>().size.x;
		float spacing = bgWidth / bgBoxCount;
		for(int count = 0; count < bgBoxCount; count++)
		{
			Instantiate(bgCratePrefab, new Vector3(count * spacing,0,4.0f), bgCratePrefab.transform.rotation);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void SpawnObstacle()
	{
		if(playerController.gameOver == false)
		{
		Instantiate (obstaclePrefab, spawnLocation, obstaclePrefab.transform.rotation);
		}
	}
}
