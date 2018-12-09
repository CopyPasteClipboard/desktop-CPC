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