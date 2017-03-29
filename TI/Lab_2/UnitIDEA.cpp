//---------------------------------------------------------------------------
#include "uInc.h"

#include <vcl.h>
#pragma hdrstop

#include "UnitIDEA.h"
#include "UnitCreateKey.h"

//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFormIDEA *FormIDEA;

//---------------------------------------------------------------------------
__fastcall TFormIDEA::TFormIDEA(TComponent* Owner)
	: TForm(Owner)
{
}

unsigned __int16 Mul(unsigned __int16 x, unsigned __int16 y)
{
	unsigned __int64 a = ((x == 0) ? (1 << 16) : x);
	unsigned __int64 b = ((y == 0) ? (1 << 16) : y);
	toInt32.int64_val = (a * b) % ((1 << 16) + 1);
	toShort.int32_val = toInt32.int32_val[0];
	return toShort.int16_val[0];
}

unsigned __int16 Add(unsigned __int16 x, unsigned __int16 y)
{
	unsigned __int64 a = x;
	unsigned __int64 b = y;
	toInt32.int64_val = (a + b) % (1 << 16);
	toShort.int32_val = toInt32.int32_val[0];
	return toShort.int16_val[0];
}

unsigned __int16 AddInv(unsigned __int16 x)
{
	return (1 << 16) - x;
}

unsigned __int32 gcd(unsigned __int32 a, unsigned __int32 b, unsigned __int32 & x, unsigned __int32 & y) {
	if (a == 0) {
		x = 0; y = 1;
		return b;
	}
	unsigned __int32 x1, y1;
	unsigned __int32 d = gcd (b % a, a, x1, y1);
	x = y1 - (b / a) * x1;
	y = x1;
	return d;
}

unsigned __int16 MulInv(unsigned __int32 a)
{
	unsigned __int32 x, y;
	unsigned __int32 m = (1 << 16) + 1;
	unsigned __int32 g = gcd(a, m, x, y);
	x = (x + m) % m;
	return x;
}

typedef struct {
	unsigned __int16 EncKey[52], DecKey[52];
} idea_keys;

string UnicodeToString(UnicodeString us) {
	string result = AnsiString(us.t_str()).c_str();
	return result;
}

// Data

unsigned __int16 Data[40];
int KeyID = -1;
byte ukey[16];
idea_keys key;
unsigned __int64 filesize = 0;

// Data

bool IsFileExist(string filePath)
{
	bool isExist = false;
	std::ifstream fin(filePath.c_str());

	if(fin.is_open())
		isExist = true;

	fin.close();
	return isExist;
}

void PrintKeyIDEA()
{
	FormIDEA->LabelKey->Caption = "Key: ";
	for (int i = 0; i < 16; i++)
	{
		unsigned __int16 x = ukey[i];
		FormIDEA->LabelKey->Caption = FormIDEA->LabelKey->Caption + " " + UnicodeString(ToHex(x).c_str()[2]) + UnicodeString(ToHex(x).c_str()[3]);
	}
}

void ideaExpandKey(byte const *userkey, unsigned __int16 *EK)
{
	int i, j;
	for (j = 0; j < 8; j++) {
		EK[j] = (userkey[0] << 8) + userkey[1];
		userkey += 2;
	}

	for (i = 0; j < 52; j++) {
		i++;
		EK[i + 7] = EK[i & 7] << 9 | EK[i + 1 & 7] >> 7;
		EK += i & 8;
		i &= 7;
	}
}

void ideaInvertKey(unsigned __int16 *EK, unsigned __int16 *DK)
{
	// (1)
	for (int i = 0; i < 10; i++)
		DK[i * 6] = MulInv(EK[48 - i * 6]);

	// (2)
	for (int i = 1; i < 8; i++)
		DK[i * 6 + 1] = AddInv(EK[48 - i * 6 + 2]);

	// (2) (3)
	for (int i = 1; i < 8; i++)
		DK[i * 6 + 2] = AddInv(EK[48 - i * 6 + 1]);

	// (2) (3)
	DK[0 * 6 + 1] = AddInv(EK[48 - 0 * 6 + 1]);
	DK[0 * 6 + 2] = AddInv(EK[48 - 0 * 6 + 2]);
	DK[48 - 0 * 6 + 1] = AddInv(EK[0 * 6 + 1]);
	DK[48 - 0 * 6 + 2] = AddInv(EK[0 * 6 + 2]);

	// (4)
	for (int i = 0; i < 10; i++)
		DK[i * 6 + 3] = MulInv(EK[48 - i * 6 + 3]);

	// (5)
	for (int i = 1; i < 9; i++)
		DK[(i - 1) * 6 + 4] = (EK[48 - i * 6 + 4]);

	// (6)
	for (int i = 1; i < 9; i++)
		DK[(i - 1) * 6 + 5] = (EK[48 - i * 6 + 5]);
}

void GenKeys(idea_keys *ik, byte *key)
{
	for (int i = 0; i < 52; i++) {
		ik->DecKey[i] = 0;
		ik->EncKey[i] = 0;
	}

	ideaExpandKey(key, ik->EncKey); 		// Gen EK
	ideaInvertKey(ik->EncKey, ik->DecKey);  // Gen DK
}



void Round(unsigned __int16 Key[52], int delta)
{
	unsigned __int32 deltaD = (delta - 1) * 4 + 3;
	unsigned __int32 deltaK = (delta - 1) * 6 - 1;

	unsigned __int16 A = Mul(Data[1 + deltaD - 4], Key[1 + deltaK]);
	unsigned __int16 B = Add(Data[2 + deltaD - 4], Key[2 + deltaK]);
	unsigned __int16 C = Add(Data[3 + deltaD - 4], Key[3 + deltaK]);
	unsigned __int16 D = Mul(Data[4 + deltaD - 4], Key[4 + deltaK]);
	unsigned __int16 E = A ^ C;
	unsigned __int16 F = B ^ D;

	Data[1 + deltaD] = A^(Mul(Add(F, Mul(E, Key[5 + deltaK])), Key[6 + deltaK]));
	Data[2 + deltaD] = C^(Mul(Add(F, Mul(E, Key[5 + deltaK])), Key[6 + deltaK]));
	Data[3 + deltaD] = B^(Add(Mul(E, Key[5 + deltaK]), Mul(Add(F, Mul(E, Key[5 + deltaK])), Key[6 + deltaK])));
	Data[4 + deltaD] = D^(Add(Mul(E, Key[5 + deltaK]), Mul(Add(F, Mul(E, Key[5 + deltaK])), Key[6 + deltaK])));
}

void FinalRound(unsigned __int16 Key[52])
{
	int delta = 9;
	unsigned __int32 deltaD = (delta - 1) * 4 + 3;
	unsigned __int32 deltaK = (delta - 1) * 6 - 1;

	Data[1 + deltaD] = Mul(Data[1 + deltaD - 4], Key[1 + deltaK]);
	Data[2 + deltaD] = Add(Data[3 + deltaD - 4], Key[2 + deltaK]);
	Data[3 + deltaD] = Add(Data[2 + deltaD - 4], Key[3 + deltaK]);
	Data[4 + deltaD] = Mul(Data[4 + deltaD - 4], Key[4 + deltaK]);
}

void IDEA_Cipher(unsigned __int16 Key[52], unsigned __int16 D[4])
{
	for (int i = 0; i < 4; i++)  // Fill first 4 values
		Data[i] = D[i];
	for (int i = 4; i < 40; i++)
		Data[i] = 0;

	for (int i = 1; i <= 8; i++) // 1..8
		Round(Key, i);

	FinalRound(Key);             // 8.5
}

void ProcessEncrypt()
{

	unsigned __int16 block[4];
	unsigned __int16 dblock[4];
	char file_data[8];

	string FilePath = UnicodeToString(FormIDEA->OpenDialogFile->FileName);
	string FileExt = FilePath.substr(FilePath.find_last_of("."));

	// Open files
	ifstream f(FilePath.c_str(), ios::binary);
	ofstream df((FilePath + ".enc" + FileExt).c_str(), ios::binary);

	f.seekg(0, ios::end);
	unsigned __int32 sizef = f.tellg();
	filesize = sizef;
	unsigned __int32 it = sizef/8;
	f.seekg(0, ios::beg);

	//FormIDEA->Label6->Caption = ToStr(sizef).c_str();

	for (int j = 0; j < it; j++)
	{
		f.read((char*)file_data, sizeof file_data);

		for (int i = 0; i < 8; i+=2)
			block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

		IDEA_Cipher(key.EncKey, block);

		for (int i = 36; i < 40; i++)
			block[i - 36] = Data[i];

		for (int i = 0; i < 8; i++)
			file_data[i] = 0;

		for (int i = 0; i < 8; i+=2)
		{
			file_data[i + 1] = block[i/2] & 0xff;
			file_data[i] = (block[i/2] >> 8);
			//FormIDEA->Label2->Caption = ToStr(ToHex(file_data[i + 1])).c_str();
		}

		df.write((char*)file_data, 8);


		FormIDEA->MemoEncBlock->Lines->Clear();
		for (int i = 0; i < 40; i++)
		{
			string result = "[" + ToStr((i) / 4) + "]:  ";
			int j;
			for (j = i; (j < i + 4) && (j < 40); j++)
			{
				result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
			}
			i = j - 1;
			FormIDEA->MemoEncBlock->Lines->Add(result.c_str());
		}
	}

	unsigned __int16 ToDel = sizef - it * 8;

	// Pre-Ending 8 bytes ..cd ab ef 00 00 00 00 00..

	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	f.read((char*)file_data, ToDel);

	for (int i = 0; i < 8; i+=2)
		block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

	IDEA_Cipher(key.EncKey, block);

	for (int i = 36; i < 40; i++)
		block[i - 36] = Data[i];

	FormIDEA->MemoEncBlock->Lines->Clear();
	for (int i = 0; i < 40; i++)
	{
		string result = "[" + ToStr((i) / 4) + "]:  ";
		int j;
		for (j = i; (j < i + 4) && (j < 40); j++)
		{
			result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->MemoEncBlock->Lines->Add(result.c_str());
	}

	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	for (int i = 0; i < 8; i+=2)
	{
		file_data[i + 1] = block[i/2] & 0xff;
		file_data[i] = (block[i/2] >> 8);
		//FormIDEA->Label2->Caption = ToStr(ToHex(file_data[i + 1])).c_str();
	}

	df.write((char*)file_data, 8);

	// Ending 8 bytes ..00 00 00 00 00 00 00 10
	for (int i = 0; i < 7; i++)
		file_data[i] = 0;

	file_data[7] = (ToDel & 0xff);

	for (int i = 0; i < 8; i+=2)
		block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

	IDEA_Cipher(key.EncKey, block);

	for (int i = 36; i < 40; i++)
		block[i - 36] = Data[i];

	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	for (int i = 0; i < 8; i+=2)
	{
		file_data[i + 1] = block[i/2] & 0xff;
		file_data[i] = (block[i/2] >> 8);
		//FormIDEA->Label2->Caption = ToStr(ToHex(file_data[i + 1])).c_str();
	}

	df.write((char*)file_data, 8);

	// Closing files
	f.close();
	df.close();

	//PrintData();



	//for (int i = 36; i < 40; i++)
	//	block[i- 36] = Data[i];

	// block[0-3]
	//IDEA_Cipher(key.DecKey, block);

	/*FormIDEA->Memo2->Lines->Clear();
	for (int i = 0; i < 40; i++) {
		string result = "[" + ToStr((i) / 4) + "]:  ";
		int j;
		for (j = i; (j < i + 4) && (j < 40); j++) {
			result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->Memo2->Lines->Add(result.c_str());
	}

	*/

	//FormIDEA->Label1->Caption = ToStr(ToHex(MulInv(key.EncKey[42]))).c_str();

}

void ProcessDecrypt()
{

	unsigned __int16 block[4];
	unsigned __int16 dblock[4];
	char file_data[8];

	string FilePath = UnicodeToString(FormIDEA->OpenDialogFile->FileName);
	string FileExt = FilePath.substr(FilePath.find_last_of("."));

	// Open files
	ifstream f(FilePath.c_str(), ios::binary);
	ofstream df((FilePath + ".dec" + FileExt).c_str(), ios::binary);

	f.seekg(0, ios::end);
	int sizef = f.tellg();
	filesize = sizef;
	unsigned __int32 it = sizef/8;
	f.seekg(0, ios::beg);

	for (int j = 0; j < it - 2; j++)
	{
		f.read((char*)file_data, sizeof file_data);

		for (int i = 0; i < 8; i+=2)
			block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

		IDEA_Cipher(key.DecKey, block);

		for (int i = 36; i < 40; i++)
			block[i - 36] = Data[i];

		for (int i = 0; i < 8; i++)
			file_data[i] = 0;

		for (int i = 0; i < 8; i+=2)
		{
			file_data[i + 1] = block[i/2] & 0xff;
			file_data[i] = (block[i/2] >> 8);
		}

		df.write((char*)file_data, 8);


		FormIDEA->MemoDecBlock->Lines->Clear();
		for (int i = 0; i < 40; i++)
		{
			string result = "[" + ToStr((i) / 4) + "]:  ";
			int j;
			for (j = i; (j < i + 4) && (j < 40); j++)
			{
				result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
			}
			i = j - 1;
			FormIDEA->MemoDecBlock->Lines->Add(result.c_str());
		}
	}


	// Get Pre-Ending 8 bytes ..cd ab ef 00 00 00 00 00..

	char maybe_add[8];

	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	f.read((char*)file_data, 8);

	for (int i = 0; i < 8; i+=2)
		block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

	IDEA_Cipher(key.DecKey, block);

	for (int i = 36; i < 40; i++)
		block[i - 36] = Data[i];

	FormIDEA->MemoDecBlock->Lines->Clear();
	for (int i = 0; i < 40; i++)
	{
		string result = "[" + ToStr((i) / 4) + "]:  ";
		int j;
		for (j = i; (j < i + 4) && (j < 40); j++)
		{
			result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->MemoDecBlock->Lines->Add(result.c_str());
	}

	for (int i = 0; i < 8; i++)
		maybe_add[i] = 0;

	for (int i = 0; i < 8; i+=2)
	{
		maybe_add[i + 1] = block[i/2] & 0xff;
		maybe_add[i] = (block[i/2] >> 8);
	}

	// Get ending 8 bytes ..00 00 00 00 00 00 00 10
	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	f.read((char*)file_data, 8);

	for (int i = 0; i < 8; i+=2)
		block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

	IDEA_Cipher(key.DecKey, block);

	for (int i = 36; i < 40; i++)
		block[i - 36] = Data[i];

	unsigned __int32 ToAdd = block[3] % 9;

	df.write((char*)maybe_add, ToAdd);

	// Closing files
	f.close();
	df.close();
}

/*void ProcessDecrypt()
{

	unsigned __int16 block[4];
	unsigned __int16 dblock[4];

	char file_data[8];

	vector<byte> v;

	//string FilePath = AnsiString(FormIDEA->OpenDialogFile->FileName.t_str()).c_str();
	//string FilePath = "data.bin";
	string FilePath = UnicodeToString(FormIDEA->OpenDialogFile->FileName);

	//ofstream ofs((FilePath + ".enc.bin").c_str(), ios::binary | ios::out);
	//ofs.close();
	 //FormIDEA->OpenDialogFile->FileName.c_str()

	// Open files
	ifstream f(FilePath.c_str(), ios::binary | ios::in);


	f.seekg(0, ios::end);
	int CountBytes = f.tellg();
	f.seekg(0, ios::beg);


	f.read((byte*)file_data, sizeof file_data);

	for (int i = 0; i < 8; i+=2)
		block[i/2] = (file_data[i] << 8 ) | (file_data[i + 1] & 0xff);

	IDEA_Cipher(key.DecKey, block);

	for (int i = 36; i < 40; i++)
		block[i - 36] = Data[i];

	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	for (int i = 0; i < 8; i+=2) {
		unsigned __int8 l = LOBYTE(block[i/2]);
		unsigned __int8 h = HIBYTE(block[i/2]);
		file_data[i + 1] = h;
		file_data[i] = l;
		//df << file_data[i];
		//df << file_data[i + 1];
	//df.write((byte*)file_data, 2);
	}
	ofstream df((FilePath + ".DEC.bin").c_str(), ios::binary | ios::out);

	//FILE *df;



	df.write((byte*)file_data, 8);

	for (int i = 0; i < 8; i++)
		file_data[i] = 0;

	//PrintData();

	FormIDEA->Memo1->Lines->Clear();
	for (int i = 0; i < 40; i++) {
		string result = "[" + ToStr((i) / 4) + "]:  ";
		int j;
		for (j = i; (j < i + 4) && (j < 40); j++) {
			result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->Memo1->Lines->Add(result.c_str());
	}

	for (int i = 36; i < 40; i++)
		block[i- 36] = Data[i];

	// block[0-3]
	IDEA_Cipher(key.EncKey, block);

	FormIDEA->Memo2->Lines->Clear();
	for (int i = 0; i < 40; i++) {
		string result = "[" + ToStr((i) / 4) + "]:  ";
		int j;
		for (j = i; (j < i + 4) && (j < 40); j++) {
			result = result + "(" + ToStr((((j+1) % 4 == 0) ? 4 : (j+1) % 4)) + ") " + ToStr(ToHex(Data[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->Memo2->Lines->Add(result.c_str());
	}

	FormIDEA->MemoEncKey->Lines->Clear();
	for (int i = 0; i < 52; i++) {
		string result = "[" + ToStr((i + 7) / 6) + "]:  ";
		int j;
		for (j = i; (j < i + 6) && (j < 52); j++) {
			result = result + "(" + ToStr((((j+1) % 6 == 0) ? 6 : (j+1) % 6)) + ") " + ToStr(ToHex(key.EncKey[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->MemoEncKey->Lines->Add(result.c_str());
	}

	FormIDEA->MemoDecKey->Lines->Clear();
	for (int i = 0; i < 52; i++) {
		string result = "[" + ToStr((i + 7) / 6) + "]:  ";
		int j;
		for (j = i; (j < i + 6) && (j < 52); j++) {
			result = result + "(" + ToStr((((j+1) % 6 == 0) ? 6 : (j+1) % 6)) + ") " + ToStr(ToHex(key.DecKey[j])) + "  ";
		}
		i = j - 1;
		FormIDEA->MemoDecKey->Lines->Add(result.c_str());
	}

	FormIDEA->Label1->Caption = ToStr(ToHex(MulInv(key.EncKey[42]))).c_str();
	FormIDEA->Label2->Caption = ToStr(ToHex(key.EncKey[42])).c_str();
}*/

//---------------------------------------------------------------------------
void __fastcall TFormIDEA::FormCreate(TObject *Sender)
{
	//char ukey[16];
	//string FileName = "test.bin";

	//ofstream fout(FileName.c_str(), ios::binary | ios::out);
	//fout.write((char*)ukey, sizeof ukey);
	//fout.close();

	LabelKey->Caption = "Key: not found.";
}
//---------------------------------------------------------------------------

void __fastcall TFormIDEA::Create1Click(TObject *Sender)
{
    FormCreateKey->Show();
}
//---------------------------------------------------------------------------

void __fastcall TFormIDEA::EditKeyIDChange(TObject *Sender)
{
	if (EditKeyID->Text.Length() > 0) {
		KeyID = EditKeyID->Text.ToInt();
		string FilePath = "keys/key" + ToStr(KeyID) + ".bin";
		if (IsFileExist(FilePath)) {
			ifstream fin(FilePath.c_str(), ios::binary | ios::in);
			fin.read((byte*)ukey, sizeof ukey);
			fin.close();
			PrintKeyIDEA();
		} else {
			KeyID = -1;
		}
	} else {
		KeyID = -1;
	}

	if (KeyID == -1) {
		LabelKey->Caption = "Key: not found.";
	}
}
//---------------------------------------------------------------------------

void __fastcall TFormIDEA::ToggleSwitchKeyClick(TObject *Sender)
{
	EditKeyID->Enabled = ToggleSwitchKey->State;
	ButtonSelectFile->Enabled = !ToggleSwitchKey->State;
	ButtonDecrypt->Enabled = !ToggleSwitchKey->State;
    ButtonEncrypt->Enabled = !ToggleSwitchKey->State;
	if (!ToggleSwitchKey->State) {
		string FilePath = "keys/key" + ToStr(KeyID) + ".bin";
		if (IsFileExist(FilePath)) {
			UnicodeString msg = "Key selected.";
			UnicodeString txt = UnicodeString("Shown key was selected.");
			Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONASTERISK);
			GenKeys(&key, ukey);

			FormIDEA->MemoEncKey->Lines->Clear();
			for (int i = 0; i < 52; i++) {
				string result = "[" + ToStr((i + 7) / 6) + "]:  ";
				int j;
				for (j = i; (j < i + 6) && (j < 52); j++)
					result = result + "(" + ToStr((((j+1) % 6 == 0) ? 6 : (j+1) % 6)) + ") " + ToStr(ToHex(key.EncKey[j])) + "  ";

				i = j - 1;
				FormIDEA->MemoEncKey->Lines->Add(result.c_str());
			}

			FormIDEA->MemoDecKey->Lines->Clear();
			for (int i = 0; i < 52; i++) {
				string result = "[" + ToStr((i + 7) / 6) + "]:  ";
				int j;
				for (j = i; (j < i + 6) && (j < 52); j++)
					result = result + "(" + ToStr((((j+1) % 6 == 0) ? 6 : (j+1) % 6)) + ") " + ToStr(ToHex(key.DecKey[j])) + "  ";

				i = j - 1;
				FormIDEA->MemoDecKey->Lines->Add(result.c_str());
			}
		} else {
			ToggleSwitchKey->State = true;
			EditKeyID->Enabled = ToggleSwitchKey->State;
			UnicodeString msg = "No such key.";
			UnicodeString txt = UnicodeString("Please provide a valide key.");
			Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONERROR);
        }
	}
}
//---------------------------------------------------------------------------

void __fastcall TFormIDEA::ButtonSelectFileClick(TObject *Sender)
{
	OpenDialogFile->Execute();
	if (OpenDialogFile->FileName.Length() > 0) {
		UnicodeString msg = "File selected.";
		UnicodeString txt = UnicodeString("File that you chosen was selected.");
		Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONASTERISK);
	}
    LabelFileName->Caption = "File: " + OpenDialogFile->FileName;
}
//---------------------------------------------------------------------------

void __fastcall TFormIDEA::ButtonEncryptClick(TObject *Sender)
{
	if (OpenDialogFile->FileName.Length() < 3) {
		UnicodeString msg = "File NOT selected.";
		UnicodeString txt = UnicodeString("Please, select file.");
		Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONERROR);
		return;
	}
	ProcessEncrypt();
}
//---------------------------------------------------------------------------

void __fastcall TFormIDEA::ButtonDecryptClick(TObject *Sender)
{
	if (OpenDialogFile->FileName.Length() < 3) {
		UnicodeString msg = "File NOT selected.";
		UnicodeString txt = UnicodeString("Please, select file.");
		Application->MessageBox(txt.c_str(), msg.c_str(), MB_OK | MB_ICONERROR);
		return;
	}
	ProcessDecrypt();
}
//---------------------------------------------------------------------------

