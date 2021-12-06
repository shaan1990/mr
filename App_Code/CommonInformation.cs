using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MerchantMirrour
{
    public class CommonInformation
    {

        public DataTable LoadAllDistricts()
        {
            DataTable dtDistricts = new DataTable();
            dtDistricts.Columns.Add("id");
            dtDistricts.Columns.Add("name");

            dtDistricts.Rows.Add(1, "Dhalai");
            dtDistricts.Rows.Add(2, "Gomati");
            dtDistricts.Rows.Add(3, "Khowai");
            dtDistricts.Rows.Add(4, "North Tripura");
            dtDistricts.Rows.Add(5, "Sipahijala");
            dtDistricts.Rows.Add(6, "South Tripura");
            dtDistricts.Rows.Add(7, "Unakoti");
            dtDistricts.Rows.Add(8, "West Tripura");

            return dtDistricts;
        }
    }
}