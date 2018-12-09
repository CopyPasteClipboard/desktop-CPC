# Clippy Desktop Edition
Created by Keola Dunn

## Welcome to Clippy!
The goal of this project was to further the principle of "Seamless Computing", that a user can leave a platform mid-task and continue the task from a different platform at the exact point they left off. The goal of Clippy was to achieve this with simple, cross-platform copy/paste operations.

## Code

### Api Classes
There are a number of ways to interact with an API in C#, many of which are fairly simple operations. For this project, I chose to use a variety of classes for API interfacing as is recommended in the .NET documentation. 

The first class I created as a member of the Clippy application was the ApiHelper (ApiClasses/ApiHelper.cs). This class is responsible for a static HttpClient instance, which is available to the entire application. Using only one instance is a preventative design decision in order to avoid potential socket exceptions that could arise from many HttpClient members. The rest of the classes are used in the various Get, Post, Push, and Delete API calls throughout the application. All of the classes are listed as follows.
- ApiHelper.cs - Creates and holds HttpClient used throughout application.
- AccountInfoModel.cs - Model that allows for account information updates. 
- ClipboardContentsModel.cs - Model that retreives clipboard contents.
- ClipboardModel.cs - Model that represents a clipboard.
- CreateAccountModel.cs - Model used to create an account.
- NewClipboardItemModel.cs - Model used to add item to a clipboard.
- NewClipboardModel.cs - Model to create a clipboard.
- SimpleLoginPostModel.cs - Model for the current version's simplified login procedure, requiring username only.
- UserLoginInfoModel.cs - Beginnings of full login model implementation.

These classes are all public, and are converted to JSON objects when applied to the .NET HTTP API calls. This way, the classes can function as the basis of the parameters for the calls, as well as the JSON returns of the calls, so that the parameters and return values can be easily accessed and changed. Additionally, because we developed our own backend and API, it allows for easy changes to parameter and return value types and names. 

### Windows
The window classes in the Desktop version of Clippy are as follows:
- MainWindow.xaml/MainWindow.xaml.cs - First window of the application opened. Houses the login screen and create account screen.
- AppWindow.xaml/AppWindow.xaml.cs - Window used to house the majority of the application after logging in.
These classes serve as the physical windows of the Clippy application. 
MainWindow is the window inherantly created with any C#/WPF application. It houses all of the create account and log in logic. Closing the window will close the application. The visual composition of the window is laid out in the .xaml file, and the .xaml.cs contains the logic.
App Window is a created window that will house the application pages after log in. The App Window's primary function outside of being the primary window for application use is the conversion of the UserLoginInfoModel to a CurrentUser class that will be used to communicate user data to the other application components. 

### Pages
Pages were developed as a tool for web applications, however they are just as applicable in a local application such as the Desktop Clippy. The pages act as the content for the window, and provide the primary UI of the application. The pages are as follows:
- AccountView.xaml/AccountView.xaml.cs - Implements the "View Account" component of the application.
- CreateAccount.xaml/CreateAccount.xaml.cs - Implements the "Create Account" application capability.
- HomeScreen.xaml/HomeScreen.xaml.cs - Serves as the home screen for the application post login.
- NewClipboard.xaml/NewClipboard.xaml.cs - Implements the ability to create a new clipboard.

### CurrentUser.cs
This class is one of the most important in the application. It contains all of the information relevant to the application user such as username, password, user ID, user clipboards and board ID's, and provides the application with ways to access the needed information. The class is passed through the application pages such that each page has access to the pertinent user information. A future version of Clippy would involve making this class into a more proper singleton, initialized to a "null" value before a user logs in and after they log out.

### ClippyTests
This is the unit testing project that was used to implement small unit tests on the Clippy application. The solution contains ClippyTests.cs, which is the actual test file where unit tests are written. The unit tests created were meant to test the components of the application that are likely to change in future iterations, particularly the varying files in ApiClasses.

### Integration Tests


More details on any of these files can be found inside the files themselves.








