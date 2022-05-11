# KNet How to build from scratch

If the user clones the repo, the following steps shall be done to use the project. 
Let's start with the tools needed to achieve the goal:
* An installed version of __git for Windows__
* An installed version of .NET 6 SDK
* An installed version of Apache Maven (> 3.8.1)

The full steps 

Then the steps are the following (the steps are made for Windows shell):

* Clone the repository in a folder (named for convenience TheFolder)

> cd TheFolder
> git clone https://github.com/masesgroup/KNet.git
>

* The project now needs to compile Java classes and obtains the Maven artifacts; this is done with a single step (it is important to use the **package** key as command for Maven); 

> cd TheFolder
> {PathToMavenInstallation}\bin\mvn -f src/java/knet/pom.xml package
>

  * The result of this step produces the artifacts within TheFolder\jars folder.

* The next step is to build the executables:

> cd TheFolder
> dotnet build --no-incremental --configuration Release /p:Platform="Any CPU" src\net\KNetCLI\KNetCLI.csproj
>

  * The previous command generates many folders under TheFolder\bin folder; each folder refers to the usable .NET version;
* The compilation does not complete the preparation; in the last step the developer shall make some manual copy:
  * Copy the **TheFolder\jars** folder within each runtime folder under **TheFolder\bin**
  * Copy the **TheFolder\src\config** folder within each runtime folder under **TheFolder\bin**.
  
The final result will be something like this:
* TheFolder
  * bin
    * net5.0
      * config
	  * jars
	  * other folders
    * net6.0
      * config
	  * jars
	  * other folders
    * net461
      * config
	  * jars
    * netcoreapp3.1
      * config
	  * jars
	  * other folders
  * Other folders