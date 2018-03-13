using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Drawing;
using System.IO;
using System.Drawing;
using Aspose.Cells;
using Aspose.Words.Reporting;


namespace ASPONSE_Words
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始进行操作");
            DataTable dt = new DataTable();
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("xm", typeof(string));
            dt.Columns.Add("xb", typeof(string));
            dt.Columns.Add("mz", typeof(string));
            dt.Columns.Add("nl", typeof(string));
            dt.Columns.Add("Photo1", typeof(string));
            dt.Columns.Add("Photo2", typeof(string));
            dt.Columns.Add("Photo3", typeof(string));
            dt.Columns.Add("Photo4", typeof(string));
            dt.Columns.Add("xslb_check_1", typeof(string));
            dt.Columns.Add("xslb_check_2", typeof(string));
            dt.Columns.Add("xslb_check_3", typeof(string));

            DataRow dr = dt.NewRow();
            dr["title"] = "测试";
            dr["xm"] = "华哥\n无敌";
            dr["xb"] = "男神";
            dr["mz"] = "汉族";
            dr["nl"] = "18";
            dr["Photo1"] = "../File/1.jpg";
            dr["Photo2"] = "../File/2.jpg";
            dr["Photo3"] = "../File/3.jpg";
            dr["Photo4"] = "../File/4.jpg";
            dr["xslb_check_1"] = "1";
            dr["xslb_check_2"] = "0";
            dr["xslb_check_3"] = "0";
            dt.Rows.Add(dr);
            var fileUrl = "../File/test11.doc";
            try
            {
                Print(fileUrl, dt);
                //Document doc = new Document("../File/test11.doc");
                //ReplaceFont11("CHECK_T", doc);
                //doc.Save("huage111.doc");
                Console.WriteLine("替换成功");
            }
            catch (Exception)
            {
                Console.WriteLine("替换失败");
            }

            Console.ReadKey();
        }

        public static void Print(string fileurl, DataTable dtInfo)
        {
            Document doc = new Document(fileurl);

            //string[] arr = { "CHECK_T","CHECK_F"};
            //foreach (var a in arr)
            //{
            //    doc.Range.Replace("$" + a + "$", "#" + a + "#", false, false);
            //    Regex regx1 = new Regex("#" + a + "#");
            //    doc.Range.Replace(regx1, new ReplaceFont(a), false);
            //}
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                var dr = dtInfo.Rows[0];
                foreach (DataColumn dc in dtInfo.Columns)
                {
                    var nValue = dr[dc.ColumnName] + "";
                    try
                    {
                        if (dc.ColumnName.ToLower().Contains("photo"))
                        {
                            if (File.Exists(nValue))
                            {
                                Regex reg = new Regex("#" + dc.ColumnName + "#");
                                doc.Range.Replace(reg, new ReplaceImage2(nValue), false);
                            }
                        }
                        else if (dc.ColumnName.ToLower().Contains("check"))
                        {
                            doc.Range.Replace("$" + dc.ColumnName + "$", "#" + dc.ColumnName + "#", false, false);
                            Regex regx = new Regex("#" + dc.ColumnName + "#");
                            doc.Range.Replace(regx, new ReplaceFont(nValue), false);
                        }
                        else
                        {
                            if (nValue.Contains("\n"))
                            {
                                doc.Range.Replace("$" + dc.ColumnName + "$", "#" + dc.ColumnName + "#", false, false);
                                Regex reg = new Regex("#" + dc.ColumnName + "#");
                                doc.Range.Replace(reg, new ReplaceHtml(nValue), false);
                            }
                            else doc.Range.Replace("$" + dc.ColumnName + "$", nValue, false, false);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            WaterMark(doc, "华哥无敌");
            doc.Save("huage.doc");
        }
        public static void WaterMark(Document mdoc, string wmText)
        {
            Aspose.Words.Drawing.Shape waterShape = new Aspose.Words.Drawing.Shape(mdoc, ShapeType.TextPlainText);
            //设置该文本的水印
            waterShape.TextPath.Text = wmText;
            waterShape.TextPath.FontFamily = "宋体";
            waterShape.Width = 200;
            waterShape.Height = 100;
            //文本将从左下角到右上角。
            waterShape.Rotation = -40;
            //绘制水印颜色
            waterShape.Fill.Color = Color.Gray;//浅灰色水印
            waterShape.StrokeColor = Color.Gray;
            //将水印放置在页面中心
            waterShape.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
            waterShape.RelativeVerticalPosition = RelativeVerticalPosition.Page;
            waterShape.WrapType = WrapType.None;
            waterShape.VerticalAlignment = VerticalAlignment.Center;
            waterShape.HorizontalAlignment = HorizontalAlignment.Center;

            // 创建一个新段落并在该段中添加水印。 
            Paragraph watermarkPara = new Paragraph(mdoc);
            watermarkPara.AppendChild(waterShape);

            // 在每个部分中，最多可以有三个不同的标题，因为我们想要出现在所有页面上的水印，插入到所有标题中。  
            foreach (Section sect in mdoc.Sections)
            {
                // 每个区段可能有多达三个不同的标题，因为我们希望所有页面上都有水印，将所有的头插入。
                InsertWatermarkIntoHeader(watermarkPara, sect, HeaderFooterType.HeaderPrimary);
                InsertWatermarkIntoHeader(watermarkPara, sect, HeaderFooterType.HeaderFirst);
                InsertWatermarkIntoHeader(watermarkPara, sect, HeaderFooterType.HeaderEven);
            }
        }
        private static void InsertWatermarkIntoHeader(Paragraph watermarkPara, Section sect, HeaderFooterType headerType)
        {
            HeaderFooter header = sect.HeadersFooters[headerType];

            if (header == null)
            {
                // 当前节中没有指定类型的头，创建它
                header = new HeaderFooter(sect.Document, headerType);
                sect.HeadersFooters.Add(header);
            }

            // 在头部插入一个水印的克隆
            header.AppendChild(watermarkPara.Clone(true));
        }

        public static void ReplaceFont11(string key, Document doc)
        {
            DocumentBuilder builder = new DocumentBuilder(doc);
            // builder.MoveToMergeField("$CHECK_T$");
            var aa = doc.MailMerge.GetFieldNames();
            while (builder.MoveToMergeField(key, true, false))
            {
                //builder.MoveToBookmark("CHECK_T");
                builder.ParagraphFormat.StyleIdentifier = Aspose.Words.StyleIdentifier.BodyText;
                builder.Font.Name = "Wingdings 2";
                builder.Font.Size = 12;
                //builder.Font.Italic = true;
                builder.Write("R");
            }
        }
    }

    public class ReplaceImage1 : IReplacingCallback
    {
        public string imageUrl;
        public string Barcode;

        public ReplaceImage1(string url)
        {
            this.imageUrl = url;
        }

        public ReplaceAction Replacing(ReplacingArgs e)
        {
            //获取当前节点
            var node = e.MatchNode;
            //获取当前文档
            Document doc = node.Document as Document;
            DocumentBuilder builder = new DocumentBuilder(doc);
            //将光标移动到指定节点
            builder.MoveTo(node);
            //插入图片
            builder.InsertImage(imageUrl);
            return ReplaceAction.Replace;
        }

    }

    public class ReplaceImage2 : IReplacingCallback
    {
        public string imageUrl;
        public string Barcode;

        public ReplaceImage2(string url)
        {
            this.imageUrl = url;
        }

        public ReplaceAction Replacing(ReplacingArgs e)
        {
            //获取当前节点        
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var node = e.MatchNode;
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                builder.MoveTo(node);
                Aspose.Words.Drawing.Shape shape = new Aspose.Words.Drawing.Shape(doc, ShapeType.Image);
                shape.ImageData.SetImage(imageUrl);
                shape.Width = 80;
                shape.Height = 104;
                shape.DistanceTop = 10;
                shape.HorizontalAlignment = HorizontalAlignment.Center;
                shape.VerticalAlignment = VerticalAlignment.Center;
                builder.InsertNode(shape);
            }
            return ReplaceAction.Replace;
        }

    }

    public class ReplaceHtml : IReplacingCallback
    {
        public string Text;

        public ReplaceHtml(string str)
        {
            this.Text = str;
        }

        public ReplaceAction Replacing(ReplacingArgs e)
        {
            //获取当前节点        
            if (!string.IsNullOrEmpty(Text))
            {
                Node node = e.MatchNode;
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                builder.MoveTo(node);
                builder.Write(Text);
            }
            return ReplaceAction.Replace;
        }

    }

    public class ReplaceFont : IReplacingCallback
    {
       
        public string Text { get; set; }
        public ReplaceFont(string Text)
        {
            this.Text = Text;
        }
        public ReplaceAction Replacing(ReplacingArgs e)
        {
            //获取当前节点        
            var node = e.MatchNode;
            Document doc = node.Document as Document;
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.MoveTo(node);
            builder.ParagraphFormat.StyleIdentifier = Aspose.Words.StyleIdentifier.BodyText;
            builder.Font.Name = "Wingdings 2";
            //builder.Font.Italic = true;//斜体
            if (Text == "1")
            {               
                builder.Font.Size = 12;             
                builder.Write("R");
            }
            else
            {
                builder.Font.Size = 11.5;
                builder.Write("□");
            }
            return ReplaceAction.Replace;
        }
    }

    public class HandleMergeFieldInsertHtml : IFieldMergingCallback
    {
        //文本处理在这里
        void IFieldMergingCallback.FieldMerging(FieldMergingArgs e)
        {
            if (e.DocumentFieldName.Equals("Desc"))
            {
                // 使用DocumentBuilder处理图片的大小
                DocumentBuilder builder = new DocumentBuilder(e.Document);
                builder.MoveToMergeField(e.FieldName);
                builder.InsertHtml(e.FieldValue.ToString());
            }
        }
        //图片处理在这里
        void IFieldMergingCallback.ImageFieldMerging(ImageFieldMergingArgs args)
        {

        }
    }

}
