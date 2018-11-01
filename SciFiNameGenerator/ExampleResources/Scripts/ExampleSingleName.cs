using UnityEngine;
using System.Collections;

public class ExampleSingleName: MonoBehaviour
{
	//assign the nameGenerator-Prefab to this variable	
	public  GameObject nameGeneratorPrefab;

	//via this variable you can later call the nameGenerator
	public  NameGen    nameGenerator;

	public  GUISkin    skin;
	public 	TextMesh   textDisplay;
	public 	GameObject objectDistplay;
	public  nameType   currentType = nameType.simpleName; 
	public  enum       nameType { simpleName, spaceShipName }
	
	void Start()
	{
		if(nameGeneratorPrefab)
		{
			//this creates an instance of the generator and assigns it to the nameGenerator-variable
			GameObject nameGeneratorTemp = Instantiate(nameGeneratorPrefab) as GameObject;
			nameGenerator = nameGeneratorTemp.GetComponent<NameGen>();
			
			CreateNewName();
		}
		else
			Debug.LogWarning("Assign the NameGenerator-Prefab to this script!", transform);
	}

	void Update()
	{
		if (objectDistplay)
			objectDistplay.transform.Rotate (Vector3.forward * -2.0f * Time.deltaTime);
	}
	
	void OnGUI()
	{
		if (skin)
			GUI.skin = skin;

		if (GUI.Button(RectAdapt(10, 10, 246, 100), "New Name"))
			CreateNewName();
	}
	
	private void CreateNewName()
	{
		if(textDisplay)
		{
			if(currentType == nameType.simpleName)
				textDisplay.text = nameGenerator.GetFirstName();			//this is how you get a name
			else
				textDisplay.text = nameGenerator.GetShipNameWithTitle();	//you can call any function from the generator and immediately assign it to a string-variable
		}
	}
	
	private Rect RectAdapt(int x, int y, int width, int height)
	{
		return new Rect((x*Screen.width)/1024, (y*Screen.height)/768, (width*Screen.width)/1024, (height*Screen.height)/768);
	}
}
