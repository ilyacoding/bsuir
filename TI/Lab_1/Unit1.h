//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <FMX.Controls.hpp>
#include <FMX.Forms.hpp>
#include <FMX.Controls.Presentation.hpp>
#include <FMX.Edit.hpp>
#include <FMX.StdCtrls.hpp>
#include <FMX.Types.hpp>
#include <FMX.Memo.hpp>
#include <FMX.ScrollBox.hpp>
#include <FMX.Dialogs.hpp>
#include <FMX.Grid.hpp>
#include <FMX.Grid.Style.hpp>
#include <System.Rtti.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TEdit *EditK;
	TMemo *MemoM;
	TToolBar *ToolBarCentral;
	TMemo *MemoC;
	TButton *ButtonLoadM;
	TButton *ButtonSaveM;
	TButton *ButtonSaveC;
	TButton *ButtonLoadC;
	TOpenDialog *OpenDialog1;
	TSaveDialog *SaveDialog1;
	TButton *ButtonDecrypt;
	TButton *ButtonCrypt;
	TButton *ButtonTest;
	TMemo *MemoK;
	TMemo *MemoS;
	TSwitch *SwitchStat;
	void __fastcall ButtonCryptClick(TObject *Sender);
	void __fastcall ButtonDecryptClick(TObject *Sender);
	void __fastcall FormResize(TObject *Sender);
	void __fastcall ButtonLoadMClick(TObject *Sender);
	void __fastcall ButtonLoadCClick(TObject *Sender);
	void __fastcall ButtonSaveMClick(TObject *Sender);
	void __fastcall ButtonSaveCClick(TObject *Sender);
	void __fastcall ButtonTestClick(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall FormCloseQuery(TObject *Sender, bool &CanClose);
	void __fastcall ButtonShowStatClick(TObject *Sender);
	void __fastcall SwitchStatSwitch(TObject *Sender);
	void __fastcall EditKKeyDown(TObject *Sender, WORD &Key, System::WideChar &KeyChar,
          TShiftState Shift);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
