using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;

using System.IO;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using X509Certificate = Org.BouncyCastle.X509.X509Certificate;
using iTextSharp.text.pdf.security;

namespace iTextSharpSign
{
    public partial class Form1 : Form
    {
        public signproperty osignproperty = new signproperty();
        X509Certificate2 certClient = null;
        X509Certificate2Collection collection = null;
        public Form1()
        {
            InitializeComponent();
            //LoadSystemCertificates();
        }


        private void debug(string txt)
        {
            DebugBox.AppendText(txt + System.Environment.NewLine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "PDF files *.pdf|*.pdf";
            openFile.Title = "Select a file";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            inputBox.Text = openFile.FileName;


            PdfReader reader = new PdfReader(inputBox.Text);

            MetaData md = new MetaData();
            md.Info = reader.Info;

            //authorBox.Text = md.Author;
            //titleBox.Text = md.Title;
            //subjectBox.Text = md.Subject;
            //kwBox.Text = md.Keywords;
            creatorBox.Text = md.Creator;
            prodBox.Text = md.Producer;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFile;
            saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.Filter = "PDF files (*.pdf)|*.pdf";
            saveFile.Title = "Save PDF File";
            if (saveFile.ShowDialog() != DialogResult.OK)
                return;
            outputBox.Text = saveFile.FileName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "Certificate files *.pfx|*.pfx";
            openFile.Title = "Select a file";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            certTextBox.Text = openFile.FileName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SignWithThisCert();            
            debug("Started ...");
            debug("Checking certificate ...");
            Cert myCert = null;
            try
            {
                myCert = new Cert(certTextBox.Text, passwordBox.Text);
                debug("Certificate OK");
            }
            catch (Exception ex)
            {
                debug("Error : please make sure you entered a valid certificate file and password");
                debug("Exception : " + ex.ToString());
                return;
            }
            debug("Creating new MetaData ... ");
            //Adding Meta Datas
            MetaData MyMD = new MetaData();
            MyMD.Author = authorBox.Text;
            MyMD.Title = titleBox.Text;
            MyMD.Subject = subjectBox.Text;
            MyMD.Keywords = kwBox.Text;
            MyMD.Creator = creatorBox.Text;
            MyMD.Producer = prodBox.Text;
            debug("Signing document ... ");
            PDFSigner pdfs = new PDFSigner(inputBox.Text, outputBox.Text, myCert, MyMD);
            pdfs.Sign(Reasontext.Text, Contacttext.Text, Locationtext.Text, SigVisible.Checked);
            debug("Done :)");
        }

        private void SignWithThisCert()
        {
            string SourcePdfFileName = inputBox.Text;
            string DestPdfFileName = outputBox.Text + "-Signed.pdf";

            X509Certificate2 cert = new X509Certificate2(certTextBox.Text, passwordBox.Text);
            X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
            X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(cert.RawData) };
            IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");

            PdfReader pdfReader = new PdfReader(SourcePdfFileName);
            FileStream signedPdf = new FileStream(DestPdfFileName, FileMode.Create);
            PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
            PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;

            signatureAppearance.Reason = "Because I can";
            signatureAppearance.Location = "My location";
            signatureAppearance.Acro6Layers = false;
            signatureAppearance.SetVisibleSignature(new iTextSharp.text.Rectangle(0, 00, 200, 100), pdfReader.NumberOfPages, "Signature");
            signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;

            MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
            MessageBox.Show("Done");
        }

        public bool LoadCertificates(ComboBox cmb)
        {
            try
            {
                X509Store st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                st.Open(OpenFlags.MaxAllowed);
                collection = st.Certificates;
                cmb.Items.Clear();
                foreach (X509Certificate2 cert in collection) cmb.Items.Add(cert.SubjectName.Name);
                cmb.SelectedIndex = 0;
                st.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SysSignCertificates(int certiindex, string IPF, string OPF,bool valisymbol=false)
        {
            {
                try
                {
                    certClient = new X509Certificate2();
                    PdfStamper pdfStamper = null;
                    IExternalSignature externalSignature = null;
                    PdfReader inputPdf = null;
                    IList<X509Certificate> chain = new List<X509Certificate>();

                    if (osignproperty.syscerti)
                    {
                        certClient = collection[certiindex];
                        //IList<X509Certificate> chain = new List<X509Certificate>();
                        X509Chain x509Chain = new X509Chain();
                        x509Chain.Build(certClient);
                        foreach (X509ChainElement x509ChainElement in x509Chain.ChainElements) chain.Add(DotNetUtilities.FromX509Certificate(x509ChainElement.Certificate));
                        string filename = @IPF;
                        inputPdf = new PdfReader(filename);
                        FileStream signedPdf = new FileStream(@OPF, FileMode.Create);
                        pdfStamper = PdfStamper.CreateSignature(inputPdf, signedPdf, '\0', null, true);
                        externalSignature = new X509Certificate2Signature(certClient, "SHA-256");
                    }
                    else
                    {
                        certClient = new X509Certificate2(osignproperty.username, osignproperty.pwd);
                        X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                        //X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(certClient.RawData) };
                        chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(certClient.RawData) };
                        string filename = @IPF;
                        inputPdf = new PdfReader(filename);
                        FileStream signedPdf = new FileStream(@OPF, FileMode.Create);
                        pdfStamper = PdfStamper.CreateSignature(inputPdf, signedPdf, '\0', null, true);
                        externalSignature = new X509Certificate2Signature(certClient, "SHA-1");
                    }

                    MetaData MyMD = new MetaData();
                    MyMD.Author = osignproperty.authorname;
                    pdfStamper.MoreInfo = (Dictionary<string, string>)MyMD.getMetaData();
                    pdfStamper.XmpMetadata = MyMD.getStreamedMetaData();
                    PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                    switch (osignproperty.font.ToString())
                    {
                        case "Helvetica":
                            signatureAppearance.Layer2Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA);
                            break;
                        case "Times-Roman":
                            signatureAppearance.Layer2Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN);
                            break;
                        case "Courier":
                            signatureAppearance.Layer2Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER);
                            break;
                    }

                    //PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                    //PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKLITE, PdfName.ADBE_PKCS7_DETACHED);
                    //dic.Date = new PdfDate(signatureAppearance.SignDate);
                    //dic.Name = CertificateInfo.GetSubjectFields(chain[0]).GetField("CN");
                    //signatureAppearance.CryptoDictionary = dic;
                    //signatureAppearance.Certificate = chain[0];
                    //signatureAppearance.Location = "test";

                    signatureAppearance.Acro6Layers = valisymbol;
                    signatureAppearance.Reason = osignproperty.reason;
                    signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
                    switch (osignproperty.signpage.ToString())
                    {
                        case "First Page":
                            signatureAppearance.SetVisibleSignature(
                            new iTextSharp.text.Rectangle(osignproperty.lx, osignproperty.ly, osignproperty.rx, osignproperty.ry, osignproperty.rotate),
                            1, osignproperty.signname);
                            break;
                        case "Last Page":
                            signatureAppearance.SetVisibleSignature(
                            new iTextSharp.text.Rectangle(osignproperty.lx, osignproperty.ly, osignproperty.rx, osignproperty.ry, osignproperty.rotate),
                            inputPdf.NumberOfPages, osignproperty.signname);
                            break;
                        case "Each Page":
                            for (int i = 0; i < inputPdf.NumberOfPages; i++)
                            {
                                signatureAppearance.SetVisibleSignature(
                                new iTextSharp.text.Rectangle(osignproperty.lx, osignproperty.ly, osignproperty.rx, osignproperty.ry, osignproperty.rotate),
                                i + 1, osignproperty.signname);
                            }
                            break;
                    }
                    MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
                    inputPdf.Close();
                    pdfStamper.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public class signproperty
        {
            private bool _syscerti = false;
            public bool syscerti
            {
                get { return _syscerti; }
                set { _syscerti = value; }
            }
            private string _signpage = string.Empty;
            public string signpage
            {
                get { return _signpage; }
                set { _signpage = value; }
            }

            private long _lx = 0;
            public long lx
            {
                get { return _lx; }
                set { _lx = value; }
            }

            private long _ly = 0;
            public long ly
            {
                get { return _ly; }
                set { _ly = value; }
            }

            private long _rx = 0;
            public long rx
            {
                get { return _rx; }
                set { _rx = value; }
            }

            private long _ry = 0;
            public long ry
            {
                get { return _ry; }
                set { _ry = value; }
            }

            private string _font = string.Empty;
            public string font
            {
                get { return _font; }
                set { _font = value; }
            }

            private string _signname = string.Empty;
            public string signname
            {
                get { return _signname; }
                set { _signname = value; }
            }

            private string _authorname = string.Empty;
            public string authorname
            {
                get { return _authorname; }
                set { _authorname = value; }
            }

            private string _reason = string.Empty;
            public string reason
            {
                get { return _reason; }
                set { _reason = value; }
            }

            private int _rotate = 0;
            public int rotate
            {
                get { return _rotate; }
                set { _rotate = value; }
            }
            private string _username = string.Empty;
            public string username
            {
                get { return _username; }
                set { _username = value; }
            }
            private string _pwd = string.Empty;
            public string pwd
            {
                get { return _pwd; }
                set { _pwd = value; }
            }
        }
    }
}