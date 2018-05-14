using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using temaCsharp.Util;

/*
 * Subject 35: Hardware
 * Classes to implement:
 * Componente        - Component
 * Compatibilitati   - Compatibility
 * Calculatoare      - Computer
 * 
 * Possible user actions: - create a component
 *                        - check compatibility between 2 components or a component and computer
 *                        - add components to a computer
 *                        
 * PHASE I:
 * 1. Declare / implement the entities (classes) --ok
 * 2. Create forms that allow users to input data --ok
 * 3. Add data validation (ErrorProvider control, Validating/Validated events, standard exceptions, custom exceptions)--ok
 * 5. Implement Alt Shortcuts
 * 4. Add data serialization / deserialization --ok
 * 5. Add the option to export a report as a txt file --ok
 * 6. Use the various menu controls (MenuStrip, ToolStrip, StatusStrip, ContextMenuStrip) --ok
 *
 * PHASE II:
 * 7. Draw a chart (don't use the chart control ;) ) in order to represent some statistics that are meaningful for
 *    your app --ok 
 * 8. (X)Offer the possibility to print a document (with PrintPreview)
 * 9. (X)Implement the drag & drop functionality
 * 
 * PHASE III:
 * 10. Use a relational database in order to persist data (for at least two different entities / classes) in your app --ok
 * 11. Implement a UserControl (so that it can be distributed to other developers) in a separate project and use it in your 
 * app. The UserControl should provide a useful functionality for your app (please don't copy&paste a clock usercontrol from 
 * the internet ;) )
 * 
 */

namespace temaCsharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // First log in

            LoginForm lf = new LoginForm();
            if (lf.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(-1);
            }


            String connectionString = Properties.Settings.Default.Database;
            String sessionFile      = Properties.Settings.Default.SessionFile;
            OleDbConnection connection = null;
            try
            {
                connection = new OleDbConnection(connectionString);
            }
            catch (Exception e) {
                HardwareUtil.log(LogLevel.error, e.Message);
            }

            // Inject the retrieved session manager into the application and try to read from ms access db
            HardwareSessionManager savedSession = new HardwareSessionManager();
            try
            {
                savedSession.retrieveState(connection);
            }
            catch (Exception e)
            {
                // we catch exception and log it but we don't tell the user
                HardwareUtil.log(LogLevel.error, e.Message);
                // and fall back to using file based persistence
                if(File.Exists(sessionFile))
                    savedSession.retrieveState(sessionFile);
            }

            // we run the app
            MainForm f = new MainForm(savedSession);
            Application.Run(f);

            // try to save changes to db
            try
            {
                f.session.saveState(connection); 
            }
            catch (Exception e) {
                // if that fails write to file and log error
                HardwareUtil.log(LogLevel.error, e.Message);
                f.session.saveState(sessionFile);
            }
        }
    }
}
