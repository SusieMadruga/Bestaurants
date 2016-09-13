using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.ArcMap;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

//for message box
using System.Windows.Forms;


namespace Bestaurants_CSharp
{
    /// <summary>
    /// Summary description for cmdViewer.
    /// </summary>
    [Guid("8cfbc578-7438-4968-b722-d9bce8eb4fa8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Bestaurants_CSharp.cmdRestaurantsViewer")]
    public sealed class cmdRestaurantsViewer : BaseCommand
    {
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

        private IApplication _application;
        public cmdRestaurantsViewer()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Bestaurants_Tools"; //localizable text
            base.m_caption = "Bestaurants Viewer";  //localizable text (the header) - if no image, it will display this text
            base.m_message = "View the restaurants in tabular format and interacts with the map.";  //localizable text (lengthy description)
            base.m_toolTip = "Bestaurants Viewer";  //localizable text 
            base.m_name = "Bestaurants_Tools_BestaurantsViewer";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")

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
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
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
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add cmdViewer.OnClick implementation

            // we want to view a form 
            frmRestaurantsViewer pRestaurantsViewer = new frmRestaurantsViewer();

            //set the application object so we can work with it in the form
            //now _application in the frmRestaurantsViewer.cs property is set 
            pRestaurantsViewer.ArcMapApplication = _application;

            //show the form (initialize it)
            pRestaurantsViewer.Show();

            // IApplication > IMxDocument > IMap > ILayer
            IDocument document = _application.Document;
            IMxDocument pMxDoc = (IMxDocument)document;

            //get the map from the document
            IMap pMap = pMxDoc.FocusMap;

            // get the first layer (which is "Food and Drinks Venues in Belize")
            //ILayer pLayer = pMap.get_Layer(0);
            // add layer to the drop down combo box (drop down list)
            //pRestaurantsViewer.cmbLayers.Items.Add(pLayer.Name);

            //loop through all layers and add them to the list
            int i = 0;
            while (i != pMap.LayerCount) {
                ILayer pLayer = pMap.Layer[i];
                pRestaurantsViewer.cmbLayers.Items.Add(pLayer.Name);
                i++;
            }
            
            
            
        }

        #endregion
    }
}
