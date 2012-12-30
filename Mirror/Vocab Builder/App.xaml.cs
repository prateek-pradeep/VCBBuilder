using Vocab_Builder.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Threading.Tasks;
using Vocab_Builder.Model;
using Windows.Storage;

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace Vocab_Builder
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        #region Public PROPERTY
        public string DBPath { get; set; }
        #endregion
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active

            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }
                DBPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.DatabaseFileName);

                //Creating database file if it not exists
                await CreateFirstTimeDataBase();

                ResetData();

                WordDataSource.LoadLocalDataAsync();
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }
            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(GroupedItemsPage), "AllGroups"))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        private async Task CreateFirstTimeDataBase()
        {
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(Constants.DatabaseFileName);
            }
            catch (FileNotFoundException)
            {
                //If databse File is not found then create a new DB File
                using (var dbConnect = new SQLite.SQLiteConnection(DBPath))
                {
                    dbConnect.CreateTable<WordDetails>();
                    dbConnect.CreateTable<WordGroup>();
                }
            }

        }

        private void ResetData()
        {
            //using (var db = new SQLite.SQLiteConnection(DBPath))
            //{
            //    #region Filling WordGroup Table
            //    db.DeleteAll<WordGroup>();

            //    char alphabet = Constants.CapsA;
            //    for (int index = alphabet; index <= Constants.CapsZ; index++)
            //    {
            //        alphabet = (char)index;
            //        db.Insert(new WordGroup()
            //        {
            //            GroupName = alphabet.ToString(),
            //            Description = String.Format(Constants.GroupDescription, alphabet)
            //        });
            //    }
            //    #endregion

            //    #region Filling WordDetails table
            //    db.DeleteAll<WordDetails>();
            //    WordDetails wordDetails = new WordDetails();
            //    uint wordKey = 1000;

            //    for (int i = 0; i < 26; i++)
            //    {
            //        string groupName = ((char)(i + Constants.AsciiValueOfA)).ToString().ToUpper();
            //        string wordName = groupName + "nalogy";
            //        string baseName = groupName + "ase";

            //        for (uint j = 0; j < 120; j++)
            //        {
            //            wordDetails.WordKey = wordKey++;
            //            wordDetails.WordName = wordName;
            //            wordDetails.GroupName = groupName;
            //            wordDetails.BaseName = baseName;
            //            db.Insert(wordDetails);
            //        }
            //    }                
                
            //    #endregion

            //}
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}

