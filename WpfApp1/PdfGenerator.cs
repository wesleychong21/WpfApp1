using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp1
{
    class PdfGenerator
    {
        string filename;
        Document _document;
        List<UnsafeRecord> _unsafeRecordDatas;
        Section section1;

        readonly static Color TableGrey = new Color(204, 204, 204);
        readonly static Color TableWhite = new Color(255, 255, 255);
        readonly static Color TableBlack = new Color(0, 0, 0);

        public PdfGenerator(string filename1, List<UnsafeRecord> unsafeRecordDatas1)
        {
            filename = filename1;
            _unsafeRecordDatas = unsafeRecordDatas1;

            _document = new Document();
            _document.Info.Title = "Unsafe Record";
            _document.Info.Author = "Wesley";
            _document.Info.Subject = "Unsafe Record";
            _document.Info.Keywords = "Unsafe Record";

            _document.DefaultPageSetup.RightMargin = 30;
            _document.DefaultPageSetup.LeftMargin = 30;
            
            DefineStyles(_document);

        }

        public void Generate()
        {
            try
            {
                section1 = _document.AddSection();
                section1.PageSetup.Orientation = Orientation.Landscape;
                HeadernFooter(); //add header and footer

                Table1();

                // Save the document...
          
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
                pdfRenderer.Document = _document;
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(filename);
            }
            catch (Exception )
            {

                throw;
            }

        }

        private void Table1()
        {

            Table table1 = section1.AddTable();
            table1.Style = "Table";
            table1.Borders.Color = TableBlack;
            table1.Borders.Width = 0.25;
            table1.Borders.Left.Width = 0.5;
            table1.Borders.Right.Width = 0.5;
            table1.Rows.LeftIndent = 0;
            Column column = table1.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table1.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table1.AddColumn("5cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table1.AddColumn("13cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table1.AddColumn("2.5cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            Row row = table1.AddRow();
            row.Cells[0].AddParagraph("Observer");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Shading.Color = TableGrey;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[1].AddParagraph("Observee");
            row.Cells[1].Format.Font.Bold = true;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Shading.Color = TableGrey;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[2].AddParagraph("Title");
            row.Cells[2].Format.Font.Bold = true;
            row.Cells[2].Shading.Color = TableGrey;
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[3].AddParagraph("Detail");
            row.Cells[3].Format.Font.Bold = true;
            row.Cells[3].Shading.Color = TableGrey;
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[4].AddParagraph("Report Date");
            row.Cells[4].Format.Font.Bold = true;
            row.Cells[4].Shading.Color = TableGrey;
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Center;

            // Row 2

            foreach (var unsafeRecord in _unsafeRecordDatas)
            {
                row = table1.AddRow();

                row.Cells[0].AddParagraph(unsafeRecord.Observer);
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[1].AddParagraph(unsafeRecord.Observee);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[2].AddParagraph(unsafeRecord.Title);
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[3].AddParagraph(unsafeRecord.Detail);
                row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

                row.Cells[4].AddParagraph(unsafeRecord.ReportDate.ToString("dd/MM/yyyy"));
                row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
            }
           
        }

        /// <summary>
        /// Defines the styles used to format the MigraDoc document.
        /// </summary>
        static void DefineStyles(Document _document)
        {
            // Get the predefined style Normal.
            var style = _document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Arial";

            style = _document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("18cm", TabAlignment.Right);

            style = _document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("3cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal.
            style = _document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Arial";
            style.Font.Size = 9;

            // Create a new style called Table based on style Normal.
            style = _document.Styles.AddStyle("Table2", "Normal");
            style.Font.Name = "Arial";
            style.Font.Size = 8;

            // Create a new style called Title based on style Normal.
            style = _document.Styles.AddStyle("Title", "Normal");
            style.Font.Name = "Arial bold";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal.
            style = _document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        private void HeadernFooter()
        {
            // Create the header.
            var header1 = section1.Headers.Primary.AddParagraph();
            header1.AddText("Unsafe Record");
            header1.Format.Font.Size = 11;
            header1.Format.Font.Bold = true;
            header1.Format.Alignment = ParagraphAlignment.Center;

            // Create the footer.         
            var footer2 = section1.Footers.Primary.AddParagraph();
            footer2.AddText("Page ");
            footer2.AddPageField();
            footer2.Format.Font.Size = 8;
            footer2.Format.Alignment = ParagraphAlignment.Center;
        }

    }
}
