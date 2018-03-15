#define WSQ_IMPORT __declspec( dllimport )



#if defined(__cplusplus)
extern "C" {
#endif


extern
char* WSQ_IMPORT GenerateSerialNumber();

extern
int WSQ_IMPORT UnlockWSQLibrary(char* authorizationcode);


extern
int WSQ_IMPORT WSQ_decode_stream(unsigned char *input_data_stream, const int input_stream_length, unsigned char **output_data_stream, int *width, int *height, int *ppi, unsigned char **comment_text);


extern
int WSQ_IMPORT WSQ_encode_stream(unsigned char *input_data_stream, const int width, const int height, const double bitrate,
				   const int ppi, char *comment_text, unsigned char **output_data_stream, int *output_stream_length);



/* saves the contents of an HBITMAP to a file.  The extension of the file name
// determines the file type.  returns 1 if successfull, 0 otherwise */
extern
WSQ_IMPORT SaveBMPToFile( HBITMAP hBitmap,      /* bitmap to be saved */
                                 const char *filename, int filetype); /* name of output file */


/* Creates an HBITMAP from an image file.  The extension of the file name
// determines the file type.  returns an HBITMAP if successfull, NULL
// otherwise */
extern
HBITMAP WSQ_IMPORT CreateBMPFromFile( const char *filename);


// Creates an HBITMAP from WSQ compressed byte array.
// Returns an HBITMAP if successfull, NULL otherwise 
extern
HBITMAP WSQ_EXPORT CreateBMPFromWSQByteArray(unsigned char *input_wsq_byte_array, int size_of_input_wsq_byte_array);


// Saves WSQ compressed byte array to an image file.
// Returns 1 if successfull, 0 otherwise 
extern
int WSQ_EXPORT SaveWSQByteArrayToImageFile(unsigned char *input_wsq_byte_array, int size_of_input_wsq_byte_array, const char *filename, int filetype);




extern
int WSQ_IMPORT RegisterWSQ();



extern
void WSQ_IMPORT WriteWSQ_bitrate(double bitrate);

extern
double WSQ_IMPORT ReadWSQ_bitrate();

extern
void WSQ_IMPORT WriteWSQ_ppi(int ppi);

extern
int WSQ_IMPORT ReadWSQ_ppi();

extern
void WSQ_IMPORT WriteWSQ_comment(char *comment);

extern
char* WSQ_IMPORT ReadWSQ_comment();



extern
void WSQ_IMPORT WriteTIFFcompression(int tiff_compression);

extern
void WSQ_IMPORT WriteTIFFpredictor(int tiff_predictor);

extern
void WSQ_IMPORT SetShowFilePropertiesDialog(int file_properties_dialog);


extern
void WSQ_IMPORT ShowFileConverter();


extern
HBITMAP WSQ_EXPORT ConvertHBITMAPtoGrayScale256(HBITMAP hBitmap);

extern
int WSQ_EXPORT SaveHBITMAPtoFileAsGrayScale256BMP(HBITMAP hBitmap, const char *filename);




#if defined(__cplusplus)
 }
#endif

