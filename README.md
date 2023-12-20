# IntroAR
This repository contains the scripts we utilized for EN.601.454/654 in the "Interactive Design for Escape Rooms in AR" project. Four different interactions (Virtual Touch, Dynamic Visualization, Player-Modified Environments, and Player Perspective) were directly integrated into a comprehensive demo, and multiplayer functionality with TCP was investigated separately. Please reference 2312_Final_Report for a detailed write up on motivations and execution of each of the interactions.

A high level summary of each of the interaction styles is as follows:
- Virtual Touch
  - GKButtonManagerScript.cs: Controls the Virtual Touch and sequencing interactions for the three buttons used in the three button set puzzle.
- Dynamic Visualization
  - GKUIButtonScript.cs: Controls the dynamic visualization of red, green, and blue objects sets upon triggers from a UI button.
-  Player-Modified Environment
  - GKInventoryManager.cs: Loads or unloads the individual inventory panels when the inventory is toggled. The script additionally accounts for game progression, restricting total visualization until the first puzzle is completed.
  - GKInventoryPanel.cs: Provides functionality for the draggable UI panel, including the instantiation of the associated game object upon release of the UI panel
  - GKDraggable.cs: Provides functionality for the draggable 3D game object, placing the 3D game object at the ray traced corresponding world coordinate for a given touch.
  - GKSphereCollision.cs: Identifies correct placement of Sphere objects in the Tic Tac Toe grid by looking at collision tags and updating booleans accordingly.
  - XCollision.cs:Identifies correct placement of Cross objects in the Tic Tac Toe grid by looking at collision tags and updating booleans accordingly.
-  Player Perspective
-  
-  Transmission Control Protocol
  -  GameManager.cs: This script ties together the key functionality, including get the action maker’s player ID, spawning player and connection to different scene
  -  NetworkManager.cs: This script implements the core functionality of all networking related events, including creating, joining and leaving rooms
  -  ShootingSlider.cs: This script implements two self-oscillating slider bars that allows player to control the shooting position and force magnitude in Vuforia with AR camera, without implementing TCP functionalities yet


