# Bilal Rehman 100921929
# Portfolio Piece
A portfolio piece from Bilal Rehman which features lively music, powerful sound effects and stunning shaders within Unity Engine. Along side programming for a feature-rich roll a ball game where you must collect all the coins to defeat the enemy while avoiding the obstacles. Music was created using SoundTrap and sound effects were sourced locally and edited using Adobe Audition. Shaders within the game are made in Unity Engine using Shader Lab.
Diagram:

class Audio Manager
  class Singleton
  {
    -static instance ; singleton
    -singleton()
    +getInstance() ; singleton
    +function()
  }
  singleton < client uses the getInstance()
  
What element of your game adopts the chosen pattern?
The audio manager adopts the singleton pattern. The original game that I made a while back had a audio manager script and a play audio script for some reason and a enemy audio script too. so to implement singleton pattern I combined all off the scripts into one. That way there is only one audio manager that handles all of the audio clips. 

Why is this pattern a good choice for the associated functionality?
this is a good choice for the associated functionality because my audio in the game was a mess. you had audio from player, level and enemy separated which made no sense. Also they are three different scenes so I don't want there to be multiple instances of the audio manager so using the singleton pattern made the most sense. also factory does not really fit in to this project as there is only one enemy and they are a set amount of coins so implementing factory would be useless.
