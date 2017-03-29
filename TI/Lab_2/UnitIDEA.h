//---------------------------------------------------------------------------

#ifndef UnitIDEAH
#define UnitIDEAH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.WinXCtrls.hpp>
#include <Vcl.ComCtrls.hpp>
#include <Vcl.ToolWin.hpp>
#include <Vcl.Menus.hpp>
#include <Vcl.Dialogs.hpp>
#include <Vcl.Samples.Spin.hpp>
//---------------------------------------------------------------------------
class TFormIDEA : public TForm
{
__published:	// IDE-managed Components
	TMemo *MemoEncKey;
	TMemo *MemoEncBlock;
	TMemo *MemoDecKey;
	TMemo *MemoDecBlock;
	TMainMenu *MainMenu1;
	TMenuItem *N3;
	TMenuItem *File1;
	TMenuItem *About1;
	TMenuItem *N1;
	TMenuItem *Create1;
	TMenuItem *Load1;
	TMenuItem *Select1;
	TMenuItem *N4;
	TMenuItem *N2;
	TMenuItem *N5;
	TEdit *EditKeyID;
	TLabel *LabelKey;
	TLabel *LabelKeyID;
	TToggleSwitch *ToggleSwitchKey;
	TOpenDialog *OpenDialogFile;
	TButton *ButtonSelectFile;
	TLabel *LabelFileName;
	TButton *ButtonEncrypt;
	TButton *ButtonDecrypt;
	TLabel *LabelNameExpKey;
	TLabel *LabelNameInvKey;
	TLabel *LabelEncBlock;
	TLabel *LabelDecBlock;
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall Create1Click(TObject *Sender);
	void __fastcall EditKeyIDChange(TObject *Sender);
	void __fastcall ToggleSwitchKeyClick(TObject *Sender);
	void __fastcall ButtonSelectFileClick(TObject *Sender);
	void __fastcall ButtonEncryptClick(TObject *Sender);
	void __fastcall ButtonDecryptClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TFormIDEA(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormIDEA *FormIDEA;
//---------------------------------------------------------------------------
#endif
