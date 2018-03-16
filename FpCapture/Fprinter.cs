using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Drawing.Imaging;
using FpCapture;
using System.Runtime.InteropServices;
using System.Diagnostics;


enum LIVESCAN_ERR{
	LIVESCAN_E_NOERR            =  1,	//No error
	LIVESCAN_E_PARAM			= -1,	//Parameter error
	LIVESCAN_E_MEMORY			= -2,	//Memory error
	LIVESCAN_E_FUNC_NOT_EXIST	= -3,	//Function not implemented error
	LIVESCAN_E_NO_DEVICE		= -4,	//Device does not exist error
	LIVESCAN_E_DEV_NOT_INIT		= -5,	//The device is not initialized
	LIVESCAN_E_ILLEGAL			= -6,	//Illegal wrong number
	LIVESCAN_E_UNDEFINED		= -9,	//Other error(Communication failure)
	LIVESCAN_E_TRANS			= -101,	//Other error(No begin capture)
	LIVESCAN_E_BEGINCAP			= -103,	//Other error(No end capture)
	LIVESCAN_E_ENDCAP			= -104,	//Other error(the device is busy)
	LIVESCAN_E_THEAD            = -105, //Other error
	LIVESCAN_E_NoSupportSetup   = 0,    //No support setup dialog box
 
};

namespace FpCapture
{

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct FPSPLIT_INFO_
    {
        public int x;
        public int y;
        public int angle;
        //unsigned char quality;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string reserved;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=144000)]
        public byte[] pRawDatapOutBuf;
    } ;



    public partial class Fprinter : Form
    {

        FPSPLIT_INFO_[] fpslit_info_ = new FPSPLIT_INFO_[10];
      
       


        byte[] m_CutFrame;
        byte[] m_BMPFrame;

        bool bIsSplit=false;

        int FpNum = 0;
                         
        int CDCW = 1600;
        int CDCH = 1500;
        int SplitW = 300;
        int SplitH = 480;
        int m_Bright;
        int m_Contrast;
        Bitmap Bmpdata;
        IntPtr SourcePtr = new IntPtr();     
       
        Program FPprogram = new Program();
        WSQImageLibraryNativeMethods WSQ_library_native_methods = new WSQImageLibraryNativeMethods();
        //private WSQImageLibraryNativeMethods WSQ_library_native_methods;
      

        public Fprinter()
        {
            InitializeComponent();
          
            SourcePtr = Marshal.AllocHGlobal((int)(CDCW * CDCH));
            WSQ_library_native_methods = new WSQImageLibraryNativeMethods();

            m_CutFrame = new byte[CDCW*CDCH];
            m_BMPFrame = new byte[CDCW * CDCH + 1078];


            //for (int i = 0; i < 10; i++)
            //{
            //   fpslit_info_[i] = new FPSPLIT_INFO_();
            //    fpslit_info_[i].pRawDatapOutBuf = new byte[SplitW * SplitH];
            //}             
        
                          
        }

        private void IDC_Device_Click(object sender, EventArgs e)
        {
            int result = Program.LIVESCAN_Init();
            bool splitInit = Program.FPSPLIT_Init(CDCW, CDCH,1);
            Console.Write("FPSPLIT_Init="+splitInit);

            switch (result)
            {
                case 1:
                    IDC_State.Text = "Open device Successfully";
                  

                    Program.LIVESCAN_SetBright(0, 128);
                    Program.LIVESCAN_SetContrast(0, 188); 
                    
                    Program.LIVESCAN_GetBright(0, out m_Bright);
                    Program.LIVESCAN_GetContrast(0, out m_Contrast);
                    Program.LIVESCAN_SetCaptWindow(0, 0, 0, 1600, 1500);

                    numBright.Value = m_Bright;
                    numContrast.Value = m_Contrast;

                    IDC_Capture.Enabled = true;
                    IDC_Stop.Enabled = true;
                   
                    break;
                case -4:
                    IDC_State.Text = "No find device";
                    MessageBox.Show("No find device, please try again");
                    break;
                default:
                    IDC_State.Text = "Unknown error";
                    MessageBox.Show("Unknown error");
                    break;
            }
        }

        private void IDC_Capture_Click(object sender, EventArgs e)
        {            
            //测试dll的Err是否调用成功
            //StringBuilder m_szErrInfo = new StringBuilder(1024);
            //Program.LIVESCAN_GetErrorInfo(-1,  m_szErrInfo);
            //Console.Write(m_szErrInfo);
      
            int result = Program.LIVESCAN_BeginCapture(0);
            if (result == 1)
            {
                timerCapture.Start();
            }
            else {
                StringBuilder m_szErrInfo = new StringBuilder(256);
                Program.LIVESCAN_GetErrorInfo(result, m_szErrInfo);
                Text_Status.Text = m_szErrInfo.ToString();
            }         
        }

        private void IDC_Stop_Click(object sender, EventArgs e)
        {
            timerCapture.Stop();
            Program.LIVESCAN_EndCapture(0);
            IDC_Device.Enabled = true;
            IDC_Capture.Enabled = true;
        }

        private void IDC_BTN_LIVESCAN_Close_Click(object sender, EventArgs e)
        {
            Program.LIVESCAN_Close();
        }

        private void IDCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Bitmap BytesToBmp(byte[] bmpBytes, Size imageSize)
        {
            ColorPalette pal;
            int w = imageSize.Width;
            int h = imageSize.Height;
            Bitmap b = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
            
            pal = b.Palette;
            for (int i = 0; i < 256; i++)
            {
                pal.Entries[i] = Color.FromArgb(i, i, i);
            }

            byte c = Convert.ToByte(255);

            Marshal.Copy(bmpBytes, 0, SourcePtr, w * h);
            b = new Bitmap(w, h, w, PixelFormat.Format8bppIndexed, SourcePtr);
            b.Palette = pal;
            b.SetResolution(500, 500);
            return b;
        }


        private void splitCapture()
        {
           
        }

        private void normalCapture()
        {
            Program.LIVESCAN_GetFPRawData(0, m_CutFrame);
            Bmpdata = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));
            IDC_Image.Image = resizeImage(Bmpdata, IDC_Image.Width, IDC_Image.Height);
        }

        private void timerCapture_Tick(object sender, EventArgs e)
        {
            Program.LIVESCAN_GetFPRawData(0, m_CutFrame);

      //      int DoSplitResult = Program.FPSPLIT_DoSplit(m_CutFrame, CDCW, CDCH, 1, SplitW, SplitH, ref FpNum, );
       //     Console.Write(" DoSplitResult=" + DoSplitResult);

            Bmpdata = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));
            IDC_Image.Image = resizeImage(Bmpdata, IDC_Image.Width, IDC_Image.Height);
            
            
           

      //      int z = Program.FPSPLIT_DoSplit(m_CutFrame, CDCW, CDCH, 1, SplitW, SplitH, out FpNum, ref fpSplit_info[0]);

       //     Console.Write("z=" + z);

          
           
          
                 

         //   DateTime beforDT = System.DateTime.Now;               
          //  int isf = Program.LIVESCAN_IsFinger(m_CutFrame, CDCW, CDCH);          
            //int isL = Program.LIVESCAN_IsLiving();       
           // if ((isf == 1) && (isL == 1))  
            //{        
           // IDC_Image.Refresh();
            //}
          //  DateTime afterDT = System.DateTime.Now;
           // TimeSpan ts = afterDT.Subtract(beforDT);
           // Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);  
        }

        private  Bitmap resizeImage(Bitmap picture,int width,int heigh)
        {
            Bitmap resizedPicture=new Bitmap(width,heigh);
            using(Graphics graphics=Graphics.FromImage(resizedPicture))
            {
                graphics.DrawImage(picture,0,0,width,heigh);
            }
            return resizedPicture;
        }
     
        private void IDB_SetBufferEmpty_Click(object sender, EventArgs e)
        {
           int ret = Program.LIVESCAN_SetBufferEmpty(ref m_CutFrame, CDCW*CDCH);
        }

        private void IDC_SetBright_Click(object sender, EventArgs e)
        {
            Program.LIVESCAN_SetBright(0, int.Parse(numBright.Value.ToString()));
        }

        private void IDC_SetContrast_Click(object sender, EventArgs e)
        {
            Program.LIVESCAN_SetContrast(0, int.Parse(numContrast.Value.ToString()));
        }

        private void IDC_Savebmp_Click(object sender, EventArgs e)
        {
            Program.LIVESCAN_EndCapture(0);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WSQ Files (*.wsq)|*.wsq|Windows BMP (*.bmp)|*.bmp|TIFF Files (*.tif)|*.tif|JPEG Files (*.jpg)|*.jpg|JPEG-2000 Part-1(*.jp2)|*.jp2|JPEG-2000 Code Stream (*.jpc)|*.jpc";
            sfd.FilterIndex = 1;
            sfd.Title = "请选择要保存的文件路径";

            string str;

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                string filePath = sfd.FileName;

                if (bIsSplit)
                {
                    if (FpNum > 0)
                    {
                        for (int i = 0; i < FpNum; i++)
                        {
                            str = i + ".bmp";
            //                Program.FPSPLIT_SaveToBmp(fpSplit_info[i].pOutBuf, SplitW, SplitH, str);
                        }
                    }
                    else
                    {
                        Text_Status.Text = "No Finger!";
                    }
                }
                else
                {
                    Bitmap FPBmpData;
                    int ret = Program.LIVESCAN_GetFPBmpData(0, m_BMPFrame);
                    if (ret == 1)
                    {
                        FPBmpData = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));
                        //FPBmpData.Save(System.IO.Directory.GetCurrentDirectory() + "\\Finger.bmp");

                        FPBmpData.Save(@System.IO.Directory.GetCurrentDirectory() + "\\Finger.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }           
            }
        }
        
        private void IDC_BTN_BeginCapture_Click(object sender, EventArgs e)
        {
            Program.LIVESCAN_BeginCapture(0);
        }

        private void IDC_BTN_GetFPRawData_Click(object sender, EventArgs e)
        {
            Program.LIVESCAN_BeginCapture(0);
            int ret = Program.LIVESCAN_GetFPRawData(0, m_CutFrame);
            Bitmap FPRawData;
            if (ret == 1)
            {
                FPRawData = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));
                FPRawData.Save(@System.IO.Directory.GetCurrentDirectory() + "\\FingerRaw.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }

        }

        private void IDC_Version_Click(object sender, EventArgs e)
        {
            int NoVersion;

            NoVersion = Program.LIVESCAN_GetVersion();

            double Vnum;
            Vnum = (NoVersion) / 100;

            MessageBox.Show("Version:" + Vnum.ToString("F2"));
        }

        private void IDC_Channel_Click(object sender, EventArgs e)
        {
            int ret = Program.LIVESCAN_GetChannelCount();
            if (ret >=0)
            {
                MessageBox.Show("Number of channel is " + ret);
            }
        }

        private void IDC_EndCapture_Click(object sender, EventArgs e)
        {
            int ret = Program.LIVESCAN_EndCapture(0);
            if (ret >= 0)
            {
                MessageBox.Show("End capture successfully!");
            }
        }

        private void IDC_Wsq_Save_Click(object sender, EventArgs e)
        {
            timerCapture.Stop();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WSQ Files (*.wsq)|*.wsq|Windows BMP (*.bmp)|*.bmp|TIFF Files (*.tif)|*.tif" +
                "|PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|Targa Files (*.tga)|*.tga|SGI Files (*.rgb)|*.rgb" +
                "|JPEG-2000 Part-1 (*.jp2)|*.jp2|JPEG-2000 Code Stream (*.jpc)|*.jpc";
        //    sfd.FilterIndex = 1;
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //you can use commented line of code bellow or you can use method from class WSQ_library_native_methods
            //_SetShowFilePropertiesDialog(1);
            WSQ_library_native_methods.SetShowFilePropertiesDialog(1);


            //b = new Bitmap(picture.Image);
            Program.LIVESCAN_BeginCapture(0);
            Program.LIVESCAN_GetFPRawData(0, m_CutFrame);

            Bitmap bmpdata = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));
            
            IntPtr bp;
            bp = bmpdata.GetHbitmap();

            //you can use commented line of code bellow or you can use method from class WSQ_library_native_methods
            //_SaveBMPToFile(bp, sfd.FileName, sfd.FilterIndex);
            WSQ_library_native_methods.SaveBMPToFile(bp, sfd.FileName, sfd.FilterIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            
            
            Program.LIVESCAN_BeginCapture(0);
            DateTime beforDT = System.DateTime.Now;

            int i = Program.LIVESCAN_GetFPRawData(0, m_CutFrame);
            //for (int a = 0; a < m_CutFrame.Length; a++)
            //{
            //    Console.Write(m_CutFrame[a]);
            //}
            Console.WriteLine("返回=" + i);

            Bmpdata = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));

            Bmpdata.Save(@System.IO.Directory.GetCurrentDirectory() + "\\FingerRaw.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Program.LIVESCAN_EndCapture(0);


            //  int isf = Program.LIVESCAN_IsFinger(m_CutFrame, CDCW, CDCH);


            //int isL = Program.LIVESCAN_IsLiving();


            // if ((isf == 1) && (isL == 1))  
            //{
            IDC_Image.Image = Bmpdata;
         //   IDC_Image.Refresh();

            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine("Stopwatch总共花费{0}ms.", ts2.TotalMilliseconds);


            //}
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);
           
        }

        private void Fprinter_Load(object sender, EventArgs e)
        {

        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
        //    IDC_Device.Enabled = true;
            timerCapture.Stop();


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存图像";
            sfd.FilterIndex = 1;

            sfd.Filter = "WSQ Files (*.wsq)|*.wsq|Windows BMP (*.bmp)|*.bmp|TIFF Files (*.tif)|*.tif" +
                   "|PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|Targa Files (*.tga)|*.tga|SGI Files (*.rgb)|*.rgb" +
                   "|JPEG-2000 Part-1 (*.jp2)|*.jp2|JPEG-2000 Code Stream (*.jpc)|*.jpc";

         if (sfd.ShowDialog() != DialogResult.OK)
         {
             return;
         }            
          
        }
        IntPtr infosIntptr;

        //拆分
        private void Button_Split_Click(object sender, EventArgs e)
        {
            int size = Marshal.SizeOf(typeof(FPSPLIT_INFO_));
            infosIntptr = Marshal.AllocHGlobal(size * 10);  

            Program.LIVESCAN_BeginCapture(0);

            Program.LIVESCAN_GetFPRawData(0, m_CutFrame);

            int DoSplitResult = Program.FPSPLIT_DoSplit(m_CutFrame, CDCW, CDCH, 1, SplitW, SplitH, ref FpNum, infosIntptr);
            Console.Write(" DoSplitResult=" + DoSplitResult);

            Bmpdata = BytesToBmp(m_CutFrame, new Size(CDCW, CDCH));
            IDC_Image.Image = resizeImage(Bmpdata, IDC_Image.Width, IDC_Image.Height);
        }

      
       
    }
}