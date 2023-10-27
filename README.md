# SPAproject
To use the app:
You need to create a new db using EF
Then run the project and create a new user, once logged in you can play the game, instructions of how everything works are in home.
There is persistance so you can close the tab, open it up again using shift + control + T and see that you are still logged in.
If you close the tab/log out mid game, the next time you press play you come back to the unfinished game that you then can finish playing.

# Issues
Sometimes when you launch the app and you are automatically logged in, you will see 401 unauthorized on some api calls (post and get), but it happens randomly and not consistently and i cant solve it, logging out and in solves it.
