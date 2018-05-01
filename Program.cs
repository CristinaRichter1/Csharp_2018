using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //Boolean ans = CompatibilityManager.isCompatible(new Component(1, "GTX 9900", "PC"), new Component(2, "FX 8700", "PC"));
            //Console.WriteLine("Answer is " + ans);
            //Computer comp = new Computer(1, "AMD", new Component[] { new Component(1, "GTX 9900", "PC"), new Component(2, "FX 8700", "PC") });
            //Console.WriteLine(comp);

            Form1 f = new Form1();

            Application.Run(f);
        }
    }
}
