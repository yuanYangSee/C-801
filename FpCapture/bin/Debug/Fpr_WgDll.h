#ifndef		_Fpr_WgDll_H_
#define		_Fpr_WgDll_H_	


#define LIVESCAN_SUCCESS 1

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


int		__stdcall	LIVESCAN_Init();

int		__stdcall	LIVESCAN_Close();

int		__stdcall	LIVESCAN_GetChannelCount();

int		__stdcall	LIVESCAN_SetBright(int nChannel, int nBright);

int		__stdcall	LIVESCAN_SetContrast(	int nChannel, int nContrast );

int __stdcall LIVESCAN_GetBright(int nChannel,int *pnBright);

int		__stdcall	LIVESCAN_GetContrast(	int nChannel, int *pnContrast );

int		__stdcall	LIVESCAN_GetMaxImageSize(	int nChannel, int *pnWidth, int *pnHeight  );


int		__stdcall	LIVESCAN_GetCaptWindow(	int nChannel, int *pnOriginX, int *pnOriginY, int *pnWidth, int *pnHeight);

int		__stdcall	LIVESCAN_SetCaptWindow(	int nChannel, int nOriginX, int nOriginY  , int nWidth, int nHeight  );


int		__stdcall	LIVESCAN_Setup();

int		__stdcall	LIVESCAN_BeginCapture(	int nChannel );

int		__stdcall	LIVESCAN_GetFPRawData(int nChannel,unsigned char *pRawData);

int		__stdcall	LIVESCAN_GetFPBmpData(int nChannel, unsigned char *pBmpData);

int		__stdcall	LIVESCAN_EndCapture(int nChannel );

int		__stdcall	LIVESCAN_IsSupportSetup();

int		__stdcall	LIVESCAN_GetVersion();

int		__stdcall	LIVESCAN_GetDesc(char pszDesc[1024]);

int		__stdcall	LIVESCAN_GetErrorInfo(int nErrorNo, char pszErrorInfo[256]);

int		__stdcall	LIVESCAN_SetBrightReset(int const nChannel,int *const  pnBright);

int		__stdcall	LIVESCAN_EndCapture(int const nChannel);

int		__stdcall	LIVESCAN_SetGamma(int nChannel, int nGamma);
int		__stdcall	LIVESCAN_SetBufferEmpty(unsigned char *pImageData, long imageLength);
 
int		__stdcall	LIVESCAN_SetID(int nChannel,unsigned char *IDData);


#endif