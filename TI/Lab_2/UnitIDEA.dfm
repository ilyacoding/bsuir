object FormIDEA: TFormIDEA
  Left = 0
  Top = 0
  Caption = 'IDEA - International Data Encryption Algorithm'
  ClientHeight = 524
  ClientWidth = 858
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object LabelKey: TLabel
    Left = 8
    Top = 48
    Width = 164
    Height = 29
    Caption = 'Key: not found.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -24
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object LabelKeyID: TLabel
    Left = 14
    Top = 11
    Width = 106
    Height = 16
    Caption = 'keys/key         .bin'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object LabelFileName: TLabel
    Left = 8
    Top = 96
    Width = 7
    Height = 25
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object LabelNameExpKey: TLabel
    Left = 110
    Top = 159
    Width = 130
    Height = 25
    Caption = 'Expanded key'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object LabelNameInvKey: TLabel
    Left = 110
    Top = 343
    Width = 117
    Height = 25
    Caption = 'Inverted key'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object LabelEncBlock: TLabel
    Left = 511
    Top = 159
    Width = 192
    Height = 25
    Caption = 'Last encrypted block'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object LabelDecBlock: TLabel
    Left = 511
    Top = 343
    Width = 192
    Height = 25
    Caption = 'Last decrypted block'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object MemoEncKey: TMemo
    Left = 8
    Top = 190
    Width = 337
    Height = 147
    DoubleBuffered = True
    ParentDoubleBuffered = False
    ReadOnly = True
    TabOrder = 0
  end
  object MemoEncBlock: TMemo
    Left = 488
    Top = 190
    Width = 241
    Height = 147
    DoubleBuffered = True
    ParentDoubleBuffered = False
    ReadOnly = True
    TabOrder = 1
  end
  object MemoDecKey: TMemo
    Left = 8
    Top = 369
    Width = 337
    Height = 147
    DoubleBuffered = True
    ParentDoubleBuffered = False
    ReadOnly = True
    TabOrder = 2
  end
  object MemoDecBlock: TMemo
    Left = 488
    Top = 369
    Width = 241
    Height = 147
    DoubleBuffered = True
    ParentDoubleBuffered = False
    ReadOnly = True
    TabOrder = 3
  end
  object EditKeyID: TEdit
    Left = 64
    Top = 8
    Width = 33
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    MaxLength = 3
    NumbersOnly = True
    ParentFont = False
    TabOrder = 4
    OnChange = EditKeyIDChange
  end
  object ToggleSwitchKey: TToggleSwitch
    Left = 126
    Top = 8
    Width = 72
    Height = 20
    State = tssOn
    TabOrder = 5
    OnClick = ToggleSwitchKeyClick
  end
  object ButtonSelectFile: TButton
    Left = 368
    Top = 126
    Width = 113
    Height = 41
    Caption = 'Select file'
    Enabled = False
    Style = bsCommandLink
    TabOrder = 6
    OnClick = ButtonSelectFileClick
  end
  object ButtonEncrypt: TButton
    Left = 735
    Top = 248
    Width = 115
    Height = 41
    Caption = 'Encrypt'
    Style = bsCommandLink
    TabOrder = 7
    OnClick = ButtonEncryptClick
  end
  object ButtonDecrypt: TButton
    Left = 735
    Top = 424
    Width = 115
    Height = 41
    Caption = 'Decrypt'
    Style = bsCommandLink
    TabOrder = 8
    OnClick = ButtonDecryptClick
  end
  object MainMenu1: TMainMenu
    Left = 792
    Top = 8
    object File1: TMenuItem
      Caption = 'File'
      object Select1: TMenuItem
        Caption = 'Load'
      end
    end
    object N1: TMenuItem
      Caption = '-'
    end
    object N3: TMenuItem
      Caption = 'Key'
      object Create1: TMenuItem
        Caption = 'Create'
        OnClick = Create1Click
      end
      object Load1: TMenuItem
        Caption = 'Load'
      end
    end
    object N4: TMenuItem
      Caption = '-'
    end
    object N5: TMenuItem
      Caption = 'View'
    end
    object N2: TMenuItem
      Caption = '-'
    end
    object About1: TMenuItem
      Caption = 'About'
    end
  end
  object OpenDialogFile: TOpenDialog
    Left = 720
    Top = 8
  end
end
