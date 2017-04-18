Below is the basic writeup of how you will be receiving work items. I was looking at the SmartyStreets API and there may be a few gotchas that may prevent you from completing this task, if you totally get stuck, we might be able to find another option to provide Autocomplete Functionality.

# Requirements:

* Replace the default Property Editor for an Address Object with SmartyStreets AutoComplete HTML control within the DevExpress XAF XRM Demo Application

# Required Background information
## DevExpress
* Requires Visual Studio 2017 Community or higher to be installed.
  * [Download and Install DevExpress Universal Demo](https://www.devexpress.com/Home/try.xml)
*	Review Support Article on how to add a Custom Property Editor to Web Project
  * [How to: Implement a Property Editor based on Custom Controls (ASP.NET)](https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112678)
## SmartyStreets
* [Sign up for free SmartyStreets Account](https://smartystreets.com/signup)
* [Review Documentation on how to implement their Autocomplete solution](https://smartystreets.com/docs/cloud/us-autocomplete-api)
    * The WebSite Plugin looks to be the best bet 
      * https://smartystreets.com/docs/plugins/website/examples 

# Additonal Information and Instructions:

Here is the GitHub Repository with the basic XAF solution: https://github.com/ImmergeCloud/XAFTest

When developing a new Property Editor, the XAF framework provides a way to assign and assess the ASPx controls very similar to a standard WebForm page.

We have already integrated a custom ASPx control to help manage multiple email addresses.
I added this custom control to the XAFTest.Module.Web Project in the PropertyEditors Folder.
If you run the XAFTest.Web Project, you should see a Person with my name.
Click on that row and you should be brought to the detail page.
Do ahead and see how the email control works now instead of being just text.

Now click on the button on the right of the Address1 property and you should be a popup window with all the address information.
The control on the Person_DetailView is what needs to be replaced with the SmartyStreets AutoComplete functionality.
The ORM, called XPO might be tricky to actually save the address to the object, so we can discuss if you get stuck there.

I have also attached screenshots of my updates to the Model

If XAF is too overwhelming, maybe you can integrate the SmartyStreets into a WebForm project as a UserControl?

As soon as you have this completed or as far as you can get, we can schedule your on-site interview and next steps.

I can be available over the weekend for coaching and a little training on XAF.

![ScreenShot #1](https://github.com/ImmergeCloud/XAFTest/blob/master/2017-04-13_15-26-52.png)

![ScreenShot #2](https://github.com/ImmergeCloud/XAFTest/blob/master/2017-04-13_15-27-23.png)
