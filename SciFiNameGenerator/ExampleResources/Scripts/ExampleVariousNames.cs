using UnityEngine;
using System.Collections;

public class ExampleVariousNames: MonoBehaviour
{
	//assign the nameGenerator-Prefab to this variable
    public  GameObject nameGeneratorPrefab;
    
	//via this variable you can later call the nameGenerator
	public  NameGen    nameGenerator;

	public  GUISkin    skin;

    private string     exampleName;
    private string     exampleNameWithRank;
	private string     exampleRank;
    private string     exampleShipName;
    private string     exampleShipNameWithTitle;

	void Start()
    {
        if(nameGeneratorPrefab)
        {
			//this creates an instance of the generator and assigns it to the nameGenerator-variable
            GameObject nameGeneratorTemp = Instantiate(nameGeneratorPrefab) as GameObject;
			nameGenerator = nameGeneratorTemp.GetComponent<NameGen>();

            CreateNewName();
			CreateNewNameWithRank();
			CreateNewRank();
            CreateNewShipName();
            CreateNewShipNameWithTitle();
        }
        else
            Debug.LogWarning("Assign the NameGenerator-Prefab to this script!", transform);
	}

    void OnGUI()
    {
        if (skin)
            GUI.skin = skin;
           
        GUI.Box(RectAdapt(384, 114, 512, 100), exampleName);
		if (GUI.Button(RectAdapt(128, 114, 246, 100), "New Full Name"))
            CreateNewName();

		GUI.Box(RectAdapt(384, 224, 512, 100), exampleNameWithRank);
		if (GUI.Button(RectAdapt(128, 224, 246, 100), "New Name\nwith Rank"))
            CreateNewNameWithRank();
        
		GUI.Box(RectAdapt(384, 334, 512, 100), exampleRank);
		if (GUI.Button(RectAdapt(128, 334, 246, 100), "New Rank"))
			CreateNewRank();

        GUI.Box(RectAdapt(384, 444, 512, 100), exampleShipName);
        if (GUI.Button(RectAdapt(128, 444, 246, 100), "New Shipname"))
            CreateNewShipName();

		GUI.Box(RectAdapt(384, 554, 512, 100), exampleShipNameWithTitle);
		if (GUI.Button(RectAdapt(128, 554, 246, 100), "New Shipname\nwith Title"))
			CreateNewShipNameWithTitle();
    }
	
    private void CreateNewName()
    {
		//this is how you get a name
		//you can call any function from the generator and immediately assign it to a string-variable
        exampleName = nameGenerator.GetName();
    }

	private void CreateNewNameWithRank()
	{
		exampleNameWithRank = nameGenerator.GetNameWithRank();
	}

	private void CreateNewRank()
	{
		exampleRank = nameGenerator.GetRank();
	}

	private void CreateNewShipName()
	{
		exampleShipName = nameGenerator.GetShipName();
	}

	private void CreateNewShipNameWithTitle()
    {
		exampleShipNameWithTitle = nameGenerator.GetShipNameWithTitle();
    }

    private Rect RectAdapt(int x, int y, int width, int height)
    {
        return new Rect((x*Screen.width)/1024, (y*Screen.height)/768, (width*Screen.width)/1024, (height*Screen.height)/768);
    }
}