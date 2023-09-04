Option Explicit On
Module Declaration

    Public Unitmaterial As Rackconfig
    Public TotalunitaryPassCount As Integer 'Count the nos of output from the stn that is tested Pass
    Public UnitaryBoardCount As Integer 'Count nos of board for the particular reference
    Public UnitaryPartCount As Integer 'Count nos of part for the particular reference
    Public UnitaryDateCode As String 'Product Date code
    Public UnitaryMaterial(50) As String 'Variable holding material info for the particular reference
    Public PSNFileInfo As PSNText

    Public Parameter As ControlSpec
    Public Login As Boolean
    Public LoadWOfrRFID As JobOrder
    Public PCBA As PCBAConf

    Public Structure PCBAConf
        Dim pcbanos As String
        Dim CT() As String
    End Structure

    Public Structure ControlSpec
        Dim UnitTagNos As String
        Dim UnitPartNos As String
        Dim UnitModel As String
        Dim UnitType As String
        Dim UnitFunction As String
        Dim UnitTension As String
        Dim UnitContact1_WO_Trig As String
        Dim UnitContact2_WO_Trig As String
        Dim UnitContact3_WO_Trig As String
        Dim UnitContact4_WO_Trig As String
        Dim UnitContact5_WO_Trig As String
        Dim UnitContact6_WO_Trig As String
        Dim UnitContact_WO_Trig As Long
        Dim UnitContact1_W_Key As String
        Dim UnitContact2_W_Key As String
        Dim UnitContact3_W_Key As String
        Dim UnitContact4_W_Key As String
        Dim UnitContact5_W_Key As String
        Dim UnitContact6_W_Key As String
        Dim UnitContact_W_Key As Long

        Dim UnitContact1_W_Key_Ten As String
        Dim UnitContact2_W_Key_Ten As String
        Dim UnitContact3_W_Key_Ten As String
        Dim UnitContact4_W_Key_Ten As String
        Dim UnitContact5_W_Key_Ten As String
        Dim UnitContact6_W_Key_Ten As String
        Dim UnitContact_W_Key_Ten As Long
        Dim UnitLabelTemplate As String
        Dim UnitLabelPhoto As String
        Dim UnitSycUL As Double
        Dim UnitSycLL As Double
    End Structure

    Public Structure JobOrder
        Dim JobNos As String
        Dim JobModelName As String
        Dim JobQTy As Integer
        Dim JobArticle As String
        Dim JobModelFW As String
        Dim JobModelAssy As String
        Dim JobInterNos As String
        Dim JobRFIDTag As String
        Dim JobUnitaryCount As Integer
        Dim JobItemCount As Integer
        Dim JobModelMaterial() As String
        Dim JobPrimaryPCBA As String
        Dim JobContact1 As String
        Dim JobContact2 As String
        Dim JobContact3 As String
        Dim JobFunctionType As String
        Dim JobProductMaterial As String
    End Structure

    Public Structure Rackconfig
        Dim PartPLCWord() As Long
        Dim PartNos() As String
    End Structure

    Public Structure PSNText
        Dim ModelName As String
        Dim DateCreated As String
        Dim DateCompleted As String
        Dim OperatorID As String
        Dim WONos As String
        Dim MainPCBA As String
        Dim SecondaryPCBA As String
        Dim ElectroMagnet As String
        Dim PSN As String
        Dim ScrewStnCheckIn As String
        Dim ScrewStnCheckOut As String
        Dim ScrewStnStatus As String
        Dim FTCheckIn As String
        Dim FTCheckOut As String
        Dim FTStatus As String
        Dim Stn5CheckIn As String
        Dim Stn5CheckOut As String
        Dim Stn5Status As String
        Dim PackagingCheckIn As String
        Dim PackagingCheckOut As String
        Dim PackagingStatus As String
        Dim DebugStatus As String
        Dim DebugComment As String
        Dim DebugTechnican As String
        Dim RepairDate As String
    End Structure


End Module
