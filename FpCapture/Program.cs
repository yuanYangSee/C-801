using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace FpCapture
{

    



    public class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Fprinter());
        }


       

       
        #region　extern fun
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_Init();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_Close();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetChannelCount();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_SetBright(int nChannel, int nBright);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_SetContrast(int nChannel, int nContrast);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetBright(int nChannel, out int pnBright);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetContrast(int nChannel, out int pnContrast);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetMaxImageSize(int nChannel, out int pnWidth, out int pnHeight);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetCaptWindow(int nChannel, out int pnOriginX, out int pnOriginY, out int pnWidth, out int pnHeight);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_SetCaptWindow(int nChannel, int nOriginX, int nOriginY, int nWidth, int nHeight);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_Setup();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_BeginCapture(int nChannel);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetFPRawData(int nChannel, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pRawData);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetFPBmpData(int nChannel, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pBmpData);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_EndCapture(int nChannel);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_IsSupportSetup();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetVersion();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetDesc( string pszDesc);// char pszDesc[1024]
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_GetErrorInfo(int nErrorNo, StringBuilder pszErrorInfo); // char pszErrorInfo[256]
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_SetBufferEmpty(ref byte[] pImageData, long imageLength);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_IsFinger([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pRawData, int nWidth, int nHeight);
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_XXXX();
        [DllImport("ID_FprCap.dll")]
        public static extern int LIVESCAN_IsLiving();

        // To call functions from WSQ_library.dll
        // you can use the methods from wrapper class WSQImageLibraryNativeMethods
        // or you can use function prototypes provided below


        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr _CreateBMPFromFile(String lpszFileName);

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void _SaveBMPToFile(IntPtr hBitmap, String filename, Int32 filetype);

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void _SetShowFilePropertiesDialog(Int32 file_properties_dialog);

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void _ShowFileConverter();

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr _ConvertHBITMAPtoGrayScale256(IntPtr hBitmap);

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void _SaveHBITMAPtoFileAsGrayScale256BMP(IntPtr hBitmap, String filename);

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr _GenerateSerialNumber();

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 _UnlockWSQLibrary(String lpszAuthorizationCode);


       
        //加载split.dll
        [DllImport("FpSplit.dll")]
        public static extern bool FPSPLIT_Init(int nImgW, int nImgH, int nPreview);
         
        [DllImport("FpSplit.dll")]
         public static extern void  FPSPLIT_UnInit();

        [DllImport("FpSplit.dll")]  
    //    public static extern int  FPSPLIT_DoSplit([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pBmpData, int nImgW, int nImgH,
    //        int nPreview,int nSplitW, int nSplitH, out int pnFpNum,  ref FPSPLIT_INFO pInfo);

        public  static extern int FPSPLIT_DoSplit([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pBmpData,
            int nImgW, int nImgH, int nPreview, int nSplitW, int nSplitH,
            ref int pnFpNum, IntPtr infosIntPtr);

        [DllImport("FpSplit.dll")]
        public static extern int FPSPLIT_SaveToBmp([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pBmpData, int nImgW, int nImgH, string pFile);


        #endregion
    }
}