using UnityEngine;
using System.Collections;

/*      
 *      Sci-Fi Name Generator 1.0
 *      Created by Matthias Zarzecki, January 2015
 */

public class NameGen: MonoBehaviour
{
    public TextAsset fileLastNames;
    public TextAsset fileFirstNamesFemale;
    public TextAsset fileFirstNamesMale;
    public TextAsset fileRanks;
    public TextAsset fileRankPrefixes;
    public TextAsset fileShipNames;
    public TextAsset fileShipPrefixes;
    public TextAsset fileShipSuffixes;

    private string[] lastNames;
    private string[] firstNames;
    private string[] ranks;
    private string[] rankPrefixes;
    private string[] shipNames;
    private string[] shipPrefixes;
    private string[] shipSuffixes;

    private string[] letters             = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private string[] numeralsWithoutZero = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    private string[] numeralsWithZero    = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    void Awake()
    {
        //get last names
        if (fileLastNames)
            lastNames = importFile(fileLastNames);

        //get first names
        if (fileFirstNamesFemale && fileFirstNamesFemale)
            firstNames = importFile(fileFirstNamesMale.text + fileFirstNamesFemale.text);

        //get ranks
        if (fileRanks)
            ranks = importFile(fileRanks);

        //get rank prefixes
        if (fileRankPrefixes)
            rankPrefixes = importFile(fileRankPrefixes);

        //get ship names
        if (fileShipNames)
            shipNames = importFile(fileShipNames);

        //get ship suffixes
        if (fileShipSuffixes)
            shipSuffixes = importFile(fileShipSuffixes);

        //get ship prefixes
        if (fileShipPrefixes)
            shipPrefixes = importFile(fileShipPrefixes);
	}
	
	public string GetName()
	{
		string firstName  = GetRandomString(firstNames);
		string lastName   = GetRandomString(lastNames);
		string middleName = "";
		
		if(Random.Range(0, 100) <= 33)	//chance of 33% of getting an initial as middle name
			middleName = " " + GetRandomString(letters) + ".";
		
		return firstName + middleName + " " + lastName;
	}

	public string GetFirstName()
	{
		return GetRandomString(firstNames);
	}

	public string GetNameWithRank()
	{
		return GetRank() + " " + GetName();
	}

	public string GetRank()
	{
		string newRank = GetRandomString(ranks);
		
		if(Random.Range(0, 100) < 40)		//chance of 40% to get a rank-prefix
			newRank = GetRandomString(rankPrefixes) + " " + newRank;
		
		return newRank;
	}
    
	public string GetShipName()
	{
		string newPrefix = "";
		string newSuffix = "";
		
		if(Random.Range(0, 100) < 33)       //chance of X of having a prefix or suffix at all
		{
			//either get a prefix or a suffix
			if(Random.Range(0, 100) < 50)
				newPrefix = GetRandomString(shipPrefixes) + " ";
			else
				newSuffix = " " + GetRandomString(shipSuffixes);
		}
		
		return newPrefix + GetRandomString(shipNames) + newSuffix;
	}

	public string GetShipNameWithTitle()
	{
		return GetShipTitle () + " " + GetShipName ();
	}

	private string GetShipTitle()
	{
		string newTitle = "";
		
		for(int i = 0; i < Random.Range(2, 4); i++)	//ship-title always is 2 or 3 letters long
			newTitle += GetRandomString(letters);
		
		return newTitle;
	}
	  
    private string GetRandomString(string[] inputArray)
    {
        return inputArray[Random.Range(0, inputArray.Length)];
    }

    private string[] importFile(TextAsset inputFile)	//imports a textfile and returns an array with the names inside it
    {
		string entries = removeLineBreaks(inputFile.text);
		return entries.Split(new char[]{','}, System.StringSplitOptions.RemoveEmptyEntries);;
    }

	private string[] importFile(string inputString)		//imports a string and returns an array with the names inside it
    {
		string entries = removeLineBreaks(inputString);
		return entries.Split(new char[]{','}, System.StringSplitOptions.RemoveEmptyEntries);
    }

	private string removeLineBreaks(string inputString)	//removes the linebreaks from string
	{
		string newString = inputString.Replace("\n", "");
		return newString.Replace("\r", "");;
	}
}