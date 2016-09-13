using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace Bestaurants_CSharp
{
    /// <summary>
    /// Summary description for BestaurantsToolbar.
    /// </summary>
    [Guid("df870c7d-88e7-472f-85ce-2faacca20660")]
    [ClassInterface(ClassInterfaceType.None)]
    // Key Unique ID that Windows knows that this is the toolbar for ArcGIS
    [ProgId("Bestaurants_CSharp.BestaurantsToolbar")]
    public sealed class BestaurantsToolbar : BaseToolbar
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
            MxCommandBars.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Unregister(regKey);
        }

        #endregion
        #endregion

        //inherits from absract class 'BaseToolbar' (from IDF base library = ESRI.ArcGIS.ADF.Local)
        public BestaurantsToolbar()
        {
            //
            // TODO: Define your toolbar here by adding items
            //
            //AddItem("esriArcMapUI.ZoomInTool");
            //BeginGroup(); //Separator
            //AddItem("{FBF8C3FB-0480-11D2-8D21-080009EE4E51}", 1); //undo command
            //AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2); //redo command

            AddItem("Bestaurants_CSharp.cmdLoadData");
            AddItem("Bestaurants_CSharp.cmdRestaurantsViewer");
        }

        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                //what name do you want the display text to be on ArcMap?
                return "Bestaurants Application";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                //must be unique 
                return "BestaurantsToolbar";
            }
        }
    }
}