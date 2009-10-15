using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.UserModel.Contrib;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.Util;

namespace BSD.C4.Tlaxcala.Sai
{
    class CXls
    {
        CConn cconn;
        static HSSFWorkbook hssfworkbook;
        public CXls(CConn cconn)
        {
            this.cconn = cconn;
        }
        public bool saveToXLS(SqlDataReader rdr, string archivo)
        {
            try
            {
                InitializeWorkbook();

                HSSFSheet sheet1 = hssfworkbook.CreateSheet("Hoja1");

                int i = 0;
                int j = 1;
                HSSFRow title = sheet1.CreateRow(0);

                //font style1: underlined, italic, red color, fontsize=20
                HSSFFont font1 = hssfworkbook.CreateFont();
                font1.Color = HSSFColor.DARK_BLUE.index;
                font1.IsItalic = false;               
                font1.FontHeightInPoints = 14;

                //bind font with style 1
                HSSFCellStyle style1 = hssfworkbook.CreateCellStyle();
                style1.SetFont(font1);

                for (i = 0; i < rdr.FieldCount; i++)
                {                    
                    title.CreateCell(i).SetCellValue(rdr.GetName(i));
                    title.GetCell(i).CellStyle = style1;
                }

                while (rdr.Read())
                {
                    HSSFRow row = sheet1.CreateRow(j);
                    for (i = 0; i < rdr.FieldCount; i++)
                    {                                                
                        row.CreateCell(i).SetCellValue(rdr[i].ToString());                           
                    }
                    j++;
                }
                WriteToFile(archivo);
                rdr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        static void WriteToFile(string archivo)
        {
            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(archivo, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }

        static void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();

            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;
        }
    }
}
