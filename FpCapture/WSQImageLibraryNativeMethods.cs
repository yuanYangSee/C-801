using System;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FpCapture
{
    class WSQImageLibraryNativeMethods
    {

        IntPtr outODataStream = IntPtr.Zero, outCommentText = IntPtr.Zero;
        IntPtr outCompressBuffer = IntPtr.Zero;
        IntPtr bitmap_ptr = IntPtr.Zero;

        private UTF8Encoding utf8 = new UTF8Encoding();

        public WSQImageLibraryNativeMethods() { }


        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _RegisterWSQ();
        public void RegisterWSQ()
        {
            try
            {
                _RegisterWSQ();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RegisterWSQ Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _CreateBMPFromFile(byte[] lpszFileName);
        public IntPtr CreateBMPFromFile(String FileName)
        {

            if (FileName == null)
                throw new ArgumentNullException("FileName should be not null");
            if (FileName.Length == 0)
                throw new ArgumentException("Incorrect file name");
            try
            {
                bitmap_ptr = _CreateBMPFromFile(utf8.GetBytes(FileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CreateBMPFromFile Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bitmap_ptr;
        }

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _SaveBMPToFile(IntPtr hBitmap, byte[] filename,
            [MarshalAs(UnmanagedType.I4)] int filetype);
        public int SaveBMPToFile(IntPtr Bitmap, String FileName, int FileType)
        {
            int retVal = -1;
            if ((Bitmap == (IntPtr)null) || (FileName == null))
                throw new ArgumentNullException("Bitmap and FileName should be not null");
            if (FileName.Length == 0)
                throw new ArgumentException("Incorrect file name");
            try
            {
                retVal = _SaveBMPToFile(Bitmap, utf8.GetBytes(FileName), FileType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveBMPToFile Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }


        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _CreateBMPFromWSQByteArray(
            [In] byte[] input_data_stream,
            [In] [MarshalAs(UnmanagedType.I4)] int input_stream_length);
        public IntPtr CreateBMPFromWSQByteArray(
            [In] byte[] input_data_stream,
            [In] Int32 input_stream_length)
        {

            try
            {
                bitmap_ptr = _CreateBMPFromWSQByteArray(input_data_stream, input_stream_length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CreateBMPFromWSQByteArray Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bitmap_ptr;
        }


        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _SaveWSQByteArrayToImageFile(
            [In] byte[] input_data_stream,
            [In] [MarshalAs(UnmanagedType.I4)] int input_stream_length,
            byte[] filename,
            [MarshalAs(UnmanagedType.I4)] int filetype);
        public int SaveWSQByteArrayToImageFile(
            [In] byte[] input_data_stream,
            [In] Int32 input_stream_length,
            String FileName,
            int FileType)
        {
            int retVal = -1;
            if (FileName == null)
                throw new ArgumentNullException("FileName should be not null");
            if (FileName.Length == 0)
                throw new ArgumentException("Incorrect file name");

            try
            {
                retVal = _SaveWSQByteArrayToImageFile(input_data_stream, input_stream_length,
                    utf8.GetBytes(FileName), FileType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveWSQByteArrayToImageFile Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }





        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _SetShowFilePropertiesDialog(
               [MarshalAs(UnmanagedType.I4)] int file_properties_dialog);
        public void SetShowFilePropertiesDialog(int file_properties_dialog)
        {
            try
            {
                _SetShowFilePropertiesDialog(file_properties_dialog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetShowFilePropertiesDialog Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _ShowFileConverter();
        public void ShowFileConverter()
        {
            try
            {
                _ShowFileConverter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ShowFileConverter Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _WSQ_encode_stream(
            [In] byte[] inputBuffer,
            [In] [MarshalAs(UnmanagedType.I4)] int width,
            [In] [MarshalAs(UnmanagedType.I4)] int height,
            [In] [MarshalAs(UnmanagedType.R8)] double bitrate,
            [In] [MarshalAs(UnmanagedType.I4)] int ppi,
            [In] byte[] commentText,
            out IntPtr compressBuffer,
            [MarshalAs(UnmanagedType.I4)] out int outputStreamLength);
        public int WSQ_encode_stream(
            byte[] inputBuffer,
            int width,
            int height,
            double bitrate,
            int ppi,
            String commentText,
            out byte[] compressBuffer,
            out int outputStreamLength)
        {
            int retVal = -1;
            compressBuffer = null;
            outputStreamLength = 0;
            try
            {
                _WSQ_encode_stream(inputBuffer, width, height,
                    bitrate, ppi, utf8.GetBytes(commentText),
                    out outCompressBuffer, out outputStreamLength);
                if (outputStreamLength == 0)
                    throw new ArgumentException("outputStreamLength == 0");
                compressBuffer = new byte[outputStreamLength];
                Marshal.Copy(outCompressBuffer, compressBuffer, 0, outputStreamLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WsqDecodeStream Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }



        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _WSQ_decode_stream(
            [In] byte[] input_data_stream,
            [In] [MarshalAs(UnmanagedType.I4)] int input_stream_length,
            out IntPtr output_data_stream,
            [MarshalAs(UnmanagedType.I4)] out int width,
            [MarshalAs(UnmanagedType.I4)] out int height,
            [MarshalAs(UnmanagedType.I4)] out int ppi,
            out IntPtr comment_text);
        public int WSQ_decode_stream(
           [In] byte[] input_data_stream,
           [In] Int32 input_stream_length,
           out byte[] output_data_stream,
           out Int32 width,
           out Int32 height,
           out Int32 ppi,
           out String comment_text)
        {
            int retVal = -1;
            output_data_stream = new byte[1];
            width = height = ppi = 0;
            comment_text = "";
            try
            {
                _WSQ_decode_stream(input_data_stream, input_stream_length,
                    out outODataStream, out width, out height,
                    out ppi, out outCommentText);
                comment_text = Marshal.PtrToStringAnsi(outCommentText);
                int lenght = width * height;
                output_data_stream = new byte[lenght];
                Marshal.Copy(outODataStream, output_data_stream, 0, lenght);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WsqDecodeStream Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }



        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _ConvertHBITMAPtoGrayScale256(IntPtr hBitmap);
        public IntPtr ConvertHBITMAPtoGrayScale256(IntPtr Bitmap)
        {
            try
            {
                bitmap_ptr = _ConvertHBITMAPtoGrayScale256(Bitmap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ConvertHBITMAPtoGrayScale256 Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bitmap_ptr;
        }


        [DllImport("WSQ_library.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _SaveHBITMAPtoFileAsGrayScale256BMP(IntPtr hBitmap, byte[] filename);
        public int SaveHBITMAPtoFileAsGrayScale256BMP(IntPtr Bitmap, String FileName)
        {
            int retVal = -1;
            if ((Bitmap == (IntPtr)null) || (FileName == null))
                throw new ArgumentNullException("Bitmap and FileName should be not null");
            if (FileName.Length == 0)
                throw new ArgumentException("Incorrect file name");
            try
            {
                retVal = _SaveHBITMAPtoFileAsGrayScale256BMP(Bitmap, utf8.GetBytes(FileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveHBITMAPtoFileAsGrayScale256BMP Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }






    }
}
