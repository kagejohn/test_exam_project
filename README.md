# test_exam_project

## Reflections and Evaluations

### Team Collaboration
The way we worked together on the project was primarily through Discord, a chat service built for gaming that also has a lot of custom made chatrooms to allow for organizing work like this. It is not the only program of its kind as there are work-oriented products that are nearly identical, but given that both Christian and Joachim are avid gamers, it only makes sense for us to use it. It also has screen-sharing features for when we have to do Pair Programming or generally only are capable of working on a piece of the program bit by bit.

### Test Automation
The strategy that we use to make sure that our automation is not a very complicated one. We use Azure DevOps to automate a list of tests that we've set up. First, we start by performing integration tests, testing the individual functions in the backend that allow us to create and fetch elements from the database, to ensure that they properly run. After confirming that the methods function, we move onto the next part of the process by shifting to a different container which has the functional tests for the front end. Given that the front end relies on the functions in the back, these do need to be run second otherwise there's no point. If these are green-lit, the code is accepted onto Azure DevOps where it can be updated and pushed.

### Non-Functional Requirements
The most non-functional issue that we think that our system would encounter would be something like an excess of students trying to log in and access the schedule. However, given that we've prioritized ourselves into User Stories that have more meat in regards to the types of tests we can conduct, we have not exactly made an effort to make Non-functional tests of any sort. It simply wasn't as much of an importance to us, with how we made our solution.

### Testability
I would personally say that our Solution is as testable as one should reasonably expect. Every method in the backend can be tested using integration tests, the front end can be tested with Selenium in Functional tests, and most if not all of them have different parameters we can alter to ensure that we are able to fall within the constraints imposed upon us by the project description.

### Test Design Techniques
One of the primary techniques we've been using to design our tests is Pair Programming, which has also been an important part of programming the solution itself. As it is difficult to work on different parts of the solution at the same time, we've been using the screen-sharing function of Discord to be able to throw things together in real time, with one of us doing the coding and the others providing feedback to ensure that things are done properly. In that regard, I think the technique has been very useful.
