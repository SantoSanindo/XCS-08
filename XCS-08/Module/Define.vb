Option Explicit On
Module Define
    'DefInt A-Z 

    'Declarations
    '
    'Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Long, ByVal LCType As Long, ByVal lpLCData As String, ByVal cchData As Long) As Long
    'Declare Function GetTimeFormat Lib "kernel32" Alias "GetTimeFormatA" (ByVal Locale As Long, ByVal dwFlags As Long, lpTime As SYSTEMTIME, ByVal lpFormat As String, ByVal lpTimeStr As String, ByVal cchTime As Long) As Long
    'Declare Function GetLocalTime Lib "kernel32" (lpSystemTime As SYSTEMTIME)
    'Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal FILENAME As String) As Integer
    'Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal AppName As String, ByVal KeyName As String, ByVal keydefault As String, ByVal ReturnString As String, ByVal NumBytes As Integer, ByVal FILENAME As String) As Integer
    'Declare Function GetProfileint Lib "kernel" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String) As Integer
    'Public Declare Function GetKeyboardState Lib "user32" (pbKeyState As Byte) As Long
    ''SYSTEMTIME
    Public DateTimeSys As SYSTEMTIME

    Public Create_new As Boolean
    Public TESTPROGRESS As Boolean

    'CONSTANT
    Public Const BIT0 = 1
    Public Const BIT1 = 2
    Public Const BIT2 = 4
    Public Const BIT3 = 8
    Public Const BIT4 = 16
    Public Const BIT5 = 32
    Public Const BIT6 = 64
    Public Const BIT7 = 128
    Public Const BIT8 = 256
    Public Const BIT9 = 512
    Public Const BIT10 = 1024
    Public Const BIT11 = 2048
    Public Const BIT12 = 4096
    Public Const BIT13 = 8192
    Public Const BIT14 = 16384
    Public Const BIT15 = 32768

    '------------------------------------
    ' Test bits
    'Public Const BITtest7 = &H80
    'Public Const BITtest6 = &H40
    'Public Const BITtest5 = &H20
    'Public Const BITtest4 = &H10
    'Public Const BITtest3 = &H8
    'Public Const BITtest2 = &H4
    'Public Const BITtest1 = &H2
    'Public Const BITtest0 = &H1

    '-------------------------------------
    Public Const Connected = 1
    Public Const Sendcomplete = 2
    Public Const ReceiveComplete = 3

    Public DataSended As Boolean, DataReceived As Boolean, Abord As Boolean, lpConnected As Boolean

    Public Structure SYSTEMTIME
        Dim wYear As Integer
        Dim wMonth As Integer
        Dim wDayOfWeek As Integer
        Dim wDay As Integer
        Dim wHour As Integer
        Dim wMinute As Integer
        Dim wSecond As Integer
        Dim wMilliseconds As Long
    End Structure


End Module
