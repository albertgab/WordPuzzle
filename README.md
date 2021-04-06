## Project Goal:
It contributes to improving the language fluency and problem-solving skills of mostly kids and foreigners.

## Project Definition of Done:
1. The user is able to play and track his history of games.
2. Required features are fully implemented and tested both automatically and manually.
3. The Code is fully documented and ready to deploy.
4. The stakeholder is happy with the product.

## The Final Sprint:
**Sprint goal:** Get a fully working and tested program.
DONE                      |LEFT TO TEST       |NOT DONE
--------------------------|-----------------  |----------
Prepare a solution        |Playing            |Logout     
Create GitHub repository  |Displaying a level |Leaderboard
Create database           |Login              |History
Setup Entity Framework    |                   |Changing details
Registration              |                   |Add admin
Timer                     |                   |Add levels

## Sprint retrospective:
### What went well?
- I managed to make a pretty complex project.
- The work was committed often and regular.
- Error handling works great.
### What needs improvement?
- Test-driven development should be used more often.
- If the given approach took already too much time, try make it the other way.
- Make more quick breaks that give a fresh look.

## Project retrospective
### What have I learned?
- I was able to use in practice Entity Framework and WPF which gave me a depth understanding of a lot of their concepts.
- Good work organization is the key get things done on time.
- Better is to try some approach and eventually change it, than stick with it spending too much time.
### What would I do differently?
- I should do much more test-driven development.
- The model first approach should be used for implementing Entity Framework as it is more suitable for this kind of project.
- I should do more research on how to design the game.
### What would I next?
- Improve Front-End (better design of windows and pages, play with colours).
- Add admin functions like adding levels, adding new admins, changing details/removing users.
- Access to the leaderboard through the internet.
- Develop a mobile app.
- Multiplayer challenges through the internet.
- Allow cross-platform playing.

## Diagrams
Available class diagrams:
- BusinessClassDiagram
- TestClassDiagram
- WPFClassDiagram<br />
You can find them in the project folders corresponding with the name of the diagram.

## User Guide
In case of running the program you need to:
1. Install NET 5.0 if you don't have already installed.
2. Create a database by running the Create_Database1.sql file.
3. Populate database by running Populate_Database.sql file.<br />
Just to run the app:
4. Run WordPuzzleWPF\bin\Release\net5.0-windows\WordPuzzleWPF.exe.
To view the code:
4. Open WordPuzzle.sln in Visual Studio.
5. In WordPuzzleData\WordPuzzleContext.cs put our connection string in to optionsBuilder.UseSqlServer('connetction string').
