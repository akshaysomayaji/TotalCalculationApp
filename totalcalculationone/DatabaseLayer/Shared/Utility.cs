using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

namespace DataObjects
{
    /// <summary>
    /// Common Utility Clas.
    /// </summary>
    public static class Utility
    {
        public static string ActionEncrypt(long id)
        {
            return ""; //Encryption.Crypto.ActionEncrypt(id.ToString());
        }
        public static string GetMonthName(int monthno)
        {
            string[] monthnames = { "January" , "February" , "March" , "April" , "May" , "June", "July" , "August" , "September",
                                    "October", "November" , "December" };

            return monthno > 0 && monthno <= 12 ? monthnames[monthno - 1] : string.Empty;
        }

        public static DataTable getDataTable(List<long> objList)
        {
            DataTable dtbl = new DataTable();

            DataColumn dcolmn = null;

            int intLoop = 0;

            string[] strColumns = new string[1] { "ID" };
            Type[] types = new Type[1] { typeof(System.Int64)
            };

            for (intLoop = 0; intLoop <= strColumns.GetUpperBound(0); intLoop++)
            {
                dcolmn = new DataColumn(strColumns[intLoop], types[intLoop]);
                dtbl.Columns.Add(dcolmn);

            }

            for (intLoop = 0; intLoop < objList.Count; intLoop++)
            {
                DataRow drw = dtbl.NewRow();


                drw["ID"] = objList[intLoop];


                dtbl.Rows.Add(drw);


            }
            return dtbl;
        }

        public static string RetrieveAppNameFromUrl(string sHostName)
        {
            string[] sSplitHostName = new string[3];
            string sAppName = string.Empty;
            if (!string.IsNullOrEmpty(sHostName))
            {
                int iStartIndex = sHostName.IndexOf('.');
                int iLastIndex = sHostName.LastIndexOf('.');
                /* handle localhost scenario */
                if ((iStartIndex == iLastIndex) && iLastIndex == -1)
                {
                    sAppName = sHostName;
                }
                else
                {
                    //sHostName = sHostName.Substring(iStartIndex + 1, iLastIndex - iStartIndex - 1);
                    sHostName = sHostName.Substring(0, iStartIndex);

                    sSplitHostName = sHostName.Split('.');
                    if (sSplitHostName.GetUpperBound(0) >= 0)
                    {
                        sAppName = sSplitHostName[0];
                    }
                }

            }

            return !string.IsNullOrEmpty(sAppName) ? sAppName.ToLower() : string.Empty;
        }

        /// <summary>
        /// Get From date and ToDate for fiscal year and quarter
        /// </summary>
        /// <param name="iFiscalYr"></param>
        /// <param name="iQuarter"></param>
        /// <returns></returns>
        /// <remarks>
        /// if fiscal =0 then return fromdate=01-APR-2012 & 31-mar-2015 ( current fiscal year and past 3 yrs)
        /// else based on the quarter and year get the quarter start and end date
        /// </remarks>
        public static string[] GetFromAndToDateForFiscalAndQuarter(int iFiscalYr, int iQuarter)
        {
            string[] sFromToDates = new string[2];
            string fromdate = string.Empty, todate = string.Empty;
            if (iFiscalYr == 0)
            {
                int year = DateTime.Now.Year;
                //check if current datetime is in fourth quarter.
                if (DateTime.Now.Month <= 3)
                    year = year - 1;

                fromdate = "01-APR-" + (year - 2).ToString();
                todate = "31-MAR-" + (year + 1).ToString();
            }
            else
            {
                switch (iQuarter)
                {
                    case 1:
                        fromdate = "01-APR-" + (iFiscalYr - 1).ToString();
                        todate = "30-JUN-" + (iFiscalYr - 1).ToString();
                        break;
                    case 2:
                        fromdate = "01-JUL-" + (iFiscalYr - 1).ToString();
                        todate = "30-SEP-" + (iFiscalYr - 1).ToString();
                        break;
                    case 3:
                        fromdate = "01-OCT-" + (iFiscalYr - 1).ToString();
                        todate = "31-DEC-" + (iFiscalYr - 1).ToString();
                        break;
                    case 4:
                        fromdate = "01-JAN-" + (iFiscalYr).ToString();
                        todate = "31-MAR-" + (iFiscalYr).ToString();
                        break;
                    default:
                        fromdate = "01-APR-" + (iFiscalYr - 1).ToString();
                        todate = "31-MAR-" + (iFiscalYr).ToString();
                        break;
                }
            }
            sFromToDates[0] = fromdate;
            sFromToDates[1] = todate;
            return sFromToDates;
        }
    }
}
