## User Guide
In case of running the program you need to:
1. Install NET 5.0 if you haven't already.
2. Create a database by running the Create_Database1.sql file.
3. Populate database by running Populate_Database.sql file.<br />
Just to run the app:
4. Run WordPuzzleWPF\bin\Release\net5.0-windows\WordPuzzleWPF.exe.<br />
To view the code:
4. Open WordPuzzle.sln in Visual Studio.
5. In WordPuzzleData\WordPuzzleContext.cs put our connection string in to optionsBuilder.UseSqlServer('connetction string').
  
## Project Goal:
It contributes to improving the language fluency and problem-solving skills of mostly kids and foreigners.

## Project Definition of Done:
1. The user is able to play and track his history of games.
2. Required features are fully implemented and tested both automatically and manually.
3. The Code is fully documented and ready to deploy.
4. The stakeholder is happy with the product.

## Sprint no. 1:
**Sprint goal:** Get a fully working and tested program.

DONE                      |LEFT TO TEST       |NOT DONE
--------------------------|-----------------  |----------
Prepare a solution        |Playing            |History   
Create GitHub repository  |Displaying a level |Add admin
Create database           |Login              |Add levels
Setup Entity Framework    |                   |Changing details
Registration              |                   |
Timer                     |                   |
Leaderboard||
Logout ||

![Before the first Sprint](Screenshots_of_backlog/Before_Sprint_1.jpg)


### Sprint retrospective:
#### What went well?
- I managed to make a pretty complex project.
- The work was committed often and regular.
- Error handling works great.
#### What needs improvement?
- Test-driven development should be used more often.
- If the given approach took already too much time, try making it the other way.
- Make more quick breaks that give a fresh look.
#### Actions
- Write unit tests for Login and Logout.
- Implement History and Changing Details.

![After the first Sprint](Screenshots_of_backlog/After_Sprint_1.jpg)

## Sprint no. 2:
**Sprint goal:** Get the code ready for presentation.
DONE                            |NOT DONE
-------------------------- |----------
Prepare a solution                 |History   
Create GitHub repository  |Add admin
Create database                      |Add levels
Setup Entity Framework                       |Changing details
Registration                                 |
Timer                                        |
Leaderboard||
Logout |
Playing  |
Displaying a level|
Login   |
History |

### Sprint retrospective:
#### What went well?
- I implemented some new features and tests.
- The work was well organized and prioritized.
- I had no blockers during this sprint.
#### What needs improvement?
- Test-driven development should be used more often.
- The front-end could look better.
- Make more quick breaks that give a fresh look.
#### Actions
- Present the project in front of other trainers.
- Try to develop the product even after assignation.

## Project retrospective
### What have I learned?
- I was able to use in practice Entity Framework and WPF which gave me a depth understanding of a lot of their concepts.
- Good work organization is the key get things done on time.
- Better is to try some approach and eventually change it, than stick with it spending too much time.
### What would I do differently?
- I should do much more test-driven development.
- The model first approach should be used for implementing Entity Framework as it is more suitable for this kind of project.
- I should do more research on how to design the game.
### What will I do next?
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
