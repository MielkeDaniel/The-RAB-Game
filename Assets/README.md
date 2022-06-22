# Description

The-RAB-Game
A speed-based jump-and-run game
by Daniel Mielke and Sander Speitling

## Unity-Setup

The project can be opened in Unity v2020.3, however the game was made in Unity v2021.3^, which is why we `higly` recommend
to use v2021.3 or higher until v2022.1 to be able to see all the features.
Using an older version than v2021.3 will cause the user to take additional steps to run the game, because it uses an older version of the VFX-Graph
and the Universal-Render-Pipeline.

## Unity v2021.3^ Setup

In case the project won´t work right from the start you will maybe have to install the Universal RP and Visual Effect Graph under

- Window > Package Manager

Furthermore some objects in the game were made using Blender. All objects `should` be imported as FBX, however Unity might still ask
you to install Blender on your computer, in order for you to be able to see certain effects.

## Unity v2020.3 Setup

In case you still want to open the project using version 2020.3, you will have to take the following steps in order to be able to
see some of the textures and effects:

1. Reinstall the URP

- Window > Package Manager > search for Universal RP (Unity Registry Packages selected)
- Remove and Reinstall it

2. Reinstall the Visual Effect Grapf

- Window > Package Manager > search for Visual Effect Graph (Unity Registry Packages selected)
- (Remove and Reinstall) it

## Warnings and Errors

Once in a while there might pop up an error in the console verbaging:
`[Worker0] Trying to get RenderBuffer with invalid antiAliasing (must be at least 1)`  
or
`[Worker0] Attempting to get Camera relative temporary RenderTexture (width || height <= 0) via a CommandBuffer in a Sriptable Render Pipeline.`
These warnings seem to come from us, subsequently adding the URP to our project. This error is well known in the community, but there was no
bugfix published for this error yet.
However this error does `not` have any impact on the game itself.

When building the game you also migh get warnings in connection with some of the shaders.
Those are not related to our code and do not have any impact on the game itself.
