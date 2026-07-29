# Municipal Services Application - Part 1 (Report Issues)

AAPD7112 (Advanced Application Development) - Portfolio of Evidence, Part 1

## What this is

A C# .NET Framework (targeting .NET Framework 4.8) Windows Forms desktop
application that lets South African municipal residents report issues
(potholes, water leaks, sanitation problems, etc.) to their municipality.

In Part 1, only the **Report Issues** feature is implemented. "Local Events
and Announcements" and "Service Request Status" are visible on the main
menu but disabled, as required by the brief - they will be built in Parts
2 and 3 of the PoE.

## Project structure

```
MunicipalServicesApp.sln
MunicipalServicesApp/
  MunicipalServicesApp.csproj
  Program.cs                          Application entry point
  Models/
    Issue.cs                          Represents one reported issue
  Data/
    IssueRepository.cs                Stores issues in a List<Issue>
  Forms/
    MainMenuForm.cs / .Designer.cs    Startup menu (3 options)
    ReportIssueForm.cs / .Designer.cs Report Issues screen
```

## How to compile and run

### Option A - Visual Studio (recommended)

1. Install **Visual Studio 2022** (Community edition is free) with the
   **.NET desktop development** workload.
2. Open `MunicipalServicesApp.sln`.
3. Press **F5** (or click **Start**) to build and run the application.

### Option B - command line

1. Install the [.NET SDK](https://dotnet.microsoft.com/) (Windows only,
   since this is a Windows Forms application).
2. From the `MunicipalServicesApp` folder (the one containing the
   `.csproj` file), run:
   ```
   dotnet build
   dotnet run
   ```

> Windows Forms applications only run on Windows. If you are working on
> macOS or Linux, use a Windows virtual machine or a lab PC to build and
> run the project.

## How to use the application

1. On startup, the **Main Menu** appears with three options. Only
   **Report Issues** is enabled.
2. Click **Report Issues** to open the reporting form.
3. Fill in:
   - **Location** - where the issue is (street, ward, landmark).
   - **Category** - choose from the dropdown (e.g. Sanitation, Roads and
     Potholes, Water and Utilities).
   - **Description** - describe the issue in detail.
   - **Attach Image / Document** (optional) - click the button to attach
     a photo or document as evidence, using the standard Windows file
     picker.
4. As you fill in the form, the **progress bar and message below the
   form** update in real time - this is the user engagement feature
   (see the research document for the justification of this choice).
5. Click **Submit Report**. The application validates that location,
   category, and description have been provided, stores the issue in
   memory, and shows a confirmation message with a reference number.
6. Click **Back to Main Menu** at any time to return to the start screen.

## Data storage

Reported issues are stored in memory for the duration of the session,
using a `List<Issue>` inside `IssueRepository`. This satisfies the
technical requirement to use an appropriate data structure to store
user-reported issues, and gives Part 2/Part 3 of the PoE a single place
to read report data from as the application grows.

## Notes for the marker

- The chosen user engagement strategy is **real-time gamified feedback**
  (a live progress bar plus encouraging messages), as researched and
  justified in the accompanying Word document for Task 1.
- The main menu's other two options are intentionally disabled
  (`Enabled = false`) rather than removed, per the specification that
  they are "to be implemented later".
