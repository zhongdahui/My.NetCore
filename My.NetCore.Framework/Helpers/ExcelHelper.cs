using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Helpers
{
    public class ExcelHelper
    {
        public static byte[] Export(List<ArrayList> data)
        {
            using (var fs = new MemoryStream())
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    if (data != null && data.Count() > 0)
                    {
                        for (int i = 0; i < data.Count(); i++)
                        {
                            for (int j = 0; j < data[i].Count; j++)
                            {
                                worksheet.Cells[i + 1, j + 1].Value = data[i][j];
                            }
                        }
                    }

                    package.SaveAs(fs);
                    return fs.ToArray();
                }
            }
        }

        public static List<ArrayList> Import(Stream stream)
        {
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int row_count = worksheet.Dimension.Rows;
                int col_count = worksheet.Dimension.Columns;

                List<ArrayList> list = new List<ArrayList>();

                for (int row = 1; row <= row_count; row++)
                {
                    ArrayList array = new ArrayList();

                    for (int col = 1; col <= col_count; col++)
                    {
                        array.Add(worksheet.Cells[row, col].Value);
                    }

                    list.Add(array);
                }

                return list;
            }
        }
    }
}
