using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Utility.Excel
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>参考：http://qiita.com/hukatama024e/items/37427f2578a8987645dd
    /// </remarks>
    public class NPOIOperation
    {
        public static void CreateNewBook(string filePath)
        {
            try
            {
                //ブック作成
                var book = CreateNewBookBase(filePath);

                //シート無しのexcelファイルは保存は出来るが、開くとエラーが発生する
                book.CreateSheet("newSheet");

                //ブックを保存
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    book.Write(fs);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// パラメータで受け取ったパスの拡張子により適したオブジェクトを返却する
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IWorkbook CreateNewBookBase(string filePath)
        {
            IWorkbook book;
            var extension = Path.GetExtension(filePath);

            // HSSF => Microsoft Excel(xls形式)(excel 97-2003)
            // XSSF => Office Open XML Workbook形式(xlsx形式)(excel 2007以降)
            if (extension == ".xls")
            {
                book = new HSSFWorkbook();
            }
            else if (extension == ".xlsx")
            {
                book = new XSSFWorkbook();
            }
            else
            {
                throw new ApplicationException("CreateNewBook: invalid extension");
            }

            return book;
        }

        public void ReadExcel(string filePath)
        {
            try
            {
                //ブック読み込み
                var book = WorkbookFactory.Create(filePath);

                //シート名からシート取得
                var sheet = book.GetSheet("newSheet");


                //日付表示するために書式変更
                var datestyle = book.CreateCellStyle();
                datestyle.DataFormat = book.CreateDataFormat().GetFormat("text");

                //全て文字列に書式変更
                var stringstyle = book.CreateCellStyle();
                stringstyle.DataFormat = book.CreateDataFormat().GetFormat("text");

                //セルに設定
                WriteCell(sheet, 0, 0, "0-0", stringstyle);
                WriteCell(sheet, 1, 1, "1-1", stringstyle);
                WriteCell(sheet, 0, 3, 100, stringstyle);
                WriteCell(sheet, 0, 4, DateTime.Today, datestyle);

                var style = book.CreateCellStyle();
                style.DataFormat = book.CreateDataFormat().GetFormat("yyyy/mm/dd");
                WriteStyle(sheet, 0, 4, style);

                //ブックを保存
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //セル設定(文字列用)
        public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, string value, ICellStyle style)
        {
            // 初めにセルのスタイル設定
            WriteStyle(sheet, columnIndex, rowIndex, style);

            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        //セル設定(数値用)
        public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, double value, ICellStyle style)
        {
            // 初めにセルのスタイル設定
            WriteStyle(sheet, columnIndex, rowIndex, style);

            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        //セル設定(日付用)
        public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, DateTime value, ICellStyle style)
        {
            // 初めにセルのスタイル設定
            WriteStyle(sheet, columnIndex, rowIndex, style);

            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        //書式変更
        public static void WriteStyle(ISheet sheet, int columnIndex, int rowIndex, ICellStyle style)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.CellStyle = style;
        }
    }
}

