

# GadzOOks
Object-oriented text-based adventure

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

## DOXYGEN DOCUMENTATION

>4/21/2022

Pulled from `Doxygen_Documentation`.
Doxygen looks at the specifically formatted comments I have made and automatically generates formatted documentation.
[https://raw.githack.com/](https://raw.githack.com/)  allows the below link to open `Doxygen_Documentation/html/Index.html`
[HTML Documentation Webpage](https://raw.githack.com/mgh-GadzOOks/GadzOOks_CS_Console/master/Doxygen_Documentation/html/index.html)


> Written with [StackEdit](https://stackedit.io/).
