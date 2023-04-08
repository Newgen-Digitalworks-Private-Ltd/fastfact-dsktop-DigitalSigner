Imports System.IO
Imports System.IO.Stream
Imports System.Net

Module utility
    'abhay
    Public strSelectedPdfFolderPath As String
    'abhay
    'API Functions
    '<DllImport("win32dll.dll")> Public Function DogRead(ByVal DogBytes As Int16, ByVal DogAddr As Integer, ByVal DogData As String) As Integer
    'End Function

    'Declare Function DogRead Lib "Win32dll.dll" (ByVal DogBytes As Long, ByVal DogAddr As Long, ByVal DogData As String) As Long
    '    Declare Function DogRead Lib "Win32dll" (ByVal DogBytes As Integer, ByVal DogAddr As Integer, ByVal DogData As String) As Integer

    '    Public Declare Function GetDesktopWindow Lib "user32" () As Long
    '    Public Declare Function ShellExecute Lib "shell32.dll" Alias _
    '    "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation _
    '    As String, ByVal lpFile As String, ByVal lpParameters _
    '    As String, ByVal lpDirectory As String, _
    '    ByVal nShowCmd As Long) As Long

    '    'ra 1.3.109
    '    Public Declare Function GetSystemDefaultLCID Lib "kernel32" () As Int32
    '    Public Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Integer, ByVal LCType As Integer, ByVal lpLCData As String) As Boolean
    '    'ra1.3.109


    '    'Global Declaration   
    '    Public conTdsPac As SqlClient.SqlConnection
    '    Public conBaseData As SqlClient.SqlConnection
    '    Public resMessage As Resources.ResourceManager
    '    Public StrUserId As String
    '    Public StrCocd As String
    '    Public strCoName As String
    '    Public blnModify As Boolean
    '    Public blnAuditTrail As Boolean
    '    Public StrFinYear As String
    '    Public StrDbName As String
    '    Public StrSvrName As String
    '    Public StrAuthentication As String
    '    Public StrSQLUserId As String
    '    Public StrSQLPwd As String
    '    Public blnCreate As Boolean
    '    Public dtOpDt, dtClDt As Date
    '    Public strDeductorType, strDeductorStatus As String
    '    Public intYearForm, intYearTo As Integer
    '    Public strSearchValue As String
    '    Public strSearchOutputType As String = "Code"
    '    Public blnLargeData As Boolean = False
    '    Public str3DType As String
    '    'For Transaction use
    '    Public strDefaultDate As String
    '    Public strGrossingUp As String
    '    Public strBookEntry As String
    '    Public strLocalIpAddress As String
    '    Public blnPrintCoverLetter As Boolean
    '    Public strEnqType As String
    '    Public blnCanModify As Boolean = True ' user right option
    '    Public blnCanDelete As Boolean = True ' ""
    '    Public blnCanAdd As Boolean = True    ' ""
    '    Public blnCanPrint As Boolean = True  ' ""
    '    Public objPublicKeyGenerator As clsEncrypt.PublicKeyGenerator
    '    Public objMyKeyPair As clsEncrypt.KeyPair
    '    Public objCryptographyFunctions As clsEncrypt.CryptographyFunctions
    '    Public objMyKeyRing As New clsEncrypt.KeyRing
    '    Public strLevelID As String
    '    Public drTrans As SqlDataReader
    '    Public drChallan As SqlDataReader
    '    Public DemoVersion As Boolean
    '    Public intSearchRate As Integer
    '    'ra 1.3.109
    '    Public blnChkOpenDb As Boolean
    '    Public strSearchCaption As String
    '    Public blnconnected As Boolean
    '    'ra 1.3.109

    '    Public intTotalRecordForPan As Long
    '    Public intTotalWrongPan As Long
    '    Public tsPanFile As System.IO.StreamWriter
    '    Public strPanFile As String
    '    'uj
    '    Public chlnNo As String
    '    Public strParent As String
    Public strPrivate As String = "<RSAKeyValue><Modulus>2b7LPLGvn+Gj7DBxSBi1pist5MLC5yb8Fo3Aly5fxDuvu2APFiCi4VLsBpWWKZC3ZAGD3JZ/0OLXyF6r2e+oDmxIBTS3ZlEYPqTZXEudoZRw5V5kQg0Uip+vXP65ztT9L9zKSVjf51gwsOUb8QpOJERhlgRYrgqBwfgpZyGhjHc=</Modulus><Exponent>AQAB</Exponent><P>/YHgY7dUragkw0SB5uXPCAxyr878lQXjP4EfrEeQF+8G95ptF2w6HIs06nJSSqiFE4IyEBuQycHTBK+1E5YGyQ==</P><Q>2+Ll3EMjqQrJD2ZTOH5lT7dTZEL6Op7NGQVhfY4+rq91WYwm1J8WHKS3rV7q8rdFC6p2HDGYmN/bTq6xB4pZPw==</Q><DP>hXiA9N9MZRX3LRv/rNrn8tvi8i9viuKLsB7C10jiU8eUin6y2zcvLWIZnSpNq2MolYnh49svkxpKiNgd5U8DCQ==</DP><DQ>mw4HVSkrDlsCqQ9ZA+9tdacq8PqiBZBRxKEcvDMAVKJ5t+mywCBmsVAeDe1u9DT0RWOw4fS/TJ4ewf9B6rVOdQ==</DQ><InverseQ>xTa1Xu+oS22WggRGgTIDCY5DpzjaKNghpyEwwHiqHsO/dGw04pQ7e+6JHXdR5BYJ+mo/kV7D+nk4r7KfeSzyMg==</InverseQ><D>awfDssPMhhRNlQ2CwWOT9mgHGQk68JBTHWr0HdvnqveDu+DNyZylM4ilB9+Dfk7qNjggbs9zaGP4mT8fzfJlcjjJhuqZ64hHQODvifYNDErk9hp8NQuv7WVJCjWtFPH7Ttn20Hj8ToQoxlUPwS2cg6cCS18E2mICXOWF+60M1aE=</D></RSAKeyValue>"
    Public strPublic As String = "<RSAKeyValue><Modulus>2b7LPLGvn+Gj7DBxSBi1pist5MLC5yb8Fo3Aly5fxDuvu2APFiCi4VLsBpWWKZC3ZAGD3JZ/0OLXyF6r2e+oDmxIBTS3ZlEYPqTZXEudoZRw5V5kQg0Uip+vXP65ztT9L9zKSVjf51gwsOUb8QpOJERhlgRYrgqBwfgpZyGhjHc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
    '    'Ver 2.0.3-Cyn
    '    Public strLtrType As String
    '    'ver 2.3.1-1081 start
    '    Public ResetChallan As Boolean
    '    'ver 2.3.1-1081 end
    '    'Ver 2.3.6-E26 Start
    '    Public blnSplQuery As Boolean
    '    Public strSplQuery As String
    '    'Ver 2.3.6-E26 End
    '    'Ver 2.3.8-Priority 1 Start
    '    Public blnSinglePartyMultiTrans As Boolean
    '    'Ver 2.3.8-Priority 1 Start

    '    'Ver 2.3.8-1719 Start
    '    Public blnSinglePartyMultiTransAll As Boolean
    '    'Ver 2.3.8-1719 End
    '    'Ver 2.4.0-AXIS-Bank Start
    '    Public blnPrnRestrict As Boolean
    '    'Ver 2.4.0-AXIS-Bank end
    '    'Ver 2.4.0-E62 Start
    '    Const PagePass As String = "B10sai"
    '    Public TANLicence As Boolean
    '    'Ver 2.4.0-E62 End

    '    Public Function ComboFill(ByVal cboCombo As ComboBox, ByVal strField As String, ByVal drName As SqlClient.SqlDataReader, Optional ByVal blnClearCbo As Boolean = True)
    '        'This is generic function used to fill any combo box using dataReader
    '        If blnClearCbo = True Then cboCombo.Items.Clear() 'This will clear earlier contents of combobox if any
    '        While drName.Read      'Loop to fill combobox
    '            cboCombo.Items.Add(drName(strField))
    '        End While
    '        drName.Close()
    '        cboCombo.SelectedIndex = -1
    '    End Function
    '    Public Function ComboFill(ByVal cboCombo As ComboBox, ByVal strField As String, ByVal strSelect As String, Optional ByVal blnClearCbo As Boolean = True, Optional ByVal strDefault As String = "NoVal")
    '        Dim cmd As New SqlClient.SqlCommand(strSelect, conTdsPac)
    '        Dim drName As SqlClient.SqlDataReader = cmd.ExecuteReader
    '        'This is generic function used to fill any combo box using dataReader
    '        If blnClearCbo = True Then cboCombo.Items.Clear() 'This will clear earlier contents of combobox if any
    '        If strDefault <> "NoVal" Then cboCombo.Items.Add(strDefault)
    '        While drName.Read      'Loop to fill combobox
    '            cboCombo.Items.Add(drName(strField))
    '        End While
    '        drName.Close()
    '        cmd.Dispose()
    '        If strDefault <> "NoVal" Then
    '            cboCombo.SelectedIndex = 0
    '        Else
    '            cboCombo.SelectedIndex = -1
    '        End If

    '    End Function
    '    Public Sub FillQtr(ByVal cboCombo As ComboBox)
    '        cboCombo.Items.Clear()
    '        cboCombo.Items.Add("Q1")
    '        cboCombo.Items.Add("Q2")
    '        cboCombo.Items.Add("Q3")
    '        cboCombo.Items.Add("Q4")
    '    End Sub
    '    Public Function QuarterEndDate(ByVal mQt As String) As Date
    '        Select Case mQt
    '            Case "Q1"
    '                QuarterEndDate = "30/06/" & Year(dtOpDt)
    '            Case "Q2"
    '                QuarterEndDate = "30/09/" & Year(dtOpDt)
    '            Case "Q3"
    '                QuarterEndDate = "31/12/" & Year(dtOpDt)
    '            Case "Q4"
    '                QuarterEndDate = "31/03/" & Year(dtClDt)
    '        End Select
    '    End Function
    '    Public Function QuarterFromDate(ByVal mQt As String) As Date
    '        Select Case mQt
    '            Case "Q1"
    '                QuarterFromDate = "01/04/" & Year(dtOpDt)
    '            Case "Q2"
    '                QuarterFromDate = "01/07/" & Year(dtOpDt)
    '            Case "Q3"
    '                QuarterFromDate = "01/10/" & Year(dtOpDt)
    '            Case "Q4"
    '                QuarterFromDate = "01/01/" & Year(dtClDt)
    '        End Select
    '    End Function
    '    Public Sub IniSettings(ByVal frm As System.Windows.Forms.Panel, Optional ByVal blnReadonly As Boolean = True, Optional ByVal blnEnable As Boolean = False)
    '        Dim mCtrl As System.Windows.Forms.Control
    '        Dim mCol As System.Drawing.Color
    '        Dim mCtrlTxt As System.Windows.Forms.TextBox
    '        Dim mCtrlNum As Tdspac.NumTextBox
    '        Dim mCtrlMsk As Tdspac.MskDate
    '        Dim mCtrlCode As Tdspac.CodeTextbox

    '        For Each mCtrl In frm.Controls
    '            If TypeOf (mCtrl) Is TextBox Then
    '                mCtrlTxt = mCtrl
    '                mCol = mCtrlTxt.BackColor
    '                If mCol.ToString <> System.Drawing.SystemColors.Info.ToString Then
    '                    mCtrlTxt.ReadOnly = blnReadonly
    '                Else
    '                    mCtrlTxt.TabStop = False
    '                End If
    '            ElseIf TypeOf (mCtrl) Is NumTextBox Then
    '                mCtrlNum = mCtrl
    '                mCol = mCtrlNum.BackColor
    '                If mCol.ToString <> System.Drawing.SystemColors.Info.ToString Then
    '                    mCtrlNum.ReadOnly = blnReadonly
    '                Else
    '                    mCtrlNum.TabStop = False
    '                End If
    '            ElseIf TypeOf (mCtrl) Is CodeTextbox Then
    '                mCtrlCode = mCtrl
    '                mCol = mCtrlCode.BackColor
    '                If mCol.ToString <> System.Drawing.SystemColors.Info.ToString Then
    '                    mCtrlCode.ReadOnly = blnReadonly
    '                Else
    '                    mCtrlCode.ReadOnly = True
    '                    mCtrlCode.TabStop = False
    '                End If

    '            ElseIf TypeOf (mCtrl) Is MskDate Then
    '                mCtrlMsk = mCtrl
    '                mCol = mCtrlMsk.BackColor
    '                If mCol.ToString <> System.Drawing.SystemColors.Info.ToString Then
    '                    mCtrlMsk.ReadOnly = blnReadonly
    '                Else
    '                    mCtrlMsk.TabStop = False
    '                    mCtrlMsk.ReadOnly = True
    '                End If
    '            ElseIf TypeOf (mCtrl) Is ComboBox Then
    '                mCol = mCtrl.BackColor
    '                If mCol.ToString <> System.Drawing.SystemColors.Info.ToString Then
    '                    mCtrl.Enabled = blnEnable
    '                Else
    '                    mCtrl.Enabled = False
    '                End If
    '            End If
    '        Next
    '    End Sub
    '    Public Function ValidPAN(ByVal strPan As String, Optional ByVal blnFormat As Boolean = True) As String
    '        Dim strValidChr As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    '        Dim Str4thChr As String = "ABCFGHJLPT"
    '        Dim strValidNum As String = "1234567890"
    '        Dim AryPan() As Char = Nothing
    '        'Returns "VALID" or "V008" for other than 4 th chr validation fails
    '        'Returns "V009" for 4th character valiation fails
    '        'PAN validations - first 5 & last char must have alphabets 
    '        ' remaining should contain numeric
    '        If strPan = Nothing Then
    '            Return "INVALID"
    '        ElseIf strPan.Length <> 10 Then
    '            If blnFormat = False Then
    '                Return "INVALID"
    '            Else
    '                Return "V008"
    '            End If

    '        ElseIf UCase(strPan) = "PANAPPLIED" Or UCase(strPan) = "PANNOTAVBL" Or UCase(strPan) = "PANINVALID" Then
    '            If blnFormat = False Then
    '                Return "INVALID"
    '            Else
    '                Return "VALID"
    '            End If

    '        Else
    '            AryPan = strPan.ToCharArray
    '            If InStr(strValidChr, AryPan(0).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryPan(1).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryPan(2).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryPan(3).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryPan(4).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryPan(9).ToString, CompareMethod.Text) = 0 Then
    '                If blnFormat = False Then
    '                    Return "INVALID"
    '                Else
    '                    Return "V008"
    '                End If
    '            End If
    '            If InStr(strValidNum, AryPan(5).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryPan(6).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryPan(7).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryPan(8).ToString, CompareMethod.Text) = 0 Then
    '                If blnFormat = False Then
    '                    Return "INVALID"
    '                Else
    '                    Return "V008"
    '                End If
    '            End If
    '            If InStr(Str4thChr, AryPan(3).ToString, CompareMethod.Text) = 0 Then
    '                If blnFormat = False Then
    '                    Return "INVALID"
    '                Else
    '                    Return "V009"
    '                End If
    '            End If
    '            Return "VALID"
    '        End If
    '    End Function
    '    Public Function IsEmpty(ByVal ctlName As Control, ByVal strValue As String, ByVal strMsg As String, ByVal blnFocus As Boolean) As Boolean
    '        'To check whether the control is empty  
    '        'For eg text incase of textbox or selectedItem in case of combobox
    '        If strValue = "" Or strValue = "//" Then
    '            MsgBox(strMsg, MsgBoxStyle.Information)
    '            If blnFocus = True Then
    '                ctlName.Focus()
    '            End If
    '            Return True
    '        End If
    '        Return False
    '    End Function
    '    Public Function NumCheck(ByVal chrValue As Char) As Boolean
    '        'This function will check whether input data is numeric 
    '        Dim intVal As Integer
    '        intVal = Asc(chrValue) 'This will return ascii value of chrValue
    '        If intVal = 8 Or intVal = 46 Or (intVal > 47 And intVal < 58) Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    End Function
    '    Public Function RetrieveData(ByVal strField As Object, Optional ByVal strDefaultValue As String = "Null")
    '        'This function will check whether retrieved data is null
    '        If IsDBNull(strField) Then
    '            If strDefaultValue <> "Null" Then
    '                Return strDefaultValue
    '            End If
    '        Else
    '            Return strField
    '        End If
    '    End Function
    '    Public Function LabelFill(ByVal strTblName As String, ByVal strCodeField As String, ByVal strNameField As String, ByVal strCodeValue As String) As String
    '        Try
    '            Dim StrTCmd As String
    '            Dim dsTCmd As SqlClient.SqlCommand
    '            Dim drName As SqlClient.SqlDataReader
    '            StrTCmd = "select " & strNameField & " from " & strTblName & " where " & strCodeField & "='" & strCodeValue & "'"
    '            dsTCmd = New SqlClient.SqlCommand(StrTCmd, conTdsPac)
    '            dsTCmd.CommandType = CommandType.Text
    '            dsTCmd.CommandTimeout = 0
    '            drName = dsTCmd.ExecuteReader()
    '            If drName.HasRows Then
    '                drName.Read()
    '                StrTCmd = drName.Item(0)
    '                If drName.IsClosed = False Then drName.Close()
    '                Return StrTCmd
    '            Else
    '                If drName.IsClosed = False Then drName.Close()
    '                Return ""
    '            End If
    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Function
    '    Public Sub AddToDataset(ByVal ds As DataSet, ByVal strQry As String)
    '        Try
    '            Dim strName() As String = Nothing
    '            Dim strValue() As String = Nothing
    '            Dim strNameString As String
    '            Dim strValueString As String
    '            Dim tableName As String
    '            Dim position1, position2 As Integer
    '            Dim i As Integer
    '            position1 = InStr(strQry, "(")
    '            position2 = InStr(strQry, ")")

    '            tableName = Mid(strQry, 13, InStr(strQry, "(") - 14) 'table name
    '            strNameString = Mid(strQry, position1 + 1, position2 - position1 - 1) 'fields name
    '            strName = strNameString.Split(",")
    '            strQry = strQry.Remove(position1 - 1, position2 - position1 + 1)

    '            position1 = InStr(strQry, "(")
    '            position2 = InStr(strQry, ")")
    '            strValueString = Mid(strQry, position1 + 1, position2 - position1 - 1)
    '            strValue = strValueString.Split(",")
    '            For i = 0 To strName.Length - 1
    '                strValue(i) = strValue(i).Trim()
    '            Next
    '            'removing quotes


    '            For i = 0 To strValue.Length - 1
    '                If (Left(strValue(i), 1) = "'") Then
    '                    strValue(i) = strValue(i).Remove(0, 1)
    '                End If
    '                If (Right(strValue(i), 1) = "'") Then
    '                    strValue(i) = strValue(i).Remove(strValue(i).Length - 1, 1)
    '                End If
    '                strValue(i) = strValue(i).Replace("''", "'")
    '                strValue(i) = strValue(i).Replace("|", ",")
    '                strValue(i) = strValue(i).Replace("^", "(")
    '                strValue(i) = strValue(i).Replace("$", ")")

    '            Next

    '            For i = 0 To strName.Length - 1
    '                strName(i) = strName(i).Trim
    '                strValue(i) = strValue(i).Trim()
    '            Next
    '            'Finding the data type
    '            Dim mFname As String

    '            For i = 0 To strValue.Length - 1
    '                mFname = strName(i).ToString
    '                If ds.Tables(0).Columns(mFname).DataType.ToString = "System.Boolean" Then
    '                    strValue(i) = IIf((strValue(i) = "1"), True, False)
    '                ElseIf ds.Tables(0).Columns(mFname).DataType.ToString = "System.DateTime" Then
    '                    Dim strDateVal As String
    '                    strDateVal = Trim((strValue(i)))
    '                    If strDateVal.ToUpper <> "NULL" Then
    '                        strValue(i) = (Mid(strDateVal, 4, 2) & "/" & Mid(strDateVal, 1, 2) & "/" & Mid(strDateVal, 7, 4))
    '                    Else
    '                        strValue(i) = "Null"
    '                    End If
    '                End If
    '            Next


    '            Dim insertRow As DataRow = ds.Tables(tableName).NewRow()
    '            For i = 0 To strValue.Length - 1
    '                mFname = strName(i).ToString
    '                If strValue(i) <> "Null" Then
    '                    insertRow(mFname) = strValue(i)
    '                End If
    '            Next
    '            ds.Tables(tableName).Rows.Add(insertRow)
    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Sub
    '    Public Sub DeleteFromDataset(ByVal dsName As DataSet, ByVal tableName As String, ByVal intCurPosition As Integer)
    '        dsName.Tables(tableName).Rows.RemoveAt(intCurPosition)
    '    End Sub
    '#Region " Update to Dataset"

    '    Public Sub UpdateToDataset(ByVal dsName As DataSet, ByVal strQueryName As String, ByVal mIntCurPosition As Integer)
    '        Try
    '            Dim strName(100) As String
    '            Dim strValue(100) As String
    '            Dim strFieldValue() As String = Nothing
    '            Dim strNameString As String
    '            Dim strValueString As String
    '            Dim tableName As String
    '            Dim position1, position2 As Integer
    '            Dim str As String
    '            Dim strCondition As String
    '            Dim strc() As String
    '            Dim intCount As Integer = 0
    '            Dim i As Integer = 0
    '            str = strQueryName
    '            position1 = InStr(strQueryName, " ")
    '            str = str.Remove(position1 - 1, 1)
    '            str = str.Insert(position1 - 1, "@")
    '            position2 = str.IndexOf(" ")
    '            tableName = str.Substring(position1, position2 - position1)
    '            str = str.Remove(0, position2 + 4)
    '            str = str.Remove(0, 1)

    '            position1 = str.IndexOf("where")
    '            strValueString = str.Substring(0, position1 - 1)
    '            strCondition = str.Remove(0, position1 + 6)
    '            strFieldValue = strValueString.Split(",")

    '            strCondition = strCondition.Replace("and", ",")
    '            strCondition = strCondition.Replace("'", " ")

    '            strc = strCondition.Split(",")

    '            For i = 0 To strc.Length - 1
    '                position1 = InStr(strc(i), "=")
    '                strName(intCount) = Mid(strc(i), 1, position1 - 1).Trim
    '                strValue(intCount) = Mid(strc(i), position1 + 1).Trim
    '                strValue(intCount) = Mid(strc(i), position1 + 1).Trim
    '                intCount = intCount + 1
    '            Next i

    '            For i = 0 To strFieldValue.Length - 1
    '                position1 = InStr(strFieldValue(i), "=")
    '                strName(intCount) = Mid(strFieldValue(i), 1, position1 - 1).Trim
    '                strValue(intCount) = Mid(strFieldValue(i), position1 + 1).Trim
    '                intCount = intCount + 1
    '            Next

    '            For i = 0 To intCount - 1
    '                If (Left(strValue(i), 1) = "'") Then
    '                    strValue(i) = strValue(i).Remove(0, 1)
    '                End If
    '                If (Right(strValue(i), 1) = "'") Then
    '                    strValue(i) = strValue(i).Remove(strValue(i).Length - 1, 1)
    '                End If
    '                strValue(i) = strValue(i).Replace("''", "'")
    '                strValue(i) = strValue(i).Replace("|", ",")
    '                strValue(i) = strValue(i).Replace("^", "(")
    '                strValue(i) = strValue(i).Replace("$", ")")
    '            Next
    '            For i = 0 To intCount - 1
    '                strName(i) = strName(i).Trim
    '                strValue(i) = strValue(i).Trim()
    '            Next

    '            Dim mFname As String
    '            dsName.Tables(tableName).Rows(mIntCurPosition).BeginEdit()
    '            For i = 0 To intCount - 1
    '                mFname = strName(i).ToString
    '                If dsName.Tables(0).Columns(mFname).DataType.ToString = "System.Boolean" Then
    '                    dsName.Tables(tableName).Rows(mIntCurPosition).Item(mFname) = IIf((strValue(i) = "1"), True, False)
    '                ElseIf dsName.Tables(0).Columns(mFname).DataType.ToString = "System.DateTime" Then
    '                    Dim strDateVal As String
    '                    strDateVal = Trim((strValue(i)))
    '                    If strDateVal.ToUpper <> "NULL" Then
    '                        dsName.Tables(tableName).Rows(mIntCurPosition).Item(mFname) = (Mid(strDateVal, 4, 2) & "/" & Mid(strDateVal, 1, 2) & "/" & Mid(strDateVal, 7, 4))
    '                    Else
    '                        strValue(i) = "Null"
    '                    End If
    '                ElseIf dsName.Tables(0).Columns(mFname).DataType.ToString = "System.Decimal" Then
    '                    dsName.Tables(tableName).Rows(mIntCurPosition).Item(mFname) = IIf((strValue(i).ToUpper = "NULL"), "NULL", strValue(i))
    '                Else
    '                    dsName.Tables(tableName).Rows(mIntCurPosition).Item(mFname) = Trim(strValue(i))
    '                End If
    '            Next i
    '            dsName.Tables(tableName).Rows(mIntCurPosition).EndEdit()
    '            dsName.Tables(tableName).AcceptChanges()

    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Sub
    '#End Region
    '    Public Function ValidEmailId(ByVal strEmailid As String) As Boolean
    '        Dim AryString As String() = Nothing
    '        Dim mEmailid As String
    '        Dim i As Integer
    '        Try
    '            'Check Printable chars except space & ^
    '            If InStr(strEmailid.Trim(), " ", CompareMethod.Text) > 0 Or InStr(strEmailid.Trim(), "^", CompareMethod.Text) > 0 Then Return False
    '            'Split with @ 
    '            AryString = strEmailid.Split(New [Char]() {"@"c})
    '            If (AryString.GetUpperBound(0)) = 1 Then
    '                ' @ should not preceded by dot without any chars
    '                If AryString(0).ToString.Trim() = "" Or AryString(0).ToString.Trim() = "." Then Return False
    '                ' @ preceded & succeeded by atleast one char
    '                For i = 1 To AryString.GetUpperBound(0)
    '                    If AryString(i).ToString.Trim() = "" Then
    '                        Return False
    '                    End If
    '                Next
    '                mEmailid = AryString(1).ToString
    '                AryString = Nothing
    '                'Split with . 
    '                AryString = mEmailid.Split(New [Char]() {"."c})
    '                If (AryString.GetUpperBound(0)) >= 1 Then
    '                    If AryString(0).ToString.Trim() = "" Then Return False
    '                    ' . preceded & succeeded by atleast one char & eMail id should not end with .
    '                    For i = 1 To AryString.GetUpperBound(0)
    '                        If AryString(i).ToString.Trim() = "" Then
    '                            Return False
    '                        End If
    '                    Next
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            Else
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Function
    '    Public Function ValidTAN(ByVal strTan As String) As Boolean
    '        Dim strValidChr As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    '        Dim strValidNum As String = "1234567890"
    '        Dim AryTan() As Char = Nothing

    '        If strTan.Length <> 10 Then
    '            Return False
    '        Else
    '            AryTan = strTan.ToCharArray
    '            If InStr(strValidChr, AryTan(0).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryTan(1).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryTan(2).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryTan(3).ToString, CompareMethod.Text) = 0 Or InStr(strValidChr, AryTan(9).ToString, CompareMethod.Text) = 0 Then
    '                Return False
    '            End If
    '            If InStr(strValidNum, AryTan(4).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryTan(5).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryTan(6).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryTan(7).ToString, CompareMethod.Text) = 0 Or InStr(strValidNum, AryTan(8).ToString, CompareMethod.Text) = 0 Then
    '                Return False
    '            End If
    '            Return True
    '        End If
    '    End Function
    '#Region " State"


    '    Public Sub FillState(ByVal cboName As ComboBox)

    '        cboName.Items.Add("ANDAMAN AND NICOBAR ISLANDS")
    '        cboName.Items.Add("ANDHRA PRADESH")
    '        cboName.Items.Add("ARUNACHAL PRADESH")
    '        cboName.Items.Add("ASSAM")
    '        cboName.Items.Add("BIHAR")
    '        cboName.Items.Add("CHANDIGARH")
    '        cboName.Items.Add("DADRA & NAGAR HAVELI")
    '        cboName.Items.Add("DAMAN & DIU")
    '        cboName.Items.Add("DELHI")
    '        cboName.Items.Add("GOA")
    '        cboName.Items.Add("GUJARAT")
    '        cboName.Items.Add("HARYANA")
    '        cboName.Items.Add("HIMACHAL PRADESH")
    '        cboName.Items.Add("JAMMU & KASHMIR")
    '        cboName.Items.Add("KARNATAKA")
    '        cboName.Items.Add("KERALA")
    '        cboName.Items.Add("LAKSHADWEEP")
    '        cboName.Items.Add("MADHYA PRADESH")
    '        cboName.Items.Add("MAHARASHTRA")
    '        cboName.Items.Add("MANIPUR")
    '        cboName.Items.Add("MEGHALAYA")
    '        cboName.Items.Add("MIZORAM")
    '        cboName.Items.Add("NAGALAND")
    '        cboName.Items.Add("ORISSA")
    '        cboName.Items.Add("PONDICHERRY")
    '        cboName.Items.Add("PUNJAB")
    '        cboName.Items.Add("RAJASTHAN")
    '        cboName.Items.Add("SIKKIM")
    '        cboName.Items.Add("TAMILNADU")
    '        cboName.Items.Add("TRIPURA")
    '        cboName.Items.Add("UTTAR PRADESH")
    '        cboName.Items.Add("WEST BENGAL")
    '        'cboName.Items.Add("CHHATTISGARH") 'ver 2.1.22
    '        cboName.Items.Add("CHHATISHGARH")
    '        cboName.Items.Add("UTTARANCHAL")
    '        'Ver 2.3.6-1513 Start
    '        'cboName.Items.Add("JHARLHAND")
    '        cboName.Items.Add("JHARKHAND")
    '        'Ver 2.3.6-1513 End
    '        cboName.Items.Add("OTHERS")
    '    End Sub
    '#End Region
    '    Public Sub ErrHandler(ByVal strErr As Exception)
    '        MsgBox(strErr.Message)
    '        MsgBox(strErr.StackTrace)
    '    End Sub
    '    Public Sub AddToTdsCode(ByVal mFileName As String, ByVal mTableName As String)
    '        Dim objReader As StreamReader
    '        Dim strFilePath As String
    '        Dim strLine As String
    '        Dim cmdCommand As New SqlClient.SqlCommand
    '        Try


    '            strFilePath = Application.StartupPath & "\" & mFileName

    '            cmdCommand.Connection = conTdsPac
    '            'ver 2.0
    '            'ver 2.0.3-15
    '            If mTableName = "SetDisplay" Then
    '                cmdCommand.CommandText = "select count(*) from " & mTableName & " where cocd='" & StrCocd & "'"
    '            Else
    '                cmdCommand.CommandText = "select count(*) from " & mTableName
    '            End If
    '            'ver 2.0.3-15
    '            If cmdCommand.ExecuteScalar = 0 Then

    '                objReader = New StreamReader(strFilePath)
    '                'objReader = New StreamReader(mFileName)
    '                strLine = Replace(Replace(Replace(objReader.ReadLine, """", "'"), "True", "1"), "False", "0")
    '                'ver 2.0.3-15
    '                If mTableName = "SetDisplay" Then
    '                    strLine = Replace(strLine, "DEMO", StrCocd)
    '                End If

    '                Do Until strLine = ""
    '                    cmdCommand.CommandText = "Insert Into " & mTableName & " values (" & strLine & ")"
    '                    cmdCommand.ExecuteNonQuery()
    '                    strLine = Replace(Replace(Replace(objReader.ReadLine, """", "'"), "True", "1"), "False", "0")
    '                    'ver 2.0.3-15
    '                    If mTableName = "SetDisplay" Then
    '                        strLine = Replace(strLine, "DEMO", StrCocd)
    '                    End If
    '                Loop
    '            End If
    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Sub
    '    Public Function OpenNewConnection() As SqlClient.SqlConnection
    '        If StrAuthentication = "Windows" Then
    '            OpenNewConnection = New SqlClient.SqlConnection("user id=" & StrSQLUserId & ";Password=" & StrSQLPwd & ";integrated security=SSPI;initial catalog=" & StrDbName & ";data source=" & StrSvrName & ";")
    '        Else
    '            OpenNewConnection = New SqlClient.SqlConnection("user id=" & StrSQLUserId & ";Password=" & StrSQLPwd & ";initial catalog=" & StrDbName & ";data source=" & StrSvrName & ";")
    '        End If

    '    End Function
    '    Public Sub GetRights(ByVal strMenu As String)
    '        'admin will have all rights
    '        If UCase(StrUserId) = "ADMIN" Then
    '            blnCanAdd = True
    '            blnCanModify = True
    '            blnCanDelete = True
    '            blnCanPrint = True
    '            Exit Sub
    '        End If
    '        ' if not admin, check for the rights

    '        Dim cmdUR As New SqlClient.SqlCommand("Select * from UserRights where cocd ='" & StrCocd & "' and DBCode ='" & StrDbName & "' and UserId='" & StrUserId & "' and MenuItem ='" & strMenu & "'", conBaseData)
    '        Dim dr As SqlClient.SqlDataReader

    '        dr = cmdUR.ExecuteReader

    '        If dr.Read = True Then
    '            blnCanAdd = dr("UpdateOptA")
    '            blnCanModify = dr("UpdateOptM")
    '            blnCanDelete = dr("UpdateOptD")
    '            blnCanPrint = dr("UpdateOptP")
    '        Else
    '            blnCanAdd = False
    '            blnCanModify = False
    '            blnCanDelete = False
    '            blnCanPrint = False
    '        End If
    '        dr.Close()
    '        cmdUR.Dispose()
    '    End Sub
    '    Public Function ChangeToDate(ByVal strDt As String) As String
    '        If strDt = "//" Then
    '            Return "Null"
    '        Else
    '            Return "'" & strDt.Substring(3, 2) & "/" & strDt.Substring(0, 2) & "/" & strDt.Substring(6, 4) & "'"
    '        End If

    '    End Function
    '#Region " Amount in Words"
    '    Public Function AmountInWords(ByVal value As Double) As String

    '        Try

    '            Dim amt As Double

    '            amt = value
    '            Dim amtword As String
    '            Dim words(100) As String
    '            If amt = 0 Then
    '                amtword = " "

    '            End If
    '            Dim temp_amt As Double
    '            Dim twrd As String
    '            temp_amt = 0
    '            twrd = ""

    '            words(1) = "One"
    '            words(2) = "Two"
    '            words(3) = "Three"
    '            words(4) = "Four"
    '            words(5) = "Five"
    '            words(6) = "Six"
    '            words(7) = "Seven"
    '            words(8) = "Eight"
    '            words(9) = "Nine"
    '            words(10) = "Ten"
    '            words(11) = "Eleven"
    '            words(12) = "Twelve"
    '            words(13) = "Thirteen"
    '            words(14) = "Fourteen"
    '            words(15) = "Fifteen"
    '            words(16) = "Sixteen"
    '            words(17) = "Seventeen"
    '            words(18) = "Eighteen"
    '            words(19) = "Nineteen"
    '            words(20) = "Twenty"
    '            words(30) = "Thirty"
    '            words(40) = "Forty"
    '            words(50) = "Fifty"
    '            words(60) = "Sixty"
    '            words(70) = "Seventy"
    '            words(80) = "Eighty"
    '            words(90) = "Ninety"

    '            temp_amt = amt

    '            amt = Int(amt)
    '            Do While amt <> 0
    '                If amt >= 1000000000 And (amt / 1000000000) <= 20 And amt < 100000000000.0# Then
    '                    twrd = twrd + words(Int(amt / 1000000000)) + " Million "
    '                    amt = amt Mod 1000000000
    '                End If
    '                If amt >= 1000000000 And (amt / 1000000000) > 20 And amt < 100000000000.0# Then
    '                    twrd = twrd + Words_fun(Int(amt / 1000000000)) + " Million "
    '                    amt = amt Mod 1000000000
    '                End If
    '                If amt >= 10000000 And (amt / 10000000) <= 20 And amt < 1000000000 Then
    '                    twrd = twrd + words(Int(amt / 10000000)) + " Crore "
    '                    amt = amt Mod 10000000
    '                End If
    '                If amt >= 10000000 And (amt / 10000000) > 20 And amt < 1000000000 Then
    '                    twrd = twrd + Words_fun(Int(amt / 10000000)) + " Crore "
    '                    amt = amt Mod 10000000
    '                End If
    '                If amt >= 100000 And (amt / 100000) <= 20 And amt < 10000000 Then
    '                    twrd = twrd + words(Int(amt / 100000)) + " Lakh "
    '                    amt = amt Mod 100000
    '                End If
    '                If amt >= 100000 And (amt / 100000) > 20 And amt < 10000000 Then
    '                    twrd = twrd + Words_fun(Int(amt / 100000)) + " Lakh "
    '                    amt = amt Mod 100000


    '                End If
    '                If amt >= 1000 And (amt / 1000) <= 20 And amt < 100000 Then
    '                    twrd = twrd + words(Int(amt / 1000)) + " Thousand "
    '                    amt = amt Mod 1000

    '                End If
    '                If amt >= 1000 And (amt / 1000) > 20 And amt < 100000 Then
    '                    twrd = twrd + Words_fun(Int(amt / 1000)) + " Thousand "
    '                    amt = amt Mod 1000

    '                End If
    '                If amt >= 100 And amt < 1000 Then
    '                    twrd = twrd + words(Int(amt / 100)) + " Hundred "
    '                    amt = amt Mod 100
    '                End If
    '                If amt >= 20 And amt < 100 Then
    '                    twrd = twrd + words(Int(amt / 10) * 10) + " "
    '                    amt = amt Mod 10
    '                End If
    '                If amt > 0 And amt < 20 Then
    '                    twrd = twrd + words(Int(amt)) + " "
    '                    amt = 0
    '                End If
    '                If amt >= 20 And amt <> 0 Then
    '                    twrd = twrd + words(Int(amt)) + " "
    '                    amt = 0
    '                End If
    '            Loop
    '            Dim deci_val As Integer
    '            deci_val = (temp_amt - Int(temp_amt)) * 100

    '            If deci_val = 0 Then
    '                amtword = twrd + " Only "
    '            Else
    '                amtword = twrd + " And Paise " + Words_fun(deci_val) + " Only "
    '            End If
    '            Return amtword
    '        Catch ex As Exception

    '        End Try
    '    End Function
    '    Public Function Words_fun(ByVal val As Integer)
    '        Dim words(100) As String
    '        words(1) = "One"
    '        words(2) = "Two"
    '        words(3) = "Three"
    '        words(4) = "Four"
    '        words(5) = "Five"
    '        words(6) = "Six"
    '        words(7) = "Seven"
    '        words(8) = "Eight"
    '        words(9) = "Nine"
    '        words(10) = "Ten"
    '        words(11) = "Eleven"
    '        words(12) = "Twelve"
    '        words(13) = "Thirteen"
    '        words(14) = "Fourteen"
    '        words(15) = "Fifteen"
    '        words(16) = "Sixteen"
    '        words(17) = "Seventeen"
    '        words(18) = "Eighteen"
    '        words(19) = "Nineteen"
    '        words(20) = "Twenty"
    '        words(30) = "Thirty"
    '        words(40) = "Forty"
    '        words(50) = "Fifty"
    '        words(60) = "Sixty"
    '        words(70) = "Seventy"
    '        words(80) = "Eighty"
    '        words(90) = "Ninety"

    '        Dim twrd1 As String
    '        twrd1 = ""

    '        If val < 100 And val > 20 Then
    '            twrd1 = twrd1 + words(Int(val / 10) * 10) + " "
    '            val = val Mod 10

    '        End If
    '        val = Int(val)

    '        If val <= 20 And val <> 0 Then
    '            twrd1 = twrd1 + words(Int(val)) + " "

    '        End If
    '        Words_fun = twrd1
    '    End Function

    '#End Region
    '    Public Function ConvertDataReaderToDataSet(ByVal reader As SqlClient.SqlDataReader) As DataSet
    '        Try
    '            Dim dataSet As DataSet = New DataSet
    '            Dim schemaTable As DataTable = reader.GetSchemaTable()
    '            Dim dataTable As DataTable = New DataTable("myTable")
    '            Dim intCounter As Integer
    '            For intCounter = 0 To schemaTable.Rows.Count - 1
    '                Dim dataRow As DataRow = schemaTable.Rows(intCounter)
    '                Dim columnName As String = dataRow("ColumnName")
    '                Dim column As DataColumn = New DataColumn(columnName)
    '                dataTable.Columns.Add(column)
    '            Next

    '            dataSet.Tables.Add(dataTable)
    '            While reader.Read()
    '                Dim dataRow As DataRow = dataTable.NewRow()
    '                For intCounter = 0 To reader.FieldCount - 1
    '                    Dim str As String = reader.GetValue(intCounter).ToString
    '                    If str = "" Then
    '                        DataRow(intCounter) = ""
    '                    Else
    '                        DataRow(intCounter) = reader.GetValue(intCounter)
    '                    End If
    '                Next
    '                dataTable.Rows.Add(dataRow)
    '            End While
    '            Return dataSet

    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Function

    Public Function EnCrypt(ByVal Text As String) As Boolean
        Dim objWriter As StreamWriter
        Try
            Dim sr As StreamReader = File.OpenText(Text)
            Dim s, strWords, strTemp As String
            Dim intasc, intTemp As Integer
            Dim input As String
            Dim strEncMessage, strMessage As String
            strWords = sr.ReadToEnd
            sr.Close()

            Dim objPublicKeyGenerator = New clsEncrypt.PublicKeyGenerator
            Dim objMyKeyPair = objPublicKeyGenerator.MakeKeyPair
            objPublicKeyGenerator = Nothing
            objMyKeyPair.PublicKey.Key = strPublic
            objMyKeyPair.PrivateKey.Key = strPrivate
            objMyKeyPair.PrivateKey.Label = "My Private Key"
            objMyKeyPair.PublicKey.Label = "My Public Key"
            Dim objCryptographyFunctions = New clsEncrypt.CryptographyFunctions
            strPublic = objMyKeyPair.PublicKey.Key
            strPrivate = objMyKeyPair.PrivateKey.Key
            Dim objMyKeyRing = New clsEncrypt.KeyRing
            objMyKeyRing.AddKeyPair(objMyKeyPair)
            strMessage = strWords

            strEncMessage = objCryptographyFunctions.SignAndEncrypt(objMyKeyPair, strMessage)
            Dim objReader As StreamReader

            'Dim strFileName As String
            objWriter = New StreamWriter(Text)
            objWriter.Write(strEncMessage)
            objWriter.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            MessageBox.Show(ex.StackTrace.ToString)
        End Try
        Return True
    End Function

    Public Function Decrypt(ByVal Text As String) As String
        Try
            Dim objPublicKeyGenerator = New clsEncrypt.PublicKeyGenerator

            Dim objMyKeyPair = objPublicKeyGenerator.MakeKeyPair
            objMyKeyPair.Publickey.key = strPublic
            objMyKeyPair.PrivateKey.Key = strPrivate
            objPublicKeyGenerator = Nothing
            Dim objCryptographyFunctions = New clsEncrypt.CryptographyFunctions
            Dim strEncMessage, strMessage As String
            Dim sr As StreamReader = File.OpenText(Text)
            Dim input, input1 As String
            input = sr.ReadToEnd
            sr.Close()
            strEncMessage = input
            strMessage = objCryptographyFunctions.DecryptAndAuthenticate(objMyKeyPair, strEncMessage)
            Return strMessage
            Dim objReader As StreamReader
            Dim objWriter As StreamWriter
            Dim strFileName As String
            objWriter = New StreamWriter(Text)
            objWriter.Write(strMessage)
            objWriter.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            MessageBox.Show(ex.StackTrace.ToString)
        End Try
    End Function

    '    Function StateCode(ByVal StrState As String) As String
    '        Select Case StrState
    '            Case "ANDAMAN AND NICOBAR ISLANDS"
    '                StateCode = "01"
    '            Case "ANDHRA PRADESH"
    '                StateCode = "02"
    '            Case "ARUNACHAL PRADESH"
    '                StateCode = "03"
    '            Case "ASSAM"
    '                StateCode = "04"
    '            Case "BIHAR"
    '                StateCode = "05"
    '            Case "CHANDIGARH"
    '                StateCode = "06"
    '            Case "DADRA & NAGAR HAVELI"
    '                StateCode = "07"
    '            Case "DAMAN & DIU"
    '                StateCode = "08"
    '            Case "DELHI"
    '                StateCode = "09"
    '            Case "GOA"
    '                StateCode = "10"
    '            Case "GUJARAT"
    '                StateCode = "11"
    '            Case "HARYANA"
    '                StateCode = "12"
    '            Case "HIMACHAL PRADESH"
    '                StateCode = "13"
    '            Case "JAMMU & KASHMIR"
    '                StateCode = "14"
    '            Case "KARNATAKA"
    '                StateCode = "15"
    '            Case "KERALA"
    '                StateCode = "16"
    '            Case "LAKHSWADEEP"
    '                StateCode = "17"
    '            Case "MADHYA PRADESH"
    '                StateCode = "18"
    '            Case "MAHARASHTRA"
    '                StateCode = "19"
    '            Case "MANPUR"
    '                StateCode = "20"
    '            Case "MEGHALAYA"
    '                StateCode = "21"
    '            Case "MIZORAM"
    '                StateCode = "22"
    '            Case "NAGALAND"
    '                StateCode = "23"
    '            Case "ORISSA"
    '                StateCode = "24"
    '            Case "PONDICHERRY"
    '                StateCode = "25"
    '            Case "PUNJAB"
    '                StateCode = "26"
    '            Case "RAJASTHAN"
    '                StateCode = "27"
    '            Case "SIKKIM"
    '                StateCode = "28"
    '            Case "TAMILNADU"
    '                StateCode = "29"
    '            Case "TRIPURA"
    '                StateCode = "30"
    '            Case "UTTAR PRADESH"
    '                StateCode = "31"
    '            Case "WEST BENGAL"
    '                StateCode = "32"
    '            Case "CHHATISHGARH", "CHHATTISGARH" 'ver 2.1.22
    '                StateCode = "33"
    '            Case "UTTARANCHAL"
    '                StateCode = "34"
    '            Case "JHARKHAND"
    '                StateCode = "35"
    '            Case "99-FOR NRI"
    '                StateCode = "99"
    '            Case Else
    '                StateCode = "00"
    '        End Select
    '    End Function
    '    Function GetNullVal(ByVal mVal As Object) As Double
    '        Try
    '            GetNullVal = (IIf(IsDBNull(mVal), 0, mVal))
    '            Exit Function
    '        Catch ex As Exception
    '            GetNullVal = 0
    '        End Try
    '    End Function
    '    'ra 1.3.109
    '    Sub ChangeDate()
    '        Try
    '            Dim lngLocale As Int32
    '            lngLocale = GetSystemDefaultLCID()
    '            If SetLocaleInfo(lngLocale, &H1F, "dd/MM/yyyy") = False Then
    '            End If
    '            MsgBox("Date Format Changed Successfully. Please run Tdspac again", vbInformation)
    '            End
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub
    '    'ra 1.3.109
    '    'ra1.3.109
    '    Public Function AddColmnInTable(ByVal strTable As String, ByVal strField As String, ByVal strFieldType As String, ByVal conTable As SqlConnection)
    '        Dim cmdTable As New SqlCommand
    '        cmdTable.Connection = conTable
    '        Try
    '            cmdTable.CommandText = "select   top 1 " & strField & " from " & strTable & ""
    '            cmdTable.ExecuteNonQuery()
    '        Catch ex As Exception
    '            cmdTable.CommandText = "alter table " & strTable & " add " & strField & " " & strFieldType & ""
    '            cmdTable.ExecuteNonQuery()
    '        End Try
    '    End Function
    '    'ra1.3.109

    '    'uj 1.3.109
    '    Public Sub ExportToExcel(ByVal dsExport As DataSet)
    '        Try

    '            Dim IEProcess As Process = New Process

    '            Dim hWndDesk
    '            Dim params
    '            Dim mFile As File
    '            Dim rs As Long
    '            params = vbNullString
    '            hWndDesk = GetDesktopWindow()

    '            Dim ts As StreamWriter
    '            Dim i, j As Integer
    '            Dim mExpText As String
    '            Dim mStr As String
    '            Dim mPos As Integer

    '            Dim ExlAppln As New Object
    '            Dim ExlBook As New Object

    '            ExlAppln = CreateObject("Excel.Application")

    '            ts = New StreamWriter(Application.StartupPath & "\ExportP.xls")

    '            mExpText = ""
    '            mStr = ""
    '            'ver 2.0.3-23

    '            For k As Integer = 0 To dsExport.Tables(0).Columns.Count - 1
    '                mStr = dsExport.Tables(0).Columns(k).ColumnName.ToString
    '                If mExpText = "" Then
    '                    mExpText = IIf(mStr = "", Space(1), mStr)
    '                    'mExpText = mExpText & Chr(9) & mStr
    '                Else
    '                    mExpText = mExpText & Chr(9) & IIf(mStr = "", Space(1), mStr)
    '                End If

    '                'memptext=
    '                'MsgBox(dsExport.Tables(0).Columns(k).ColumnName)
    '            Next
    '            ts.WriteLine(mExpText)
    '            'ver 2.0.2
    '            mExpText = ""
    '            mStr = ""
    '            'ver 2.0.3-23

    '            For i = 0 To dsExport.Tables(0).Rows.Count - 1
    '                mStr = ""
    '                For j = 0 To dsExport.Tables(0).Columns.Count - 1
    '                    If mExpText = "" Then
    '                        'Ver 2.3.6-E27 Start
    '                        'mExpText = IIf((dsExport.Tables(0).Rows(i).Item(j) = ""), Space(1), dsExport.Tables(0).Rows(i).Item(j))
    '                        If IsDBNull(dsExport.Tables(0).Rows(i).Item(j)) = False Then
    '                            mExpText = IIf((dsExport.Tables(0).Rows(i).Item(j) = ""), Space(1), dsExport.Tables(0).Rows(i).Item(j))
    '                        End If
    '                        'Ver 2.3.6-E27 End
    '                        mExpText = IIf(Mid(mExpText, 1, 1) = "0", "'" & mExpText, mExpText)
    '                    Else
    '                        'Ver 2.3.6-E27 Start
    '                        'mPos = InStr(1, dsExport.Tables(0).Rows(i).Item(j), Chr(13))
    '                        'mStr = dsExport.Tables(0).Rows(i).Item(j)
    '                        If IsDBNull(dsExport.Tables(0).Rows(i).Item(j)) = False Then
    '                            mPos = InStr(1, dsExport.Tables(0).Rows(i).Item(j), Chr(13))
    '                            mStr = dsExport.Tables(0).Rows(i).Item(j)
    '                        Else
    '                            mStr = vbNullString
    '                        End If
    '                        'Ver 2.3.6-E27 End

    '                        Do While mPos > 0
    '                            mStr = Mid(mStr, 1, Val(mPos) - 1) & " " & Mid(mStr, Val(mPos) + 2)
    '                            mPos = InStr(1, mStr, Chr(13))
    '                        Loop

    '                        mExpText = mExpText & Chr(9) & mStr
    '                    End If
    '                Next
    '                ts.WriteLine(mExpText)
    '                mExpText = ""
    '            Next
    '            ts.Close()

    '            If mFile.Exists(Application.StartupPath & "\ExportP.xls") = True Then
    '                IEProcess.Start(Application.StartupPath & "\ExportP.xls")
    '            End If
    '        Catch ex As Exception
    '            MsgBox("The process cannot access the file """ & Application.StartupPath & "\ExportP.xls"" because it is being used by another process.")
    '            If ex.Message = "The process cannot access the file """ & Application.StartupPath & "\ExportP.xls"" because it is being used by another process." Then
    '                MsgBox("Close file 'ExportP.xls' and then try again!")
    '            Else
    '                Call ErrHandler(ex)
    '            End If

    '        End Try
    '    End Sub
    '    'ver 2.0.3-22
    '    Public Function RQ(ByVal StrVal As String) As String
    '        'Remove Quote
    '        RQ = Replace(StrVal, "'", "''")
    '        Return RQ
    '    End Function
    '    'ver 2.0.3-22

    '    Public Sub AlterImportSetupTable() 'ver 2.03 - For Pune Client
    '        '1. Objective - To Add Surcharge field into ImportSetup Table
    '        'first to find out whether this field is exising or not in the 
    '        'database
    '        Try

    '            Dim adpNewField As New SqlDataAdapter("Select * from ImportSetup", conTdsPac)
    '            Dim ds As New DataSet
    '            adpNewField.Fill(ds)

    '            'Ver 2.3.8-1719 Start
    '            'If ds.Tables(0).Columns.Contains("Surcharge") = True Then
    '            '    adpNewField.Dispose()
    '            '    Exit Sub
    '            'End If
    '            If ds.Tables(0).Columns.Contains("Surcharge") = False Then
    '                'Ver 2.3.8-1719 End
    '                Dim conNewField As New SqlCommand("Alter table ImportSetup add Surcharge nVarChar(50)", conTdsPac)
    '                conNewField.ExecuteNonQuery()
    '                Dim conNewField1 As New SqlCommand("Alter table LogImportSetup add Surcharge nVarChar(50)", conTdsPac)
    '                conNewField1.ExecuteNonQuery()
    '            End If

    '            'Ver 2.3.8-1719 Start
    '            adpNewField.Dispose()
    '            ds.Dispose()

    '            Dim Da As New SqlDataAdapter
    '            Dim DsTdsSubCode As New DataSet
    '            Dim cmd As New SqlCommand

    '            Da = New SqlDataAdapter("Select * from ImportSetup", conTdsPac)
    '            Da.Fill(DsTdsSubCode)
    '            If DsTdsSubCode.Tables(0).Columns.Contains("TranTdsStatus") = False Then
    '                cmd = New SqlCommand("Alter table ImportSetup add TranTdsStatus nVarchar(50)", conTdsPac)
    '                cmd.ExecuteNonQuery()
    '                cmd = New SqlCommand("Alter table LogImportSetup add TranTdsStatus nVarchar(50)", conTdsPac)
    '                cmd.ExecuteNonQuery()
    '                cmd = New SqlCommand("Alter table ImportSetup add TranTdsSubcode nVarchar(50)", conTdsPac)
    '                cmd.ExecuteNonQuery()
    '                cmd = New SqlCommand("Alter table LogImportSetup add TranTdsSubcode nVarchar(50)", conTdsPac)
    '                cmd.ExecuteNonQuery()
    '                cmd.Dispose()
    '            End If
    '            DsTdsSubCode.Dispose()
    '            Da.Dispose()
    '            'Ver 2.3.8-1719 End

    '        Catch ex As Exception
    '            Call ErrHandler(ex)
    '        End Try
    '    End Sub

    '    Public Sub CreateTabeTdsFile()
    '        'form16a-new format changes
    '        Try
    '            'ver2.0.4-PRN Change
    '            Dim cmd As New SqlClient.SqlCommand
    '            cmd.Connection = conTdsPac
    '            cmd.CommandText = "SELECT count(Name) FROM sysobjects Where Name= 'eTdsFile' AND xType= 'U'"
    '            If cmd.ExecuteScalar = 0 Then
    '                cmd.CommandText = "create table eTdsFile(FormNo varchar(10),Quarter varchar(10),RDate smalldatetime,PRNNo varchar(15),Cocd varchar(15))"
    '            Else
    '                Dim adpNewField As New SqlDataAdapter("Select * from eTdsFile", conTdsPac)
    '                Dim ds As New DataSet
    '                adpNewField.Fill(ds)
    '                If ds.Tables(0).Columns.Contains("Cocd") = True Then
    '                    adpNewField.Dispose()
    '                    Exit Sub
    '                End If
    '                adpNewField.Dispose()
    '                'cmd.CommandText = "alter table eTdsFile add Cocd varchar(15)"
    '            End If
    '            cmd.ExecuteNonQuery()

    '        Catch ex As Exception
    '            If ex.Message = "There is already an object named 'eTdsFile' in the database." Then
    '                Exit Sub
    '            ElseIf ex.Message = "Column names in each table must be unique. Column name 'Cocd' in table 'eTdsFile' is specified more than once." Then
    '                Exit Sub
    '            Else
    '                Call ErrHandler(ex)
    '            End If
    '            'ver2.0.4-PRN Change
    '        End Try
    '    End Sub

    '    Sub CreateSunMaster()

    '        On Error GoTo errhead
    '        Dim strSql As String
    '        Dim cmdSun As New SqlCommand
    '        cmdSun.Connection = conTdsPac
    '        'Checking the table
    '        Dim cmd As New SqlClient.SqlCommand

    '        cmd.Connection = conTdsPac

    '        cmd.CommandText = "SELECT count(Name) FROM sysobjects Where Name= 'SunMaster' AND xType= 'U'"
    '        If cmd.ExecuteScalar > 0 Then
    '            'ver 2.3.6-1479 start
    '            'Ver 2.3.9-E60 start
    '            'If StrFinYear = "2008-2009" Then
    '            If StrFinYear = "2008-2009" Or StrFinYear = "2009-2010" Then

    '                'Dim cmdTemp As New SqlCommand("SELECT count(*) from SunMaster where CodeField ='First' and CodeValue ='8'", conTdsPac)
    '                Dim cmdTemp As New SqlClient.SqlCommand
    '                cmdTemp.Connection = conTdsPac
    '                If StrFinYear = "2008-2009" Then
    '                    cmdtemp.CommandText = "SELECT count(*) from SunMaster where CodeField ='First' and CodeValue ='8'"
    '                Else
    '                    cmdTemp.CommandText = "SELECT count(*) from SunMaster where CodeField ='First' and CodeValue ='9'"
    '                End If
    '                'Ver 2.3.9-E60 end
    '                If cmdTemp.ExecuteScalar = 0 Then
    '                    'Ver 2.3.9-E60 start
    '                    If StrFinYear = "2008-2009" Then
    '                        'Ver 2.3.9-E60 end
    '                        Call UpdateSun("Insert into SunMaster values ('First','8','wef 1st April','')", cmdSun)
    '                        'Ver 2.3.9-E60 start
    '                    Else
    '                        Call UpdateSun("Insert into SunMaster values ('First','9','wef 1st April','')", cmdSun)
    '                    End If
    '                    'Ver 2.3.9-E60 end
    '                End If
    '                cmdTemp.Dispose()
    '            End If
    '            'ver 2.3.6-1479 end
    '            Exit Sub
    '        End If
    '        cmd.Dispose()

    '        strSql = "Create Table SunMaster (CodeField nVarChar(10),CodeValue nVarChar(20),Description nVarChar(50),TdsCode nVarChar(10))"
    '        cmdSun.CommandText = strSql
    '        cmdSun.ExecuteNonQuery()
    '        'Ver 2.3.9-E60 start
    '        'Call UpdateSun("Insert into SunMaster values ('First','A','Till 31st May','')", cmdSun)
    '        'Call UpdateSun("Insert into SunMaster values ('First','7','wef 1st June','')", cmdSun)
    '        If StrFinYear = "2007-2008" Then
    '            Call UpdateSun("Insert into SunMaster values ('First','A','Till 31st May','')", cmdSun)
    '            Call UpdateSun("Insert into SunMaster values ('First','7','wef 1st June','')", cmdSun)
    '        End If
    '        'Ver 2.3.9-E60 end
    '        Call UpdateSun("Insert into SunMaster values ('Second','A','Companies','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','B','Individual','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','C','Companies','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','F','Firm','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','H','HUF','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','J','Artificial Juricidical Person','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','L','Local Authority','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','N','Individual','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','O','Co-Operative Society','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Second','P','AOP/BOI','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','A','Advertisement','94C')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','B','Brokerage / Commission','94H')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','C','Contractor','94C')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','I','Interest','94A')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','N','Insurance Commission','94D')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','P','Professional Fees','94J')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','R','Rent','94I')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','S','Sub Contractor','94C')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','L','Winning from Lotteries','94B')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','Y','Royalty','195')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Third','M','Plant & Machinery Rent','94I')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Fourth','0','Zero Rate - Self declration','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Fourth','1','Normal Rate','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Fourth','A - Z','Special Rate','')", cmdSun)
    '        Call UpdateSun("Insert into SunMaster values ('Fourth','2','Surcharge Rate 10','')", cmdSun)
    '        'ver 2.3.6-1479 start
    '        If StrFinYear = "2008-2009" Then Call UpdateSun("Insert into SunMaster values ('First','8','wef 1st April','')", cmdSun)
    '        'ver 2.3.6-1479 End
    '        'Ver 2.3.9-E60 start
    '        If StrFinYear = "2009-2010" Then
    '            Call UpdateSun("Insert into SunMaster values ('Third','D','Dividend','194')", cmdSun)
    '            Call UpdateSun("Insert into SunMaster values ('Third','E','Deposit of NSS','4EE')", cmdSun)
    '            Call UpdateSun("Insert into SunMaster values ('Third','T','Interest on Securities','193')", cmdSun)
    '        End If
    '        'Ver 2.3.9-E60 end
    'errhead:
    '        Exit Sub
    '    End Sub

    '    Private Sub UpdateSun(ByVal strSql As String, ByVal cmdSun As SqlCommand)
    '        cmdSun.CommandText = strSql
    '        cmdSun.ExecuteNonQuery()
    '    End Sub

    '    Public Function ValidPanPattern(ByVal mPan As String) As Boolean
    '        Dim j As Integer
    '        Dim strValidChr As String

    '        strValidChr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    '        ValidPanPattern = False

    '        'Ver 2.3.8-II Priority 1 start
    '        If Trim(mPan) = "" Or Len(Trim(mPan)) <> 10 Then
    '            ValidPanPattern = False
    '            Exit Function
    '        End If
    '        'Ver 2.3.8-II Priority 1 end

    '        For j = 1 To 5
    '            If j = 4 Then
    '                If InStr(1, "ABCFGHJLPT", UCase(Mid(mPan, 4, 1))) = 0 Then
    '                    ValidPanPattern = False
    '                    Exit Function
    '                End If
    '            End If

    '            If InStr(1, strValidChr, Mid(mPan, j, 1)) = 0 Then
    '                ValidPanPattern = False
    '                Exit Function
    '            End If
    '        Next
    '        For j = 6 To 9
    '            If InStr(1, "1234567890", Mid(mPan, j, 1)) = 0 Then
    '                ValidPanPattern = False
    '                Exit Function
    '            End If
    '        Next
    '        If InStr(1, strValidChr, Mid(mPan, 10, 1)) = 0 Then
    '            ValidPanPattern = False
    '            Exit Function
    '        End If
    '        ValidPanPattern = True

    '    End Function

    '    Function CreatePanFile(ByVal mFolder As String) As Boolean

    '        On Error GoTo errhead
    '        strPanFile = mFolder & "\InvalidPan.txt"
    '        tsPanFile = New System.IO.StreamWriter(strPanFile)
    '        tsPanFile.WriteLine("Sr.No " & "Party Name" & Space(65) & "Wrong Pan")
    '        CreatePanFile = True
    '        Exit Function

    'errhead:
    '        If Err.Number = 70 Then
    '            MsgBox("Please close file : " & strPanFile & "  before creating eTDS File", vbInformation, "eTDSWiz")
    '            CreatePanFile = False
    '            Exit Function
    '        Else

    '        End If
    '    End Function

    '    Function CalculatePercentage(ByVal blnSalary As Boolean) As Boolean
    '        Dim curPercentage As Decimal
    '        Dim curValidPercet As Decimal
    '        Dim strCorrect As Integer
    '        On Error Resume Next
    '        tsPanFile.Close()
    '        If blnSalary = True Then
    '            'ver 2.3.2-FVU2116 start
    '            'curValidPercet = 10
    '            'strCorrect = 90
    '            curValidPercet = 5
    '            strCorrect = 95
    '            'ver 2.3.2-FVU2116 end
    '        Else
    '            'ver 2.3.2-FVU2116 start
    '            'curValidPercet = 30
    '            'strCorrect = 70
    '            curValidPercet = 15
    '            strCorrect = 85
    '            'ver 2.3.2-FVU2116 end
    '        End If

    '        Dim r
    '        curPercentage = (intTotalWrongPan / intTotalRecordForPan) * 100
    '        If curPercentage > curValidPercet Then
    '            MsgBox("Total Deductee Records= " & intTotalRecordForPan & vbCrLf & "Recods with structurally invalid PANs = " & intTotalWrongPan & vbCrLf & "Percentage of wrong PAN = " & curPercentage & vbCrLf & "eTDS file cannot be created. Minimum " & strCorrect & " % PANs must be structurally valid", vbCritical)

    '            If MsgBox("Do you still want to Create eTds File?", MsgBoxStyle.YesNo) = vbYes Then
    '                CalculatePercentage = True
    '            Else
    '                Dim IEProcess As Process = New Process
    '                IEProcess.Start(strPanFile)
    '                'r = ShellExecute(hWndDesk, "Open", strPanFile, params, 0&, 1)
    '                CalculatePercentage = False
    '            End If           'End

    '            Exit Function
    '        End If
    '        CalculatePercentage = True
    '    End Function

    '    Sub UpdatePanFile(ByVal StrParty As String, ByVal strPAN As String)
    '        On Error Resume Next
    '        intTotalRecordForPan = intTotalRecordForPan + 1
    '        If ValidPanPattern(strPAN) = False Then
    '            intTotalWrongPan = intTotalWrongPan + 1
    '            tsPanFile.WriteLine(intTotalWrongPan & Space(7 - intTotalWrongPan.ToString.Length) & StrParty & Space(75 - StrParty.Length) & strPAN)
    '        End If

    '    End Sub

    '    'Ver 2.4.0-AXIS-BANK Start
    '    Function PrnUpdated(ByVal strTdsCode As String, ByVal strChlnNo As String) As Integer
    '        Dim strQuery As String
    '        Dim cmd As New SqlCommand

    '        If blnPrnRestrict Then
    '            If strTdsCode = "195" Then
    '                strQuery = "select count(c.[Quarter]) from eTdsFile e, Challan C where e.cocd=c.cocd and             e.[quarter]=c.[quarter] and e.FormNo='26Q' and c.challanno='" & strChlnNo & "' and e.Cocd='" & StrCocd & "'"
    '            Else
    '                strQuery = "select count(c.[Quarter]) from eTdsFile e, Challan c where e.cocd=c.cocd and             e.[quarter]=c.[quarter] and e.FormNo='27Q' and c.challanno='" & strChlnNo & "' and e.Cocd='" & StrCocd & "' "
    '            End If
    '            'Ver 2.4.0-Rajani Start
    '            cmd.Connection = conTdsPac
    '            cmd.CommandText = strQuery
    '            Return cmd.ExecuteScalar
    '            'Ver 2.4.0-Rajani End
    '        End If
    '        'Ver 2.4.0-Rajani Start
    '        'cmd.Connection = conTdsPac
    '        'cmd.CommandText = strQuery
    '        'Return cmd.ExecuteScalar
    '        'Ver 2.4.0-Rajani End
    '    End Function
    '    'Ver 2.4.0-AXIS-BANK End


    Public Function CheckUpgrade(ByVal mVersionFileName As String, ByVal AppVerNo As String) As String

        Dim sVerNo As String
        Dim sServerNm As String
        Dim webBrws As New WebClient

        Application.DoEvents()
        sVerNo = webBrws.DownloadString(mVersionFileName)
        sServerNm = webBrws.Headers("Server")

        If sServerNm = "" Then
            CheckUpgrade = "Unable to connect to Internet"
            Return ("")
        End If

        If Val(sVerNo) > Val(AppVerNo) Then
            Return ("You are using Old Version ! " & "Download Version " & sVerNo)
        Else
            Return ("")
        End If

    End Function


  


End Module