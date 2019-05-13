﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using ListApplication.Models;

namespace ListApplication
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            if (args.Kind != Windows.ApplicationModel.Activation.ActivationKind.VoiceCommand)
            {
                return;
            }

            var commandArgs = args as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;

            var speechRecognitionResult = commandArgs.Result;
            string voiceCommandName = speechRecognitionResult.RulePath[0];
            string textSpoken = speechRecognitionResult.Text;


            //count males or females
            string spokenCountItem = "";
            try
            {
                spokenCountItem = speechRecognitionResult.SemanticInterpretation.Properties["countItem"][0];
            }
            catch
            {
                //
            }

            var sCountItem = "";
            switch (spokenCountItem)
            {
                case "Male":
                case "Men":
                case "Boys":
                    sCountItem = "Male";
                    break;
                case "Females":
                case "Girls":
                case "Women":
                    sCountItem = "Female";
                    break;

            }



            //Place 
            string spokenPlace = "";
            try
            {
                spokenPlace = speechRecognitionResult.SemanticInterpretation.Properties["place"][0];
            }
            catch
            {
                //
            }
            var location ="";
            
            switch (spokenPlace)
            {
                case "Blenheim":
                    location = "Blenheim";
                    break;
                case "Toronto":
                    location = "Toronto";
                    break;
                case "Windsor":
                    location = "Windsor";
                    break;
                case "London":
                    location = "London";
                    break;
                case "Caledonia":
                    location = "Caledonia";
                    break;
                case "Chatham":
                    location = "Chatham";
                    break;
                case "Welland":
                    location = "Welland";
                    break;
            }


            //Sort Item
            string spokenItem = "";
            try
            {
                spokenItem = speechRecognitionResult.SemanticInterpretation.Properties["sortItem"][0];
            }
            catch
            {
                //
            }
            var sortField = "";
            switch (spokenItem)
            {
                case "Age":
                    sortField = "Age";
                    break;
                case "Sex":
                    sortField = "Sex";
                    break;
                case "FavouriteColor":
                    sortField = "FavouriteColor";
                    break;
                case "LastName":
                    sortField = "LastName";
                    break;
                case "FirstName":
                    sortField = "FirstName";
                    break;
            }

            Frame rootFrame = Window.Current.Content as Frame;
            MainPage page = rootFrame.Content as MainPage;

            if (page == null)
                return;

            switch (voiceCommandName)
            {
                case "sortByLocation":
                    page.SortByLocation();
                    break;
                case "howMany":
                    page.HowMany(location);
                    break;
                case "countTheAmount":
                    page.CountTheAmount(sCountItem);
                    break;
                case "omniSort":
                    page.OmniSort(sortField);
                    break;
                case "bestFriend":
                    page.BestFriend();
                    break;
            }
        }
    }
}
