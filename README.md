# 🧊 CollidingCubes 🧊 

## Architecture 🏛️
The solution uses a **DDD Architecture**. With just the Presentation and Domain layer, since there is no need to access any data with an infrastructure layer.
- This architecture helsp isolate the domain logic and make it the core of the application so we build all the code around it.
- It improves the testability of each layer in isolation from the others.
- It gives each layer a single responsibility.

## Patterns 🎨
- **Dependency injection pattern**: All the dependencies are injected to avoid coupling, improve the maintainability and extensibility of the code. With it we achieve the "D" (Dependency Inversion Principle) of the SOLID principles.

- **Factory pattern**: With it we simplify the logic of the creation of a `Cube` by separating the responsibility of the object creation from the rest of the code. It makes the code easier to modify and mantain in case we want to modify the creation of a `Cube` ("S" principle). I used an interface for the factory instead of creating a static factory to avoid coupling the code to the specific factory and to allow to have different factories to define diferent types of `Cube` object under the same interface ("I" principle) Since this factory shouldn't be modified and in case to have a different creation of the `Cube` object we also achieve the "O" principle.

## Testing 🧪
Tested the Domain service `CubeService` functionalities in alls its cases mocking the `CubePositionService` to test each component independently. We could still test the `CubeFactory` exceptions and the `CubePositionService`.

## Author 👤
This code was created by **Ferran Ramirez Navajón**. 

You can find me on [LinkedIn](https://www.linkedin.com/in/ferranramirez/).
