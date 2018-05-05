using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
 * 1. Declare / implement the entities (classes)
 * 2. Create forms that allow users to input data
 * 3. Add data validation (ErrorProvider control, Validating/Validated events, standard exceptions, custom exceptions)
 * 5. Implement Alt Shortcuts
 * 4. Add data serialization / deserialization
 * 5. Add the option to export a report as a txt file
 * 6. Use the various menu controls (MenuStrip, ToolStrip, StatusStrip, ContextMenuStrip)
 *
 * PHASE II:
 * 7. Draw a chart (don't use the chart control ;) ) in order to represent some statistics that are meaningful for your app 
 * 8. Offer the possibility to print a document (with PrintPreview)
 * 9. Implement the drag & drop functionality
 * 
 * PHASE III:
 * 10. Use a relational database in order to persist data (for at least two different entities / classes) in your app
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

            String connectionString = Properties.Settings.Default.Database;
            OleDbConnection connection = new OleDbConnection(connectionString);

            // Inject the retrieved session manager into the application 
            HardwareSessionManager savedSession = new HardwareSessionManager();
            try
            {
                savedSession.retrieveState(connection);
                //savedSession.retrieveState("Resources/session.bin"); // We can persist data via file-based binary serialization
            } catch (Exception e)
            {
                // we catch exception and log it but we don't tell the user
                HardwareUtil.log(Loglevel.error, e.Message);
            }

            Form1 f = new Form1(savedSession);
            Application.Run(f);

            //f.session.saveState("session.bin"); // we can save session to file 
            f.session.saveState(connection); // but also to db
        }
    }
}
