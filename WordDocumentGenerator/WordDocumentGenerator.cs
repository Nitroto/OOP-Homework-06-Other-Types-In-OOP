using Novacode;
using System;
using System.Drawing;
using System.IO;

namespace WordDocumentGenerator
{
    class WordDocumentGenerator
    {
        static void Main()
        {
            string fileName = @"..\..\GameContest.docx";
            string imageAddres = @"..\..\res\rpg-game.png";
            Color darkBlue = Color.FromArgb(18, 50, 89);

            using (DocX document = DocX.Create(fileName))
            {
                // Title
                Paragraph title = document.InsertParagraph().Append("SoftUni OOP Game Contest").Font(new FontFamily("Calibri")).FontSize(20).Bold().SpacingAfter(1.5);
                title.Alignment = Alignment.center;

                // Image
                using (MemoryStream ms = new MemoryStream())
                {
                    var img = System.Drawing.Image.FromFile(imageAddres);
                    double xScale = 1;
                    double yScale = 1;
                    double maxWidth = 6.673;
                    double maxHeight = 2.575;
                    double hScale = ((double)96 / img.HorizontalResolution);
                    double vScale = ((double)96 / img.VerticalResolution);
                    double imageWidth = img.Width / img.HorizontalResolution;
                    if (maxWidth < imageWidth)
                    {
                        xScale = maxWidth / imageWidth * hScale;
                    }
                    double imageHeight = img.Height / img.VerticalResolution;
                    if (maxHeight < imageHeight)
                    {
                        yScale = maxHeight / imageHeight * vScale;
                    }
                    double finalScale = Math.Min(xScale, yScale);

                    img.Save(ms, img.RawFormat);
                    ms.Seek(0, SeekOrigin.Begin);

                    Novacode.Image image = document.AddImage(ms);
                    Picture pic = image.CreatePicture();
                    pic.Height = (int)(Math.Round((double)img.Height * finalScale));
                    pic.Width = (int)(Math.Round((double)img.Width * finalScale));
                    Paragraph picture = document.InsertParagraph();
                    picture.InsertPicture(pic, 0);
                }
                Paragraph empty = document.InsertParagraph();

                // Main text
                Paragraph textMain = document.InsertParagraph()
                    .Append("SoftUni is organizing a contest for the best ")
                    .Append("role playing game").Bold()
                    .Append(" from the OOP teamwork projects. The winning teams will receive a ")
                    .Append("grand prize").UnderlineStyle(UnderlineStyle.singleLine)
                    .Append("! The game should be:");
                textMain.Alignment = Alignment.both;

                // Bullets
                var list = document.AddList(listType: ListItemType.Bulleted);
                document.AddListItem(list, "Properly structured and follow all good OOP practices", 0);
                document.AddListItem(list, "Awesome",0);
                document.AddListItem(list, "..Very Awesome",0);
                document.InsertList(list);

                document.InsertParagraph(empty);

                //Table
                Table table = document.AddTable(4, 3);
                table.Design = TableDesign.LightListAccent1;
                table.Alignment = Alignment.center;
                table.Rows[0].Cells[0].Paragraphs[0].Append("Team");
                table.Rows[0].Cells[0].Paragraphs[0].Alignment = Alignment.center;
                table.Rows[0].Cells[1].Paragraphs[0].Append("Game");
                table.Rows[0].Cells[1].Paragraphs[0].Alignment = Alignment.center;
                table.Rows[0].Cells[2].Paragraphs[0].Append("Points");
                table.Rows[0].Cells[2].Paragraphs[0].Alignment = Alignment.center;
                for (int row = 1; row < table.RowCount; row++)
                {
                    for (int col = 0; col < table.ColumnCount; col++)
                    {
                        table.Rows[row].Cells[col].Paragraphs[0].Append("-");
                        table.Rows[row].Cells[col].Paragraphs[0].Alignment = Alignment.center;
                    }
                }
                document.InsertTable(table);

                document.InsertParagraph(empty);

                // Final Text
                Paragraph finalText = document.InsertParagraph()
                    .Append("The top 3 teams will receive a ")
                    .Append("SPECTACULAR").Bold()
                    .Append(" prize:")
                    .AppendLine("A HANDSHAKE FROM NAKOV").Font(new FontFamily("Calibri")).FontSize(18).UnderlineStyle(UnderlineStyle.singleLine).Color(darkBlue).Bold();
                finalText.Alignment = Alignment.center;

                document.Save();
            }
        }
    }
}
