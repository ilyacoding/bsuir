object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'CheckSyntax of Pascal'
  ClientHeight = 345
  ClientWidth = 505
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 220
    Height = 13
    Caption = 'Check type defining and using vars with index'
  end
  object Edit1: TEdit
    Left = 8
    Top = 27
    Width = 489
    Height = 21
    TabOrder = 0
    Text = 
      'Type _Matrix2 = array[1..10,1..29] of array[1..10,1..29] of inte' +
      'ger;'
    OnChange = Edit1Change
  end
  object ProgressBar1: TProgressBar
    Left = 8
    Top = 54
    Width = 489
    Height = 17
    TabOrder = 1
  end
  object Memo1: TMemo
    Left = 8
    Top = 77
    Width = 489
    Height = 260
    TabOrder = 2
  end
end
