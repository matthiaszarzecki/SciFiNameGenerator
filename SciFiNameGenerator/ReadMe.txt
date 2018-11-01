
Thanks for getting the Sci-Fi NameGenerator!

This tool has been built with the purpose of giving you access to a wide variety of cool-sounding names, ranks to use in your
game. Each name has been hand-picked, which means only impactful entries are present in this collection.

In addition to character-names you also get the ability to create names for Ships and other vehicles (i.e. "USS Enterprise"),
and the ability to create unique ranks to use in your game, like "Breveted Commander".

Full Names: 7.867.827 possible
Ranks:          1.312 possible
Ship-Names:    29.700 possible

Here is how it works:

///1. Location of Example-Scenes
In the folder SciFiNameGenerator you'll the scenes ExampleSpaceShip, ExampleElephants, and ExampleVariousNames, in which you can
see how the scripts are set up. ExampleElephant shows how to get a simple first name, ExampleSpaceShip show shipnames, and
ExampleVariousNames, shows you how to get a wide array of names, shipnames and ranks.

///2. How to get a random name
In order to use it you have to instantiate a copy of the NameGenerator-prefab and assign it to a variable in the script that
will call it. In the ExampleSpaceShip-scene that is the ControllerSingleName, which has to exist in the scene. Once the NameGenerator
has been created, you can access the name-functions.

Here is how the creation works in the ExampleSingleName-script, which you can find in SciFiNameGenerator/ExampleResources/Scripts:

    public GameObject nameGeneratorPrefab;
    private NameGen nameGenerator;
  
    GameObject nameGeneratorTemp = Instantiate(nameGeneratorPrefab) as GameObject;
    nameGenerator = nameGeneratorTemp.GetComponent<NameGen>();

Once the NameGenerator has been created, you can get names from it.

    String characterName = nameGenerator.GetName();

you can then use the string anywhere you like, like naming characters or ships.

///3. How data files work
Each name-textfile is a list of names, separated by commas (','), with each entry on a new line. This is for
better readability and not strictly necessary, as the line breaks are removed once the file is read in.

Afterwards the program checks for commas and adds the names to its storage accordingly. As it checks
for commas you can also have spaces in names (like "de Raisx" for a last name).

The files itself are assigned to variables inside the NameGenerator-Prefab. Assigning them via variables allows you to
easily swap out files for other sets.

///4. Adding new names to lists
If you have some cool names you want to add to the NameGenerator, open up the file you want to add them to (like
FirstNamesFemale.txt if you want to add a typically female first name) and add it at the bottom of the file!
Make sure to separate each entry with a comma (',').

Similarly, if there turns out to be a name in the list you do not like, you can just delete it from the list.

///5. How to create a new custom name-set
If you want to create a list of names of a certain type that isn't already present, you can easily make your own.

Let's say you want to make a list of names for Horses. Start by creating a text-file called "NamesHorses.txt". Then
add the names to it, separating each with a comma.

    Pegasus,
    Secretariat,
    Buttercup,
    Dash,
    Blackie,

For a simple way to use it you can add it to the NameGenerator-prefab instead of an existing file, and then use the
corresponding function. If you add it in fileFirstNamesMale-slot, you can get the names with the GetFirstName()-
function.

///6. How to adapt the code with your own functions
If you feel you are good enough you can also adapt the code to create your own function. For the horse-name-example,
it would work like this:

At the beginning of the script, add these lines:

    public TextAsset fileHorseNames;
    private string[] horseNames;

Add these lines to the Awake()-function:

    void Awake()
    {
        if fileHorseNames;
            horseNames = importFile(fileHorseNames);
    }

Then add this function to the script:

    public string GetHorseName()
    {
        return GetRandomStringhorseNames;
    }
	
Once the NameGenerator has been set up (described in point 2, above), with the text-file assigned to the fileHorseNames-variable,
you can get a horse name by calling the GetHorseName()-function.

    string newHorseName = nameGenerator.GetHorseName();
	
And that's it!

Now go out and have fun!
-Matthias

Matthias Zarzecki
@IcarusTyler
www.matthewongamedesign.com