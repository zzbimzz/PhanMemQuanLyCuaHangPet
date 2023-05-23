﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BUS
{
    public class ExcelHelper
    {
        public static void WriteExcelFile(string outputPath, string templateFilePath, DataTable table)
        {
            File.Copy(templateFilePath, outputPath, true);
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(outputPath, true))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                List<string> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                }


                Row lastRow = sheetData.Elements<Row>().LastOrDefault();

                uint newRowNumber = lastRow != null ? lastRow.RowIndex + 1 : 1;
                uint stt = 1;

                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row() { RowIndex = newRowNumber++ };

                    Cell sttCell = new Cell();
                    sttCell.DataType = CellValues.Number;
                    sttCell.CellValue = new CellValue(stt++.ToString());
                    newRow.AppendChild(sttCell);

                    foreach (String col in columns)
                    {
                        Cell cell = new Cell();

                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(newRow);
                }
                workbookPart.Workbook.Save();
                Process.Start(outputPath);

            }
        }
    }
}
