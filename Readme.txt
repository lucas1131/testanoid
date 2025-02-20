# Testanoid
This project was given as a test for a job application. I took the opportunity to make the entire game using Dependency Injection with Zenject for practice. The assets are not mine but the code was completely rewritten from scratch. 
I wanted to show how to use Zenject and why I thought dependency injection is a nice design pattern for working with Unity. This helps make the code very well separated, everything is behind proper interfaces, which makes it's easier to do composition, there are no Monobehaviours where they aren't needed and although there are no written automated tests, with everything being injected and using interfaces, it's really easy to mock and writte proper automated tests for this.


Original objective:
Given the project “Architecture Test”, please refactor the project taking into consideration the following key points:

- KISS principle 
- decoupling data and representation
- composition over inheritance
- single responsibility principle
- application of design patterns where possible

The project will be evaluated by the following, in order of importance (high to low):

- complexity of the code (is the code simple to understand?)
- readability of the code (is the code easy to read?)
- robustness (how hard is it to make the app crash?)
- flexibility (how well the game adapts to different devices/screen sizes)
- gameplay polish (is the gameplay behaving in a nice way?)

The project has been designed with a 9:16 ratio in portrait mode, using Unity 2018 LTS version.

Once you are finished with it, please upload the project to GitHub or some other git repository and share it with us. Also, please prepare a screen recording where you show your refactored code and explain some of your decisions. It should be under 10 minutes if possible.
