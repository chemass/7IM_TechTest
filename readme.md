# 7IM Technical Test

This solution consists of 4 projects:
- 7IM_TechTest - The .NET back end
- 7IM_TechTest_Angular - The Angular front end
- TechTest.IntegrationTests - A small integration test project
- TechTest.UnitTests - a small unit test project.

All tests can be run directly in visual studio, or by using 'dotnet test' or 'ng test' 

I decided to use a minimal api endpoint with a GET request for the search endpoint.
Given the requirements, this seemed the most sensible approach, without unnecessarily overcomplicating anything.
It shows the use of DI and some basic validation without bringing in any other libraries such as FlurntValidation etc.

The data repository simply caches the data on first request. Adding anything further here seemed pointless.

Although I usually reject the idea of passing any form of entity/dto through to the front end, with such a simplistic program, it seemed that adding any kind of view model was superfluous.
In a real project, there would be a data entity which would be mapped to a DTO for transition through layers, which would finally be mapped to a model to be exposed through the endpoint.

I quite enjoyed relearning Angular - It's been a long time since I've touched it and the tooling has certainly improved!
I went with a simple 3 component app - the application component, a search component and the person display component.
There are some simple tests included, although they are not exhaustive. Also, my styling leaves something to be desired!

Finally, there are the two dotnet test projects, comprising of both unit and integration tests.
As the application itself is so small, there are barely any tests, but you can see that I understand the concepts.

I'd say that this took me around 3-4 hours altogether, including relearning Angular.

All in all, a mildly amusing technical test that I'd be happy to give to a prospective junior developer.
