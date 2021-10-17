# RoadStatus

This is a project to display the status of a road based on the response from th TfL api.


# Project details

The main project and the tests project were built using .NET Core 3.1.
The test project uses NUnit 3 as a test framework.

## Dependencies

The following external NuGet packages were installed in the project:
* Microsoft.ExtensionsConfiguration
* Microsoft.ExtensionsConfiguration.Binder
* Microsoft.ExtensionsConfiguration.Json
* RestSharp
* NUnit
* NUnit3TestAdapter
* Microsoft.NET.Test.Sdk

# Before running the app
The app requires a valid appId and ApiKey to be able to retrieve the status from the TfL API, for that we need to make sure we have a file called `appConfig.json` in the root of the application folder.
This file should contain both parameters in a json format, like the following:
```
{
	"appId": "YOUR_APP_ID_HERE",
	"apiKey": "YOUR_API_KEY_HERE"
}
```
You also need to compile the app and make sure the dependencies were successfully installed.
# Running the app
To run the app, open a cmd on the root of where the binaries were created and execute the app like: `.\RoadStatus.exe ROAD_NAME` and change the `ROAD_NAME` for the actual road name.

The app should return a descriptive error message if there's something wrong with the config file or the road name.

If there's nothing wrong, the app should display the status of the road that was requested.

# Running the tests
The automated tests were created following the same file structure and name as the main project for ease of use.

You can just run the tests using your favourite IDE from the test explorer.

## About the failing tests

There is currently one test that is failing because of what I believe is a bug on the TfL API, we shouldn't be able to run a road check on the API without sending the app key and app id, that's why *GetRoadStatus_WithEmptyConfig_ShouldReturnException* fails. If this behaviour is expected, then this test needs to be adapted to reflect it.

There's one other test that requires you to configure the app key and app id in it so it can successfully retrieve the status, so please replace the `YOUR_API_KEY` and `YOUR_APP_ID` in the *GetRoadStatus_WithValidConfigAndValidRoad_ShouldReturnTheStatus* and *GetRoadStatus_WithValidConfigAndInvalidRoad_ShouldReturnException* with your valid Api Key and App Id respectively.

# Others

Any parameters after the first one are ignored;
Any extra configuration in the appConfig.json file will be ignored;
Ideally I shouldn't always throw just Exception and should make them specific exceptions and on the tests not validate by the message but by the type of exception.