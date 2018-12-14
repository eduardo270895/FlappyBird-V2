using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour 
{
    
    public GameObject uppercolumn;
    public GameObject lowercolumn;                                   //The column game object.
    public int columnPoolSize = 5;									//Amount of columns 
	public float spawnRate = 4f;									//columns spawn.
	public float columnMaxup = 0f;                                  //Minimum y value of the column position.
	public float columnMinup = -2f;                                 //Maximum y value of the column position
    private float distance = -3f;                                   // this is the initial distance between the two columns 
    private GameObject[] uppercolumns;
    private GameObject[] lowercolumns;                              //Collection of pooled columns.
    private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

        //Initialize the columns collection.
        uppercolumns = new GameObject[columnPoolSize];
        lowercolumns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++)
		{
            //create the individual columns the upper one and the lower one.
            uppercolumns[i] = (GameObject)Instantiate(uppercolumn, objectPoolPosition, Quaternion.identity);
            lowercolumns[i] = (GameObject)Instantiate(lowercolumn, objectPoolPosition, Quaternion.identity);

        }
	}

    	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(columnMinup, columnMaxup);
     


            uppercolumns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            lowercolumns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition+distance);

            currentColumn ++;
            if (distance < 0.1)
            {
                distance = distance + 0.2f;
            }



            if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}

  
    
            
}