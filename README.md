# MapLocation

Current Version 0.0.1

.NET Wrapper for various location services to standardise to a simple MapLocation object for multiple providers.

Worked on from time-to-time (mainly in free time) to have some fun with GitHub.

Bear with me if you have a PR, as I'm not normally a Git guy and live my life in TFS/VSTS/Azure Devops (or whatever it's getting called today 😊). Will try and keep this plodding on though

Nuget: https://www.nuget.org/packages/MapLocation
Install: Install-Package MapLocation -Version 0.0.1
Usage: Generate a new Maps class, passing in MapOptions (see Console App)

## MapOptions:
**APIKey** is required if the service requires an API Key (will throw an error on **Maps** object creation)

**MapImageOptions** is optional, but if you are using **Maps** to generate an image, it is requred (will throw an error on call of image function)
