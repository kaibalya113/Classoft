using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text.html;

namespace ClassManager.Common
{
    public class ImportExport
    {
        public static void ImportToExcel(ADGV.AdvancedDataGridView dgv, string PathToSave = null, bool closeApp = false)
        {
            
            if (dgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass XcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                XcelApp.Application.Workbooks.Add(Type.Missing);

                int excelColumnIndex = 1;
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    if (dgv.Columns[i - 1].Visible == true && (dgv.Columns[i - 1].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                    {
                        XcelApp.Cells[1, excelColumnIndex] = dgv.Columns[i - 1].HeaderText;
                        excelColumnIndex++;
                    }
                    
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    excelColumnIndex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                        {
                            if (dgv.Rows[i].Cells[j].Value != null)
                            {
                                XcelApp.Cells[i + 2, excelColumnIndex] = dgv.Rows[i].Cells[j].Value.ToString();
                            }
                            excelColumnIndex++;
                        }

                    }

                }

                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;

                (XcelApp.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Activate();
                if (PathToSave != null)
                {
                    XcelApp.ActiveWorkbook.SaveAs(PathToSave);
                }

                if (closeApp == true)
                {
                    XcelApp.Quit();
                }

            }


        }

        public static void exportToExcel(DataTable dt, string PathToSave = null, bool closeApp = false)
        {
            if (dt.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass XcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                XcelApp.Application.Workbooks.Add(Type.Missing);

                int excelColumnIndex = 1;
                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, excelColumnIndex] = dt.Columns[i - 1].Caption;
                }
                excelColumnIndex++;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                        }
                    }

                }

                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;

                (XcelApp.Sheets[1] as Microsoft.Office.Interop.Excel.Worksheet).Activate();
                if (PathToSave != null)
                {
                    XcelApp.ActiveWorkbook.SaveAs(PathToSave);
                }

                if (closeApp == true)
                {
                    XcelApp.Quit();
                }

            }


        }

        //added by ashvini 4-12-17
        //these method is used to get parameters values and display pdf data and format these data as needed.

        public static void ImportToPDF(ADGV.AdvancedDataGridView dgv, string pathTosave, ClassManager.Common.PdfParameters getparamvalue, bool closeApp = false)
        {   //added by ashvini 4-12-17
            //creating parameter instance to display title
            Paragraph p = new Paragraph(getparamvalue.Title, FontFactory.GetFont(FontFactory.HELVETICA, 25, Font.NORMAL));
            p.Alignment = Element.ALIGN_CENTER;
            //end


            //added by ashvini 4-12-17
            //create pdftable to dispay stream, course, package
            int columns =3;
            PdfPTable DispayHeaderInfo = new PdfPTable(columns);
            DispayHeaderInfo.HorizontalAlignment = Element.ALIGN_CENTER;
            if (getparamvalue.name != null)
            {
                Phrase str = new Phrase(getparamvalue.name, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppw = new PdfPCell(str);
                ppw.Border = PdfPCell.NO_BORDER;
                ppw.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(ppw);


            }
            if (getparamvalue.Stream != null)
            {
                Phrase str = new Phrase(getparamvalue.Stream, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pp = new PdfPCell(str);
                pp.Border = PdfPCell.NO_BORDER;
                pp.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(pp);
            }
        
           
              
            if (getparamvalue.Course != null)
            {
                Phrase course = new Phrase(getparamvalue.Course, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppp = new PdfPCell(course);
                ppp.Border = PdfPCell.NO_BORDER;
                ppp.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(ppp);


            }
           
            if (getparamvalue.EnqNo != null)
            {
                Phrase course = new Phrase(getparamvalue.EnqNo, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppt = new PdfPCell(course);
                ppt.Border = PdfPCell.NO_BORDER;
                ppt.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(ppt);
            }
          
            if (getparamvalue.View != null)
            {
                Phrase course = new Phrase(getparamvalue.View, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell fd = new PdfPCell(course);
                fd.Border = PdfPCell.NO_BORDER;
                fd.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(fd);

            }
         
            if (getparamvalue.Package != null)
            {
                Phrase pack = new Phrase(getparamvalue.Package, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pppp = new PdfPCell(pack);
                pppp.Border = PdfPCell.NO_BORDER;
                pppp.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(pppp);
            }

            if (getparamvalue.BranchName!= "" && getparamvalue.BranchName != null)
            {
                Phrase br = new Phrase(getparamvalue.BranchName, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell cn = new PdfPCell(br);
                cn.Border = PdfPCell.NO_BORDER;
                cn.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(cn);
            }

            if (getparamvalue.Contact != "" && getparamvalue.Contact != null)
            {
                Phrase br = new Phrase(getparamvalue.Contact, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell cn = new PdfPCell(br);
                cn.Border = PdfPCell.NO_BORDER;
                cn.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(cn);
            }

            if (getparamvalue.ParentNo !=null)
            {
                Phrase pn = new Phrase(getparamvalue.ParentNo, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pm = new PdfPCell(pn);
                pm.Border = PdfPCell.NO_BORDER;
                pm.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(pm);
            }
            //end

            //added by ashvini 4-12-17
            //create pdfptable instance to display branch,fromdate,todate.

            int columnsForSecond = 3;
            PdfPTable DisplayHeaderInfo = new PdfPTable(columnsForSecond);
         
            if (getparamvalue.FromDate != "" && getparamvalue.FromDate != null)

            {
                Phrase fdate = new Phrase(getparamvalue.FromDate, FontFactory.GetFont("Arial", 15, Font.NORMAL));
                PdfPCell c2 = new PdfPCell(fdate);
                c2.Border = PdfPCell.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c2);
            }
            if (getparamvalue.ToDate != "" && getparamvalue.ToDate  != null)
            {
                Phrase Ldate = new Phrase(getparamvalue.ToDate, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell c3 = new PdfPCell(Ldate);
                c3.Border = PdfPCell.NO_BORDER;
                c3.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c3);
            }
            if (getparamvalue.GroupBy!=null)
            {
                Phrase gb = new Phrase(getparamvalue.GroupBy, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell g = new PdfPCell(gb);
                g.Border = PdfPCell.NO_BORDER;
                g.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(g);
            }
            if (getparamvalue.Branch != "" && getparamvalue.Branch != null)
            {
                Phrase br = new Phrase(getparamvalue.Branch, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell c1 = new PdfPCell(br);
                c1.Border = PdfPCell.NO_BORDER;
                c1.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c1);
            }
            if (getparamvalue.att_View != null)
            {
                Phrase vw = new Phrase(getparamvalue.att_View, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell va = new PdfPCell(vw);
                va.Border = PdfPCell.NO_BORDER;
                va.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(va);
            }
           int columnsForFooter= 1;
            PdfPTable DisplayFooter = new PdfPTable(columnsForFooter);

            //if (getparamvalue.count!="" && getparamvalue.count!=null)


            //if (getparamvalue.Footer != "" && getparamvalue.Footer != null)
            //{
            //    Phrase fo = new Phrase(getparamvalue.Footer, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
            //    PdfPCell fj = new PdfPCell(fo);
            //    fj.Border = PdfPCell.NO_BORDER;
            //    fj.HorizontalAlignment = Element.ALIGN_CENTER;
            //    DisplayFooter.AddCell(fj);
            //}
            {
                Phrase co = new Phrase(getparamvalue.count, FontFactory.GetFont("Arial", 19, Font.BOLD));
                PdfPCell c2 = new PdfPCell(co);
                c2.Border = PdfPCell.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_RIGHT;
                DisplayFooter.AddCell(c2);
            }
            //Paragraph p1 = new Paragraph(getparamvalue.count, FontFactory.GetFont(FontFactory.HELVETICA, 15, Font.NORMAL));
            //p1.Alignment = Element.ALIGN_RIGHT;
            Paragraph p2 = new Paragraph(getparamvalue.Footer, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
            p2.Alignment = Element.ALIGN_CENTER;
            //added by ashvini 4-12-17
            //the paragraph instance is used to dispay footer  
            //Paragraph f = new Paragraph(getparamvalue.Footer, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
            //f.Alignment = Element.ALIGN_CENTER;
            //end

            //added by ashvini 4-12-17
            //get visible rows count of gridview.      
            int f2 = 3;
            PdfPTable Dispayfooter = new PdfPTable(f2);
           Dispayfooter.HorizontalAlignment = Element.ALIGN_CENTER;
            if (getparamvalue.Present != null)
            {
                Phrase str = new Phrase(getparamvalue.Present, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppw = new PdfPCell(str);
                ppw.Border = PdfPCell.NO_BORDER;
                ppw.HorizontalAlignment = Element.ALIGN_CENTER;
                Dispayfooter.AddCell(ppw);


            }
            if (getparamvalue.Absent != null)
            {
                Phrase str = new Phrase(getparamvalue.Absent, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell pp = new PdfPCell(str);
                pp.Border = PdfPCell.NO_BORDER;
                pp.HorizontalAlignment = Element.ALIGN_CENTER;
                Dispayfooter.AddCell(pp);
            }



            if (getparamvalue.Total != null)
            {
                Phrase course = new Phrase(getparamvalue.Total, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell ppp = new PdfPCell(course);
                ppp.Border = PdfPCell.NO_BORDER;
                ppp.HorizontalAlignment = Element.ALIGN_CENTER;
                Dispayfooter.AddCell(ppp);


            }

            int TotalColumns = 0;
            int Colount = 0;
            for (int m = 1; m < dgv.Columns.Count + 1; m++)
            {
                if (dgv.Columns[m - 1].Visible == true && (dgv.Columns[m - 1].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                {
                    Colount = TotalColumns + 1;
                    TotalColumns++;
                }
            }
            //end

            //added by ashvini 4-12-17
            //added for new line
            int columnForNewline = 1;
            PdfPTable pdfname = new PdfPTable(columnForNewline);
            Phrase phSpace = new Phrase("\n");
            PdfPCell clSpace = new PdfPCell(phSpace);
            clSpace.Border = PdfPCell.NO_BORDER;
            clSpace.Colspan = columns;
            pdfname.AddCell(clSpace);
            PdfPTable pdfTable = new PdfPTable(Colount);
            pdfTable.DefaultCell.Padding = 6;
            pdfTable.HorizontalAlignment = 4;
      //      pdfTable.SetTotalWidth(new float[] { 40 });
            //end


            //added by ashvini 4-12-17
            //used to set headertext in pdf
            if (dgv.Rows.Count > 0)
            {


                int PDFColumnIndex = 1;
                for (int i = 1; i <dgv.Columns.Count+1; i++)
                {
                    if (dgv.Columns[i - 1].Visible == true && (dgv.Columns[i - 1].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                    {
                        string s = (dgv.Columns[i - 1].HeaderText);
                        Phrase ph = new Phrase(s, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD));
                        PdfPCell head = new PdfPCell(ph);
                        head.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));
                        head.PaddingBottom = 6;
                    
                        head.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
                        //var width = e.PdfPage.GetClientSize().Width;
                        pdfTable.AddCell(head);
                        PDFColumnIndex++;

                    }


                }


                //end

                //added by ashvini 4-12-17
                //by using these get data and ignore those columns data which contain images.
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    PDFColumnIndex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j].GetType().ToString().Equals("System.Windows.Forms.DataGridViewTextBoxColumn")))
                        {
                            if (dgv.Rows[i].Cells[j].Value != null)
                            {
                                PdfPCell pdfcell = new PdfPCell(new Phrase(dgv.Rows[i].Cells[j].FormattedValue.ToString()));
                                //  cell.Width = 200;
                                pdfcell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#f1f5f6"));
                               pdfcell.PaddingBottom = 6;
                              //  pdfcell.Width = 60;
                           
                                  pdfcell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER; 
                               
                                pdfTable.AddCell(pdfcell);
                            }
                            PDFColumnIndex++;
                        }
                    }
                }
            }

            //added by ashvini 4-12-17
            //used to set path and create documen and dispay pdf data.             
            using (FileStream stream = new FileStream(pathTosave, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(p);
                
                pdfDoc.Add(pdfname);

                pdfDoc.Add(DispayHeaderInfo);
                pdfDoc.Add(DisplayHeaderInfo);
               
                pdfDoc.Add(pdfname);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfname);
                pdfDoc.Add(Dispayfooter);
                pdfDoc.Add(DisplayFooter);

                pdfDoc.Add(p2);
                pdfDoc.Close();
                stream.Close();
            }



        }

      
    }
}
