﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductViewModel : IDataErrorInfo
    {
        public int ID { get; set; }
        public string SerialNo { get; set; }
        public string Name { get; set; }
        public int MakeID { get; set; }
        public int LocationID { get; set; }

        public int PartTypeID { get; set; }
        public int PanelTypeID { get; set; }
        public int SizeID { get; set; }
        public int PanelIPNumberID { get; set; }
        public int CertID { get; set; }
        public int StockLevel { get; set; }
        public int Qty { get; set; }

        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;

               

                return result;
            }
        }
       
    }

    

    public class ProdViewModel : AIS_DataAccessLayer.Product
    {
        public new int ID { get; set; }
        public new string SerialNo { get; set; }
        public new string Name { get; set; }
        public new int MakeID { get; set; }
        public int Qty { get; set; }
    }
}
