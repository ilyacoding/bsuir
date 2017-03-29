object Form1: TForm1
  Left = 0
  Top = 0
  Caption = #1055#1086#1090#1086#1082#1086#1074#1086#1077' '#1096#1080#1092#1088#1086#1074#1072#1085#1080#1077
  ClientHeight = 521
  ClientWidth = 1000
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesigned
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object PanelLFSR: TPanel
    Left = 8
    Top = 207
    Width = 553
    Height = 91
    ShowCaption = False
    TabOrder = 0
    object LabelLFSR1: TLabel
      Left = 23
      Top = 51
      Width = 32
      Height = 16
      Caption = 'Value'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object EditKey: TLabeledEdit
      Left = 23
      Top = 24
      Width = 234
      Height = 21
      EditLabel.Width = 144
      EditLabel.Height = 13
      EditLabel.Caption = 'LFSR State (x^23 + x^5 + 1)'
      MaxLength = 23
      NumbersOnly = True
      TabOrder = 0
      OnChange = EditKeyChange
      OnKeyPress = EditKeyKeyPress
    end
    object ButtonInitLFSR1: TButton
      Left = 352
      Top = 22
      Width = 75
      Height = 25
      Caption = 'Initialize'
      Enabled = False
      TabOrder = 1
      OnClick = ButtonInitLFSR1Click
    end
    object ButtonTakt: TButton
      Left = 352
      Top = 53
      Width = 75
      Height = 25
      Caption = 'Tick'
      Enabled = False
      TabOrder = 2
      OnClick = ButtonTaktClick
    end
    object ButtonEncrypt: TButton
      Left = 454
      Top = 1
      Width = 98
      Height = 89
      Align = alRight
      Caption = 'Process'
      Enabled = False
      Style = bsCommandLink
      TabOrder = 3
      OnClick = ButtonEncryptClick
    end
  end
  object PanelGeffe: TPanel
    Left = 8
    Top = 304
    Width = 984
    Height = 210
    TabOrder = 1
    object LabelGLFSR1: TLabel
      Left = 23
      Top = 59
      Width = 32
      Height = 16
      Caption = 'Value'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object LabelGLFSR2: TLabel
      Left = 23
      Top = 123
      Width = 32
      Height = 16
      Caption = 'Value'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object LabelGLFSR3: TLabel
      Left = 23
      Top = 187
      Width = 32
      Height = 16
      Caption = 'Value'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object LabelGeffeKey: TLabel
      Left = 300
      Top = 162
      Width = 36
      Height = 19
      Caption = 'Key: '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object LabelX2: TLabel
      Left = 1
      Top = 123
      Width = 18
      Height = 19
      Caption = 'X2'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object LabelX1: TLabel
      Left = 1
      Top = 59
      Width = 18
      Height = 19
      Caption = 'X1'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object LabelX3: TLabel
      Left = 1
      Top = 187
      Width = 18
      Height = 19
      Caption = 'X3'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object Label1: TLabel
      Left = 405
      Top = 40
      Width = 6
      Height = 13
      Caption = '1'
    end
    object Label2: TLabel
      Left = 405
      Top = 69
      Width = 6
      Height = 13
      Caption = '1'
    end
    object Label3: TLabel
      Left = 405
      Top = 96
      Width = 6
      Height = 13
      Caption = '1'
    end
    object Label4: TLabel
      Left = 405
      Top = 117
      Width = 6
      Height = 13
      Caption = '1'
    end
    object Label5: TLabel
      Left = 381
      Top = 36
      Width = 18
      Height = 19
      Caption = 'X1'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object Label6: TLabel
      Left = 381
      Top = 67
      Width = 18
      Height = 19
      Caption = 'X2'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object Label7: TLabel
      Left = 381
      Top = 92
      Width = 18
      Height = 19
      Caption = 'X3'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object Label8: TLabel
      Left = 384
      Top = 115
      Width = 15
      Height = 19
      Caption = 'K:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object Label9: TLabel
      Left = 405
      Top = 17
      Width = 175
      Height = 13
      Caption = 'X1=1 then K:=X2; X1=0 then K:=X3'
    end
    object EditKey1: TLabeledEdit
      Left = 23
      Top = 32
      Width = 257
      Height = 21
      EditLabel.Width = 150
      EditLabel.Height = 13
      EditLabel.Caption = 'LFSR1 State (x^23 + x^5 + 1)'
      MaxLength = 23
      NumbersOnly = True
      TabOrder = 0
      OnChange = EditKey1Change
      OnKeyPress = EditKeyKeyPress
    end
    object EditKey2: TLabeledEdit
      Left = 23
      Top = 96
      Width = 257
      Height = 21
      EditLabel.Width = 150
      EditLabel.Height = 13
      EditLabel.Caption = 'LFSR2 State (x^31 + x^3 + 1)'
      MaxLength = 31
      NumbersOnly = True
      TabOrder = 1
      OnChange = EditKey1Change
      OnKeyPress = EditKeyKeyPress
    end
    object EditKey3: TLabeledEdit
      Left = 23
      Top = 160
      Width = 257
      Height = 21
      EditLabel.Width = 150
      EditLabel.Height = 13
      EditLabel.Caption = 'LFSR3 State (x^39 + x^4 + 1)'
      MaxLength = 39
      NumbersOnly = True
      TabOrder = 2
      OnChange = EditKey1Change
      OnKeyPress = EditKeyKeyPress
    end
    object ButtonGInit: TButton
      Left = 300
      Top = 30
      Width = 75
      Height = 25
      Caption = 'Initialize'
      Enabled = False
      TabOrder = 3
      OnClick = ButtonGInitClick
    end
    object ButtonGTick: TButton
      Left = 300
      Top = 61
      Width = 75
      Height = 25
      Caption = 'Tick'
      Enabled = False
      TabOrder = 4
      OnClick = ButtonGTickClick
    end
    object ButtonGProcess: TButton
      Left = 885
      Top = 1
      Width = 98
      Height = 208
      Align = alRight
      Caption = 'Process'
      Enabled = False
      Style = bsCommandLink
      TabOrder = 5
      OnClick = ButtonGProcessClick
    end
    object ButtonGenGeffe: TButton
      Left = 300
      Top = 92
      Width = 75
      Height = 22
      Caption = 'Autotick'
      Enabled = False
      TabOrder = 6
      OnClick = ButtonGenGeffeClick
    end
  end
  object PanelFile: TPanel
    Left = 8
    Top = 8
    Width = 984
    Height = 47
    TabOrder = 2
    object LabelFileName: TLabel
      Left = 120
      Top = 11
      Width = 35
      Height = 19
      Caption = 'File: '
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object ButtonOpenFile: TButton
      Left = 1
      Top = 1
      Width = 105
      Height = 45
      Align = alLeft
      Caption = 'Open file'
      Style = bsCommandLink
      TabOrder = 0
      OnClick = ButtonOpenFileClick
    end
  end
  object PanelRC4: TPanel
    Left = 567
    Top = 208
    Width = 425
    Height = 91
    TabOrder = 3
    object LabelKeyRC4: TLabel
      Left = 23
      Top = 59
      Width = 32
      Height = 16
      Caption = 'Value'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Tahoma'
      Font.Style = []
      ParentFont = False
    end
    object EditKeyRC4: TLabeledEdit
      Left = 23
      Top = 32
      Width = 32
      Height = 21
      EditLabel.Width = 50
      EditLabel.Height = 13
      EditLabel.Caption = 'RC4 U key'
      MaxLength = 3
      NumbersOnly = True
      TabOrder = 0
    end
    object ButtonInitRC4: TButton
      Left = 80
      Top = 30
      Width = 41
      Height = 25
      Caption = 'Add'
      TabOrder = 1
      OnClick = ButtonInitRC4Click
    end
    object ButtonDelRC4: TButton
      Left = 127
      Top = 30
      Width = 58
      Height = 25
      Caption = 'Delete'
      TabOrder = 2
      OnClick = ButtonDelRC4Click
    end
    object ButtonProcessRC4: TButton
      Left = 326
      Top = 1
      Width = 98
      Height = 89
      Align = alRight
      Caption = 'Process'
      Enabled = False
      Style = bsCommandLink
      TabOrder = 3
      OnClick = ButtonProcessRC4Click
    end
  end
  object PanelOutput: TPanel
    Left = 8
    Top = 61
    Width = 984
    Height = 140
    TabOrder = 4
    object Labelin: TLabel
      Left = 23
      Top = 13
      Width = 30
      Height = 13
      Caption = 'Input:'
    end
    object LabelKey: TLabel
      Left = 343
      Top = 13
      Width = 22
      Height = 13
      Caption = 'Key:'
    end
    object Labelout: TLabel
      Left = 667
      Top = 13
      Width = 38
      Height = 13
      Caption = 'Output:'
    end
    object Memo1: TMemo
      Left = 23
      Top = 32
      Width = 185
      Height = 89
      ScrollBars = ssVertical
      TabOrder = 0
    end
    object Memo2: TMemo
      Left = 343
      Top = 32
      Width = 185
      Height = 89
      ScrollBars = ssVertical
      TabOrder = 1
    end
    object Memo3: TMemo
      Left = 667
      Top = 32
      Width = 185
      Height = 89
      ScrollBars = ssVertical
      TabOrder = 2
    end
    object RadioGroup1: TRadioGroup
      Left = 214
      Top = 32
      Width = 111
      Height = 89
      Caption = 'Select view'
      Items.Strings = (
        'Binary'
        'Decimal'
        'Hexadecimal'
        'Text')
      TabOrder = 3
      OnClick = RadioGroup1Click
    end
    object RadioGroup2: TRadioGroup
      Left = 534
      Top = 32
      Width = 111
      Height = 89
      Caption = 'Select view'
      Items.Strings = (
        'Binary'
        'Decimal'
        'Hexadecimal'
        'Text')
      TabOrder = 4
      OnClick = RadioGroup2Click
    end
    object RadioGroup3: TRadioGroup
      Left = 858
      Top = 32
      Width = 111
      Height = 89
      Caption = 'Select view'
      Items.Strings = (
        'Binary'
        'Decimal'
        'Hexadecimal'
        'Text')
      TabOrder = 5
      OnClick = RadioGroup3Click
    end
  end
  object OpenDialogFile: TOpenDialog
    Left = 848
    Top = 8
  end
  object TimerGeffe: TTimer
    Enabled = False
    Interval = 1
    OnTimer = TimerGeffeTimer
    Left = 776
    Top = 13
  end
end
