### 5. .NET Web API

A c# APPLICATION WITH .NET FRAMEWORK

dotnet-demo (HelloApi)

An ASP.NET Core Web API, containerized with a multi-stage Docker build and deployed via a Jenkins CI/CD pipeline to Docker Hub and an EC2 host.

What this application does

HelloApi is an ASP.NET Core Web API project (N-Tier style, with a dedicated Controllers folder and a matching HelloApi.Tests unit test project) .

Because [Route("[controller]")] maps the route to the controller name minus the Controller suffix, all endpoints live under /Hello.

Endpoints
Method	Path	Response
GET 	/Hello	{ message: "Hello from .NET API!", version: "1.0.0", timestamp: <UTC now> }
GET	    /Hello/health	{ status: "UP" }
GET	    /Hello/{name}	{ message: "Hello, {name}!" } — returns 400 Bad Request with { error: "Name cannot be empty" } if name is empty/whitespace

Once deployed, the app is reachable at:

http://<host>:5000/Hello
http://<host>:5000/Hello/health
http://<host>:5000/Hello/Keerthana



Tech stack
Language / Framework: C# / .NET 10 (ASP.NET Core Web API)
Testing: xUnit-style test project — HelloApi.Tests with HelloControllerTests.cs
Containerization: Docker (multi-stage build — SDK build stage → ASP.NET runtime stage)
CI/CD: Jenkins (declarative pipeline)
Registry: Docker Hub
Code quality: SonarQube (sonar-project.properties present for scan config)
Deployment target: AWS EC2 (container run directly on host via Docker)
Project structure
dotnet-demo/
├── HelloApi/
│   ├── Controllers/
│   │   └── HelloController.cs       # API controller — request handling
│   ├── Program.cs                   # App entry point / startup, middleware pipeline
│   ├── appsettings.json             # App configuration
│   └── HelloApi.csproj              # Project file — dependencies, target framework
├── HelloApi.Tests/
│   ├── HelloControllerTests.cs      # Unit tests for HelloController
│   └── HelloApi.Tests.csproj
├── HelloApi.sln                     # Solution file — links HelloApi + HelloApi.Tests
├── Dockerfile                       # Multi-stage image build definition
├── Jenkinsfile                      # Docker-based CI/CD pipeline (build → push → deploy)
├── JenkinsfileD                     # Secondary pipeline definition (see note below)
├── sonar-project.properties         # SonarQube scanner configuration
├── .gitignore
└── README.md