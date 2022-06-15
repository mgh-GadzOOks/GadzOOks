

# GadzOOks
Object-oriented text-based adventure. My (Michael Hopper) personal project, designed to implement and combine a variety of programming concepts I know. Furthermore, as an opportunity to learn new concepts to solve problems, increase my understanding of C#, Github, and to have practical practice for planning and documentation. Intention is not to have a designated end goal, but to be highly scalable, procedural and to continue adding features and complexity as desired. Created first as a console application to limit focus on UI and concentrate on code, objects, and logic; plan to create mobile app and windows form versions.

> Updated 5/9/2022

## DOXYGEN DOCUMENTATION

>4/21/2022

Doxygen looks at the specifically formatted comments I have made and automatically generates formatted documentation.
[https://raw.githack.com/](https://raw.githack.com/)  is being used to allow the below link to open `Doxygen_Documentation/html/index.html` from this repository.

[HTML Documentation Webpage](https://raw.githack.com/mgh-GadzOOks/GadzOOks_CS_Console/master/Doxygen_Documentation/html/index.html)

## PROGRESS PICTURES

>4/8/2022

Splash Screen (all ASCII art text generated from [patorjk.com](https://patorjk.com/software/taag/#p=display&f=Big&t=))
![Splash Screen](/Images/SplashScreen.png)

Main Menu and general limited menu validation example
![Main Menu](/Images/MainMenu.png)

Options menu screens
![Main Options Menu](/Images/MainOptionsMenu.png)
![Text Speed Options Menu](/Images/TextSpeedOptionsMenu.png)

Example game text being displayed
![Game Text](/Images/GameText.png)

Pause menu (displayed by hitting "P" key after above text)
![Pause Menu](/Images/PauseMenu.png)

Text log (displayed by hitting "L" key after above text)
(text is displayed from most recently logged to oldest)
![Text Log](/Images/TextLog.png)

## COMPLETED AND TO-DOS
> 4/8/2022
 - [X] Splash screen which leads to a main menu
 - [X] Main menu with options and quit.
 - [X] Letter entry, which is validated, for user input on limited menus.
 - [X] Text which can be displayed at different speeds.
 - [X] Ability to open a menu (pause menu) with options and quit between screens of text being displayed.
 - [X] Ability to open a log of previously displayed text between screens of text being displayed.
 - [X] Game text displayed at bottom of pre-sized console window, allowing space for other relevant diagrams or text to be displayed on the top half.
 - [ ] System to take in and validate user made colloquial text.
 - [ ] Player avatar to control and interact with text based environment and actors through.
 - [ ] Tutorial and user entry of player avatar basic information
 - [ ] Environment system.
 - [ ] Actors and objects.
 - [ ] Environment and actor response to player interaction.
 - [ ] System by which information from player, environments, objects, and actors are colloquialized and displayed in text.

## CONCEPTUALIZATION NOTES

>4/8/2022

 - Environment has to be created first because all other game objects are inside whatever environment the player avatar is currently in.
 - Player avatar is equally important to environment because it is the tether to and view point for logical game world.
 - Player avatar properties and methods (?)
	 - What makes up the player? What can be delegated to other entities?
	 - How does an avatar interact with the environment? How and by what is this conveyed to the player?
	 - Inspect(environment/actor/object) (maybe it's own class depending on scope) The eyes of the avatar take in the environment/actor/object.
 - Environment properties and methods (?)
	 - What makes up the environment? What can be delegated to other entities?
	 - What can the environment do?
	 > 4/21/2022
	 
	 - Environment is made with a 2D array property which makes up the area of the environment
	 - Array elements of the area hold information on the ground that makes up that area (grass, wood floor, etc.) and what is on that tile (lamp, chair, monster, etc.)
	> 5/9/2022

	- Starting point should be generic and scalable location: place to hold character. Detail should be added later, not required to start.
	>6/15/2022

	- Locations are created using an array of 2D arrays. Each 2D array is a coordinate based gird and is referred to as a layer. Each layer holds different information about the location for a particular grid coordinate. Currently, this is separated into: walls, textures, static objects, interactable objects, characters, and description layers.
> Written with [StackEdit](https://stackedit.io/).
