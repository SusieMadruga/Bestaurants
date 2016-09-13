using System;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;

namespace Bestaurants_CSharp
{
    /// <summary>
    /// Summary description for cmdLoadData.
    /// </summary>
    [Guid("3079bc3a-a1aa-48a2-83f3-4ef5fa58204f")]
    [ClassInterface(ClassInterfaceType.None)]
    // COM (needs native reprsentations to identify the class - without native .NET you don't need these things) 
    [ProgId("Bestaurants_CSharp.cmdLoadData")]
    public sealed class cmdLoadData : BaseCommand
    {
        //registers it with ArcMap 
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        // this is our first interface!! (our first encounter of ArcObjects Interface)
        // the first object and the first that gets passed to you 
        // '_' indicates it is a private variable
        private IApplication _application;
        public cmdLoadData()
        {
            // THIS WILL GET CALLED WHEN ARCMAP OPENS 
            // m_application is still empty though, it is just a declaration 
            // --> it is actually ArcMap itself!
            //
            // TODO: Define values for the public properties
            //
            // toolbar can exist by itself so you must put it in a category (so it's properly sorted in ArcMap - don't touch it, it's ours!)
            base.m_category = "Bestaurants_Tools"; //localizable text
            base.m_caption = "Load Data";  //localizable text (the header) - if no image, it will display this text
            base.m_message = "Load Data into ArcMap from external files";  //localizable text (lengthy description)
            base.m_toolTip = "Load Data";  //localizable text 
            base.m_name = "Bestaurants_Tools_LoadData";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// gets called when ArcMap is initiating (give it to me!)
        /// it loops though and passes the hook (the application)
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            // it knows it has to be an IApplication
            if (hook == null)
                return;

            _application = hook as IApplication;

            //Disable if it is not ArcMap
            if (hook is IMxApplication)
                base.m_enabled = true;
            else
                base.m_enabled = false;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// MOST IMPORTANT!
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add cmdLoadData.OnClick implementation
            MessageBox.Show("Hello World!");

            // change title of ArcMap Document (Like "Untitled - ArcMap") 
            _application.Caption = "Bestaurants Application";
            
        }

        #endregion
    }
}
