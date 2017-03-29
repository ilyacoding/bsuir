//---------------------------------------------------------------------------

#ifndef UnitCreateKeyH
#define UnitCreateKeyH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.WinXCtrls.hpp>
#include <Vcl.ComCtrls.hpp>
//---------------------------------------------------------------------------
class TFormCreateKey : public TForm
{
__published:	// IDE-managed Components
	TEdit *EditKey;
	TLabel *LabelKey;
	TButton *ButtonDelete;
	TButton *ButtonSaveKey;
	TButton *ButtonRand;
	void __fastcall EditKeyKeyPress(TObject *Sender, System::WideChar &Key);
	void __fastcall EditKeyChange(TObject *Sender);
	void __fastcall ButtonSaveKeyClick(TObject *Sender);
	void __fastcall ButtonDeleteClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TFormCreateKey(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFormCreateKey *FormCreateKey;
//---------------------------------------------------------------------------
#endif
