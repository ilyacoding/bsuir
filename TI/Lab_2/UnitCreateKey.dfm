object FormCreateKey: TFormCreateKey
  Left = 0
  Top = 0
  Caption = 'Generating a key'
  ClientHeight = 206
  ClientWidth = 558
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  DesignSize = (
    558
    206)
  PixelsPerInch = 96
  TextHeight = 13
  object LabelKey: TLabel
    Left = 16
    Top = 16
    Width = 6
    Height = 23
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object EditKey: TEdit
    Left = 245
    Top = 72
    Width = 41
    Height = 47
    Anchors = [akTop]
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -32
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnChange = EditKeyChange
    OnKeyPress = EditKeyKeyPress
  end
  object ButtonDelete: TButton
    Left = 517
    Top = 8
    Width = 33
    Height = 47
    Anchors = [akTop, akRight]
    Caption = '<-'
    TabOrder = 1
    OnClick = ButtonDeleteClick
  end
  object ButtonSaveKey: TButton
    Left = 213
    Top = 143
    Width = 105
    Height = 41
    Anchors = [akBottom]
    Caption = 'Save Key'
    Style = bsCommandLink
    TabOrder = 2
    OnClick = ButtonSaveKeyClick
  end
  object ButtonRand: TButton
    Left = 308
    Top = 72
    Width = 197
    Height = 47
    Caption = 'Generate random key'
    Enabled = False
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    Style = bsCommandLink
    TabOrder = 3
  end
end
