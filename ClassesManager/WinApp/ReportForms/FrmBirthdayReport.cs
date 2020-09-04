//added by ashvini to display birthday reort between fromdate and Todate on 25-01-2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;
using ClassManager.BLL;
using ClassManager.Info;
using System.Net.Mail;
using ClassManager.Info.Reporting;
using System.IO;
using System.Web;
using ClassManager.Common;
using iTextSharp.text.html;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text.html.simpleparser;
namespace ClassManager.WinApp
{
    public partial class FrmBirthdayReport : FrmParentForm
    {
        string sCaption = "Birthday Report";
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        public FrmBirthdayReport()
        {
            InitializeComponent();
        }

        private void FrmBirthdayReport_Load(object sender, EventArgs e)
        {
            cmbMonths.Items.Add(new ComboItem(0, "Select Month"));
            cmbMonths.Items.Add(new ComboItem(1, "Jan"));
            cmbMonths.Items.Add(new ComboItem(2, "Feb"));
            cmbMonths.Items.Add(new ComboItem(3, "Mar"));
            cmbMonths.Items.Add(new ComboItem(4, "Apr"));
            cmbMonths.Items.Add(new ComboItem(5, "May"));
            cmbMonths.Items.Add(new ComboItem(6, "Jun"));
            cmbMonths.Items.Add(new ComboItem(7, "Jul"));
            cmbMonths.Items.Add(new ComboItem(8, "Aug"));
            cmbMonths.Items.Add(new ComboItem(9, "Sep"));
            cmbMonths.Items.Add(new ComboItem(10, "Oct"));
            cmbMonths.Items.Add(new ComboItem(11, "Nov"));
            cmbMonths.Items.Add(new ComboItem(12, "Dec"));

            cmbMonths.SelectedIndex = DateTime.Now.Month;

            BirthdayGrid.DataSource = WinForm.ToDataTable(BLL.MarketingHandler.getBirthdayReport(cmbMonths.SelectedIndex, branchID));
            formatBirthdayGrid();

        }

        public static DataTable sendBirthdaySMS(List<Info.Marketing> lstStudent)
        {
            try
            {
                bool allowtoSndBrthdaySMS = Info.SysParam.getValue<bool>(SysParam.Parameters.SEND_BDAY_SMS);

                if (allowtoSndBrthdaySMS)
                {
                    Dictionary<string, string> smsData = new Dictionary<string, string>();
                    string smsTemplate;

                    //Get sms config                
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //Traversing each student
                    foreach (Info.Marketing student in lstStudent)
                    {
                        //get template
                        smsTemplate = Template.getValue<string>(Info.TemplateType.BIRTHDAYSMS);

                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());
                        smsBody.Replace(":Name", student.Name);
                        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                        string Phone = student.ContactNo;

                        if (!smsData.ContainsKey(Phone))
                        {
                            smsData.Add(student.ContactNo, smsBody.ToString());
                        }

                    }

                    MailHandler.sendSMS(smsConfig, smsData, false, "BirthDaySMS");
                }

                return Common.Utility.ToDataTable<Info.Marketing>(lstStudent);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public void formatBirthdayGrid()
        {
            //Hiding Columns.
            BirthdayGrid.Columns["Id"].Visible = false;
            BirthdayGrid.Columns["Group"].Visible = false;
            BirthdayGrid.Columns["Anniversary"].Visible = false;
            BirthdayGrid.Columns["EmailID"].Visible = false;
            BirthdayGrid.Columns["StudType"].Visible = false;

            //Formatting Date.
            BirthdayGrid.Columns["BirthDay"].DefaultCellStyle = UICommon.WinForm.GridDateFormat;
            BirthdayGrid.Columns["ContactNo"].HeaderText = "Contact";
            BirthdayGrid.Columns["BirthDay"].HeaderText ="Date";
        }




        private void btnSend_Click(object sender, EventArgs e)
        {
            sendBirthdaySMS(BLL.MarketingHandler.getBirthdayReport(cmbMonths.SelectedIndex, Program.LoggedInUser.BranchId.ToString()));

            UICommon.WinForm.showStatus("Message Sent Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        }



        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                BirthdayGrid.DataSource = WinForm.ToDataTable(BLL.MarketingHandler.getBirthdayReport(cmbMonths.SelectedIndex, branchID));
                formatBirthdayGrid();
                if (BirthdayGrid.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(BirthdayGrid, null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ImportToPDF(ADGV.AdvancedDataGridView dgv, string pathTosave, ClassManager.Common.PdfParameters getparamvalue, bool closeApp = false)
        {   //added by ashvini 4-12-17
            //creating parameter instance to display title
            Paragraph p = new Paragraph(getparamvalue.Title, FontFactory.GetFont(FontFactory.HELVETICA, 25));
            p.Alignment = Element.ALIGN_CENTER;
            //end


            //added by ashvini 4-12-17
            //create pdftable to dispay stream, course, package
            int columns = 3;
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

            if (getparamvalue.BranchName != "" && getparamvalue.BranchName != null)
            {
                Phrase br = new Phrase(getparamvalue.BranchName, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell cn = new PdfPCell(br);
                cn.Border = PdfPCell.NO_BORDER;
                cn.HorizontalAlignment = Element.ALIGN_CENTER;
                DispayHeaderInfo.AddCell(cn);
            }


            //end

            //added by ashvini 4-12-17
            //create pdfptable instance to display branch,fromdate,todate.

            int columnsForSecond = 3;
            PdfPTable DisplayHeaderInfo = new PdfPTable(columnsForSecond);

            if (getparamvalue.FromDate != "" && getparamvalue.FromDate != null)

            {
                Phrase fdate = new Phrase(getparamvalue.FromDate, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell c2 = new PdfPCell(fdate);
                c2.Border = PdfPCell.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c2);
            }
            if (getparamvalue.ToDate != "" && getparamvalue.ToDate != null)
            {
                Phrase Ldate = new Phrase(getparamvalue.ToDate, FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.NORMAL));
                PdfPCell c3 = new PdfPCell(Ldate);
                c3.Border = PdfPCell.NO_BORDER;
                c3.HorizontalAlignment = Element.ALIGN_CENTER;
                DisplayHeaderInfo.AddCell(c3);
            }
            if (getparamvalue.GroupBy != null)
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
            int columnsForFooter = 1;
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
                Phrase co = new Phrase(getparamvalue.count, FontFactory.GetFont("Arial", 19, iTextSharp.text.Font.NORMAL));
                PdfPCell c2 = new PdfPCell(co);
                c2.Border = PdfPCell.NO_BORDER;
                c2.HorizontalAlignment = Element.ALIGN_RIGHT;
                DisplayFooter.AddCell(c2);
            }
            //Paragraph p1 = new Paragraph(getparamvalue.count, FontFactory.GetFont(FontFactory.HELVETICA, 15, Font.NORMAL));
            //p1.Alignment = Element.ALIGN_RIGHT;
            Paragraph p2 = new Paragraph(getparamvalue.Footer, FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
            p2.Alignment = Element.ALIGN_CENTER;
            //added by ashvini 4-12-17
            //the paragraph instance is used to dispay footer  
            //Paragraph f = new Paragraph(getparamvalue.Footer, FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL));
            //f.Alignment = Element.ALIGN_CENTER;
            //end

            //added by ashvini 4-12-17
            //get visible rows count of gridview.      

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
            float[] widths = new float[] { 35, 20, 20 };
            pdfTable.WidthPercentage = 55f;
            pdfTable.SetWidths(widths);
            pdfTable.DefaultCell.Padding = 6;

            pdfTable.HorizontalAlignment = 4;
            // pdfTable.SetTotalWidth(new float[] { 40 });
            //end


            //added by ashvini 4-12-17
            //used to set headertext in pdf
            if (dgv.Rows.Count > 0)
            {


                int PDFColumnIndex = 1;
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
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
                        //var width = e.PdfPage.GetClientSize().Widh;
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
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(p);

                pdfDoc.Add(pdfname);

                pdfDoc.Add(DispayHeaderInfo);
                pdfDoc.Add(DisplayHeaderInfo);

                pdfDoc.Add(pdfname);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(pdfname);

                pdfDoc.Add(DisplayFooter);

                pdfDoc.Add(p2);
                pdfDoc.Close();
                stream.Close();
            }



        }

        private void btn_saveToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                BirthdayGrid.DataSource = WinForm.ToDataTable(BLL.MarketingHandler.getBirthdayReport(cmbMonths.SelectedIndex, branchID));
                formatBirthdayGrid();
                PdfParameters getParameter = new PdfParameters();


                getParameter.FromDate = (cmbMonths.SelectedItem as ComboItem).name;
                getParameter.ToDate = (cmbMonths.SelectedItem as ComboItem).name;
                getParameter.Footer = "Printed On:-" + DateTime.Now;
                getParameter.Title = "Birthday Report";
                getParameter.Branch = "BranchID:- " + Program.LoggedInUser.Branch.BranchName;

                //added by ashvini 4-12-17
                //in these method get path for saving pdf
                if (BirthdayGrid.Rows.Count != 0)

                {
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pathTosave = folderDlg.SelectedPath + "\\Birthday Report.PDF";
                        Environment.SpecialFolder root = folderDlg.RootFolder;
                        //added by ashvini 4-12-17
                        //these method is used to get parameters with value and pass them to common 
                        ImportToPDF(BirthdayGrid, pathTosave, getParameter);
                        UICommon.WinForm.showStatus("PDF Created Successfully.", sCaption, this);
                    }
                }
                else
                {
                    WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            BirthdayGrid.DataSource = WinForm.ToDataTable(BLL.MarketingHandler.getBirthdayReport(cmbMonths.SelectedIndex, branchID));
            formatBirthdayGrid();
        }
    }
}


//end by ashvini 25-01-2019