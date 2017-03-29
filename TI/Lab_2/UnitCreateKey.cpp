//---------------------------------------------------------------------------

#include "uInc.h"
#include <vcl.h>
#pragma hdrstop

#include "UnitCreateKey.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFormCreateKey *FormCreateKey;
//---------------------------------------------------------------------------
char ukey[16];
int KeySize = 0;
//---------------------------------------------------------------------------
__fastcall TFormCreateKey::TFormCreateKey(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
bool IsFileExist(string filePath)
{
	bool isExist = false;
	std::ifstream fin(filePath.c_str());

	if(fin.is_open())
		isExist = true;

	fin.close();
	return isExist;
}
//---------------------------------------------------------------------------
void __fastcall TFormCreateKey::EditKeyKeyPress(TObject *Sender, System::WideChar &Key)

{
	if (Key == 8)
		return;

	if (Key == 13)
		return;

	if (EditKey->Text.Length() > 1)
		Key = 0;

	if (((Key >= 'a') && (Key <= 'f')) || ((Key >= '0') && (Key <= '9')))
		return;
	else
		Key = 0;
}
//---------------------------------------------------------------------------
void PrintKey()
{
	FormCreateKey->LabelKey->Caption = "Key: ";
	for (int i = 0; i < KeySize; i++)
	{
		unsigned __int16 x = ukey[i];
		FormCreateKey->LabelKey->Caption = FormCreateKey->LabelKey->Caption + " " + UnicodeString(ToHex(x).c_str()[2]) + UnicodeString(ToHex(x).c_str()[3]);
	}
}

void __fastcall TFormCreateKey::EditKeyChange(TObject *Sender)
{
	if (KeySize == 16)
		return;

	if (EditKey->Text.Length() == 2) {
		Sleep(100);
		AnsiString str = EditKey->Text;
		std::string s(str.c_str());
		ukey[KeySize++] = ToDec(str);
		EditKey->Text = "";
		PrintKey();
	}

	//byte XX[8], YY[8], ZZ[8];
	//uint32_t long_block[10]; /* 5 blocks */
	/*
	byte x[16];
	int k = 1;
	for (int i = 0; i < 16; i++) {
		if (i % 2 == 0)
			x[i] = 0;
		else
			x[i] = k++;
	}

	ofstream fout("key.bin", ios::binary | ios::out);
	fout.write((byte*)x, sizeof x);
	fout.close();

	for (int i = 0; i < 16; i++) {
		x[i] = 0;
	}  */
}
//---------------------------------------------------------------------------
void __fastcall TFormCreateKey::ButtonSaveKeyClick(TObject *Sender)
{
	if (KeySize != 16) {
		UnicodeString msg = "Saving a key.";
		UnicodeString txt = UnicodeString("Key must be 16 bytes. " + UnicodeString(16 - KeySize) + " remaining.");
		Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONWARNING);
		return;
	}

	int FileID = 0;
	while (IsFileExist("keys/key" + ToStr(FileID) + ".bin")) FileID++;
	string FileName = ("keys/key" + ToStr(FileID) + ".bin");
	ofstream fout(FileName.c_str(), ios::binary | ios::out);
	fout.write((byte*)ukey, sizeof ukey);
	fout.close();

	UnicodeString msg = "Key successfully generated.";
	UnicodeString txt = UnicodeString("Your key is located at 'keys/key" + UnicodeString(ToStr(FileID).c_str()) + ".bin'");
	Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONASTERISK);
}
//---------------------------------------------------------------------------
void __fastcall TFormCreateKey::ButtonDeleteClick(TObject *Sender)
{
	if (KeySize > 0)
		KeySize--;
	PrintKey();
}
//---------------------------------------------------------------------------
