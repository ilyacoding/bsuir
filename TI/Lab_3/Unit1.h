//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Dialogs.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TPanel *PanelLFSR;
	TLabeledEdit *EditKey;
	TButton *ButtonInitLFSR1;
	TButton *ButtonTakt;
	TOpenDialog *OpenDialogFile;
	TButton *ButtonOpenFile;
	TLabel *LabelFileName;
	TButton *ButtonEncrypt;
	TPanel *PanelGeffe;
	TLabeledEdit *EditKey1;
	TLabeledEdit *EditKey2;
	TLabeledEdit *EditKey3;
	TLabel *LabelGLFSR1;
	TLabel *LabelGLFSR2;
	TLabel *LabelLFSR1;
	TLabel *LabelGLFSR3;
	TButton *ButtonGInit;
	TButton *ButtonGTick;
	TPanel *PanelFile;
	TButton *ButtonGProcess;
	TButton *ButtonGenGeffe;
	TTimer *TimerGeffe;
	TLabel *LabelGeffeKey;
	TLabel *LabelX2;
	TLabel *LabelX1;
	TLabel *LabelX3;
	TPanel *PanelRC4;
	TPanel *PanelOutput;
	TMemo *Memo1;
	TLabel *Labelin;
	TMemo *Memo2;
	TLabel *LabelKey;
	TMemo *Memo3;
	TLabel *Labelout;
	TRadioGroup *RadioGroup1;
	TRadioGroup *RadioGroup2;
	TRadioGroup *RadioGroup3;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *Label3;
	TLabel *Label4;
	TLabel *Label5;
	TLabel *Label6;
	TLabel *Label7;
	TLabel *Label8;
	TLabel *Label9;
	TLabeledEdit *EditKeyRC4;
	TLabel *LabelKeyRC4;
	TButton *ButtonInitRC4;
	TButton *ButtonDelRC4;
	TButton *ButtonProcessRC4;
	void __fastcall EditKeyKeyPress(TObject *Sender, System::WideChar &Key);
	void __fastcall ButtonInitLFSR1Click(TObject *Sender);
	void __fastcall ButtonTaktClick(TObject *Sender);
	void __fastcall ButtonOpenFileClick(TObject *Sender);
	void __fastcall ButtonEncryptClick(TObject *Sender);
	void __fastcall EditKeyChange(TObject *Sender);
	void __fastcall EditKey1Change(TObject *Sender);
	void __fastcall ButtonGInitClick(TObject *Sender);
	void __fastcall ButtonGTickClick(TObject *Sender);
	void __fastcall ButtonGProcessClick(TObject *Sender);
	void __fastcall TimerGeffeTimer(TObject *Sender);
	void __fastcall ButtonGenGeffeClick(TObject *Sender);
	void __fastcall RadioGroup1Click(TObject *Sender);
	void __fastcall RadioGroup2Click(TObject *Sender);
	void __fastcall RadioGroup3Click(TObject *Sender);
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall ButtonInitRC4Click(TObject *Sender);
	void __fastcall ButtonDelRC4Click(TObject *Sender);
	void __fastcall ButtonProcessRC4Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
