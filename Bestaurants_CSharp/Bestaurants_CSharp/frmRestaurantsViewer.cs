using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
//for message box
using System.Windows.Forms;

namespace Bestaurants_CSharp
{
    public partial class frmRestaurantsViewer : Form
    {
        public IApplication _application { get; set; }

        public  IApplication ArcMapApplication {
            get { return _application; }
            set { _application = value; }
        } 
      

        public frmRestaurantsViewer()
        {
            InitializeComponent();
        }

        private void cmbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dont have access to anything here!!
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            //we need to know which layer we should show
            //how do we know which layer? the layer has a selecteditem (which is a string = the layer name)
            // we do not now have ILayer as an object > we have a string
            //how can we get the layer from the string?? >> we write a function!
            ILayer pSelectedLayer = getLayerByName(cmbLayers.SelectedItem.ToString());
            pSelectedLayer.Visible = true;
            IDocument document = _application.Document;
            IMxDocument pMxDoc = (IMxDocument)document;
            pMxDoc.UpdateContents();
            //FocusMap and ActiveView are the same 
            //refreshes symbology and map
            pMxDoc.ActiveView.Refresh();
        }

        private void cmdHide_Click(object sender, EventArgs e)
        {
            ILayer pSelectedLayer = getLayerByName(cmbLayers.SelectedItem.ToString());
            pSelectedLayer.Visible = false;
            IDocument document = _application.Document;
            IMxDocument pMxDoc = (IMxDocument)document;
            pMxDoc.UpdateContents();
            pMxDoc.ActiveView.Refresh();
        }

        /// <summary>
        /// Get the layer by name
        /// </summary>
        /// <param name="sLayerName"></param>
        /// <returns></returns>
        private ILayer getLayerByName(String sLayerName) {
            
            IDocument document = _application.Document;
            IMxDocument pMxDoc = (IMxDocument)document;
            IMap pMap = pMxDoc.FocusMap;

            int i = 0;
            while (i != pMap.LayerCount)
            {
                ILayer pLayer = pMap.Layer[i];
                if (pLayer.Name.Equals(sLayerName))
                {
                    return pLayer;
                }
            }
            //if you are here, you didn't find the layer
            return null;
        }      
    }
}
