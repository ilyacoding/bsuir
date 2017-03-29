//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "uInc.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

#define LFSR1_MAX   26
//#define LFSR1_Shift 16

#define LFSR2_MAX   34
//#define LFSR2_Shift 6

#define LFSR3_MAX   24
//#define LFSR3_Shift 3

//#define LFSR1_MAX   23
//#define LFSR1_Shift 5

//#define LFSR2_MAX   31
//#define LFSR2_Shift 3

//#define LFSR3_MAX   39
//#define LFSR3_Shift 4

using namespace std;

string UnicodeToString(UnicodeString us) {
	string result = AnsiString(us.t_str()).c_str();
	return result;
}

template <typename T>
string ToStr(T Data)
{
	 ostringstream ss;
	 ss << Data;
	 return ss.str();
}

template< typename T >
string ToHex( T i )
{
	stringstream stream;
	stream << std::setfill ('0') << std::setw(sizeof(T)*2) << std::hex << i;
	return stream.str();
}

template< typename T >
unsigned __int16 ToDec( T i )
{
	unsigned __int16 x;
	stringstream stream;
	stream << std::hex << i;
	stream >> std::hex >> x;
	return x;
}

template< typename T >
char ToChar( T i )
{
	char x;
	string input(i);
	stringstream stream(input);
	stream >> x;
	return (char)x;
}

class TLFSR1 {
	public:
		//byte bits[23];
		bitset<LFSR1_MAX> bits;
		//byte GetBit();
		bool GetBit();
};

bool TLFSR1::GetBit()
{
	bool retbit = bits[LFSR1_MAX - 1];
	/*for (int i = 0; i < 22; i++) {
		bits[i] = bits[i + 1];
	}*/
	bits <<= 1;
	//bits[0] = retbit ^ bits[LFSR1_Shift] ^ bits[];
	bits[0] = retbit ^ bits[8] ^ bits[7] ^ bits[1];
	return retbit;
}

class TLFSR2 {
	public:
		//byte bits[23];
		bitset<LFSR2_MAX> bits;
		//byte GetBit();
		bool GetBit();
};

bool TLFSR2::GetBit()
{
	bool retbit = bits[LFSR2_MAX - 1];
	/*for (int i = 0; i < 22; i++) {
		bits[i] = bits[i + 1];
	}*/
	bits <<= 1;
	bits[0] = retbit ^ bits[15] ^ bits[14] ^ bits[1];
	return retbit;
}

class TLFSR3 {
	public:
		//byte bits[23];
		bitset<LFSR3_MAX> bits;
		//byte GetBit();
		bool GetBit();
};

bool TLFSR3::GetBit()
{
	bool retbit = bits[LFSR3_MAX - 1];
	/*for (int i = 0; i < 22; i++) {
		bits[i] = bits[i + 1];
	}*/
	bits <<= 1;
	bits[0] = retbit ^ bits[4] ^ bits[3] ^ bits[1];
	return retbit;
}

TLFSR1 LFSR1;

TLFSR1 GLFSR1;
TLFSR2 GLFSR2;
TLFSR3 GLFSR3;

// In/Key/Out
vector<bitset<8> > bitsIN;
vector<bitset<8> > bitsKEY;
vector<bitset<8> > bitsOUT;
unsigned __int32 toprint = 8;
unsigned __int32 GeffeCount = 0;

vector <unsigned __int8> U;

void PrintU()
{
	Form1->LabelKeyRC4->Caption = "";
	for (int i = 0; i < U.size(); i++)
	{
		int x = (int)U[i];
		Form1->LabelKeyRC4->Caption = Form1->LabelKeyRC4->Caption + (ToStr(x) + " ").c_str();
	}
}

void OutputClear()
{
	bitsIN.clear();
	bitsKEY.clear();
	bitsOUT.clear();
	Form1->Memo1->Lines->Clear();
	Form1->Memo2->Lines->Clear();
	Form1->Memo3->Lines->Clear();
	Form1->Label1->Caption = "";
	Form1->Label2->Caption = "";
	Form1->Label3->Caption = "";
	Form1->Label4->Caption = "";
	GeffeCount = 0;
}


void PrintGLFSR()
{
	Form1->LabelGLFSR1->Caption = GLFSR1.bits.to_string<char, std::string::traits_type,std::string::allocator_type >().c_str();
	Form1->LabelGLFSR2->Caption = GLFSR2.bits.to_string<char, std::string::traits_type,std::string::allocator_type >().c_str();
	Form1->LabelGLFSR3->Caption = GLFSR3.bits.to_string<char, std::string::traits_type,std::string::allocator_type >().c_str();
}

void AddToGeffeKey(bool a)
{
	if (a)
		Form1->LabelGeffeKey->Caption = "Key: 1";
	else
		Form1->LabelGeffeKey->Caption = "Key: 0";
}

bool GetGeffeBit()
{
	bool x1 = GLFSR1.GetBit();
	bool x2 = GLFSR2.GetBit();
	bool x3 = GLFSR3.GetBit();

	if (GeffeCount < toprint*8) {
		if (x1)
			Form1->Label1->Caption = Form1->Label1->Caption + "1";
		else
			Form1->Label1->Caption = Form1->Label1->Caption + "0";
		if (x2)
			Form1->Label2->Caption = Form1->Label2->Caption + "1";
		else
			Form1->Label2->Caption = Form1->Label2->Caption + "0";
		if (x3)
			Form1->Label3->Caption = Form1->Label3->Caption + "1";
		else
			Form1->Label3->Caption = Form1->Label3->Caption + "0";

		if ((x1 && x2) || (!x1 && x3))
			Form1->Label4->Caption = Form1->Label4->Caption + "1";
		else
			Form1->Label4->Caption = Form1->Label4->Caption + "0";

		GeffeCount++;
    }

	AddToGeffeKey((x1 && x2) || (!x1 && x3));


	return (x1 && x2) || (!x1 && x3);
}

void PrintLFSR1()
{
	Form1->LabelLFSR1->Caption = LFSR1.bits.to_string<char, std::string::traits_type,std::string::allocator_type >().c_str();
}



void PrintKey()
{
	LFSR1.GetBit();
	PrintLFSR1();
}


void EncryptLFSR1()
{
	char file_data[1];


	string FilePath = UnicodeToString(Form1->OpenDialogFile->FileName);
	string FileExt = FilePath.substr(FilePath.find_last_of("."));
	// Open files
	ifstream f(FilePath.c_str(), ios::binary);
	ofstream df((FilePath + ".enc[LFSR]" + FileExt).c_str(), ios::binary);

	f.seekg(0, ios::end);
	unsigned __int32 sizef = f.tellg();
	f.seekg(0, ios::beg);

	//FormIDEA->Label6->Caption = ToStr(sizef).c_str();

	for (int j = 0; j < sizef; j++)
	{
		f.read((char*)file_data, 1);
		bitset<8> file_bits(file_data[0]);
		bitset<8> key_bits;
		bitsIN.push_back(file_bits);

		for (int i = 7; i >= 0; i--)
		{
			bool bt = LFSR1.GetBit();
			if (bt) key_bits.set(i);
			file_bits[i] = file_bits[i] ^ bt;
			/*if (file_bits[i])
				output += "1";
			else
				output += "0";
			if (bt)
				key += "1";
			else
				key += "0";*/
		}

		bitsKEY.push_back(key_bits);
		bitsOUT.push_back(file_bits);
		// j = 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14
		// j >= 3
		// sizef = 15
		if ((j >= toprint) && (j < sizef - toprint))
		{
			bitsIN.pop_back();
			bitsOUT.pop_back();
			bitsKEY.pop_back();
		}

		file_data[0] = file_bits.to_ulong();
		df.write((char*)file_data, 1);
		PrintLFSR1();
	}
}

void EncryptGeffe()
{
	char file_data[1];

	Form1->LabelGeffeKey->Caption = "Key: ";

	string FilePath = UnicodeToString(Form1->OpenDialogFile->FileName);
	string FileExt = FilePath.substr(FilePath.find_last_of("."));
	// Open files
	ifstream f(FilePath.c_str(), ios::binary);
	ofstream df((FilePath + ".enc[Geffe]" + FileExt).c_str(), ios::binary);

	f.seekg(0, ios::end);
	unsigned __int32 sizef = f.tellg();
	f.seekg(0, ios::beg);

	for (int j = 0; j < sizef; j++)
	{
		f.read((char*)file_data, 1);
		bitset<8> file_bits(file_data[0]);
		bitset<8> key_bits;
		bitsIN.push_back(file_bits);

		for (int i = 7; i >= 0; i--)
		{
			bool bt = GetGeffeBit();
			if (bt) key_bits.set(i);
			file_bits[i] = file_bits[i] ^ bt;
		}

		bitsKEY.push_back(key_bits);
		bitsOUT.push_back(file_bits);
		if ((j >= toprint) && (j < sizef - toprint))
		{
			bitsIN.pop_back();
			bitsOUT.pop_back();
			bitsKEY.pop_back();
		}

		file_data[0] = file_bits.to_ulong();
		df.write((char*)file_data, 1);
		PrintGLFSR();
	}
}

void EncryptRC4()
{
	char file_data[1];
	int i = 0;

	// Generate S
	unsigned __int8 S[256];
	for (int i = 0; i <= 255; i++)
		S[i] = i;
	int j = 0;
	for (int i = 0; i < 256; i++)
	{
		j = (j + S[i] + U[i % U.size()]) % 256;
		char tmp = S[i];
		S[i] = S[j];
		S[j] = tmp;
	}
	// /Generate S

	string FilePath = UnicodeToString(Form1->OpenDialogFile->FileName);
	string FileExt = FilePath.substr(FilePath.find_last_of("."));
	// Open files
	ifstream f(FilePath.c_str(), ios::binary);
	ofstream df((FilePath + ".enc[RC4]" + FileExt).c_str(), ios::binary);

	f.seekg(0, ios::end);
	unsigned __int32 sizef = f.tellg();
	f.seekg(0, ios::beg);

	i = 0;
	j = 0;
	for (int k = 0; k < sizef; k++)
	{
		f.read((char*)file_data, 1);

		bitset<8> f_bitsIN(file_data[0]);
		bitsIN.push_back(f_bitsIN);

		i = (i + 1) % 256;
		j = (j + S[i]) % 256;
		char tmp = S[i];
		S[i] = S[j];
		S[j] = tmp;
		char K = S[(S[i] + S[j]) % 256];



		bitset<8> f_bitsKEY(K);
		bitsKEY.push_back(f_bitsKEY);

		file_data[0] = file_data[0] ^ K;

		bitset<8> f_bitsOUT(file_data[0]);
		bitsOUT.push_back(f_bitsOUT);

		if ((k >= toprint) && (k < sizef - toprint))
		{
			bitsIN.pop_back();
			bitsOUT.pop_back();
			bitsKEY.pop_back();
		}

		df.write((char*)file_data, 1);
		//PrintRC4();
	}
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner): TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::EditKeyKeyPress(TObject *Sender, System::WideChar &Key)
{
	if (Key != '0' && Key != '1' && Key != 8)
		Key = 0;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::ButtonInitLFSR1Click(TObject *Sender)
{
	string str = UnicodeToString(EditKey->Text);
	for (int i = 0; i < LFSR1_MAX; i++)
		switch(CharToBit(str[LFSR1_MAX - 1 - i]))
		{
			case 1:
				LFSR1.bits[i] = 1;
				break;
			case 0:
				LFSR1.bits[i] = 0;
				break;
			default:
				LFSR1.bits[i] = 0;
		}
	PrintLFSR1();
	ButtonTakt->Enabled = true;
		//
}
//---------------------------------------------------------------------------
void __fastcall TForm1::ButtonTaktClick(TObject *Sender)
{
	PrintKey();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonOpenFileClick(TObject *Sender)
{
	OpenDialogFile->Execute();
	if (OpenDialogFile->FileName.Length() > 5) {

		// Open files
		ifstream f(UnicodeToString(Form1->OpenDialogFile->FileName).c_str(), ios::binary);
		f.seekg(0, ios::end);
		int sizef = f.tellg();
		string type = "";
		f.seekg(0, ios::beg);
		if (sizef/1024 == 0)
		{
			type = "B";
		} else {
			type = "KB";
			sizef /= 1024;
		}

		UnicodeString str = "";
		int i = OpenDialogFile->FileName.Length();
		while (OpenDialogFile->FileName[i] != '\\') i--;
		for (int j = i + 1; j <= OpenDialogFile->FileName.Length(); j++)
			str += OpenDialogFile->FileName[j];
		LabelFileName->Caption = "File: " + str + " (" + (ToStr(sizef) + " " + type + ")").c_str();
		ButtonGProcess->Enabled = true;
		ButtonEncrypt->Enabled = true;
		ButtonProcessRC4->Enabled = true;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonEncryptClick(TObject *Sender)
{
	OutputClear();
	EncryptLFSR1();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::EditKeyChange(TObject *Sender)
{
	string str = UnicodeToString(EditKey->Text);
	if ((EditKey->Text.Length() < LFSR1_MAX) || (str.find("1") == string::npos))
		ButtonInitLFSR1->Enabled = false;
	else
		ButtonInitLFSR1->Enabled = true;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::EditKey1Change(TObject *Sender)
{
	string str[3];
	str[0] = UnicodeToString(EditKey1->Text);
	str[1] = UnicodeToString(EditKey2->Text);
	str[2] = UnicodeToString(EditKey3->Text);
	for (int i = 0; i < 3; i++)
		if (str[i].find("1") == string::npos) {
			ButtonGInit->Enabled = false;
			return;
		}
	if ((EditKey1->Text.Length() < LFSR1_MAX) || (EditKey2->Text.Length() < LFSR2_MAX) || (EditKey3->Text.Length() < LFSR3_MAX))
		ButtonGInit->Enabled = false;
	else
		ButtonGInit->Enabled = true;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonGInitClick(TObject *Sender)
{
	string str = UnicodeToString(EditKey1->Text);
	for (int i = 0; i < LFSR1_MAX; i++)
		GLFSR1.bits[i] = CharToBit(str[LFSR1_MAX - 1 - i]);

	str = UnicodeToString(EditKey2->Text);
	for (int i = 0; i < LFSR2_MAX; i++)
		GLFSR2.bits[i] = CharToBit(str[LFSR2_MAX - 1 - i]);

	str = UnicodeToString(EditKey3->Text);
	for (int i = 0; i < LFSR3_MAX; i++)
		GLFSR3.bits[i] = CharToBit(str[LFSR3_MAX - 1 - i]);

	ButtonGTick->Enabled = true;
	ButtonGenGeffe->Enabled = true;
	PrintGLFSR();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonGTickClick(TObject *Sender)
{
	GetGeffeBit();
	PrintGLFSR();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonGProcessClick(TObject *Sender)
{
	OutputClear();
	EncryptGeffe();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::TimerGeffeTimer(TObject *Sender)
{
	GetGeffeBit();
	PrintGLFSR();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonGenGeffeClick(TObject *Sender)
{
	TimerGeffe->Enabled = !TimerGeffe->Enabled;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioGroup1Click(TObject *Sender)
{
	Memo1->Lines->Clear();
	if (RadioGroup1->ItemIndex == 0) {
		string str = "";
		if (bitsIN.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (bitsIN[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsIN.size(); i++) {
				str += (bitsIN[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
		} else {
			for (int i = 0; i < bitsIN.size(); i++) {
				str += (bitsIN[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
		}
		Memo1->Lines->Add(str.c_str());
	} else if (RadioGroup1->ItemIndex == 1) {
		string str = "";
		if (bitsIN.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += ToStr(bitsIN[i].to_ulong()) + " ";
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsIN.size(); i++) {
				str += ToStr(bitsIN[i].to_ulong()) + " ";
			}
		} else {
			for (int i = 0; i < bitsIN.size(); i++) {
				str += ToStr(bitsIN[i].to_ulong()) + " ";
			}
		}
		Memo1->Lines->Add(str.c_str());
	} else if (RadioGroup1->ItemIndex == 2) {
		string str = "";
		if (bitsIN.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (ToHex((unsigned __int16)bitsIN[i].to_ulong()) + " ");
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsIN.size(); i++) {
				str += (ToHex((unsigned __int16)bitsIN[i].to_ulong()) + " ");
			}
		} else {
			for (int i = 0; i < bitsIN.size(); i++) {
				str += (ToHex((unsigned __int16)bitsIN[i].to_ulong()) + " ");
			}
		}
		Memo1->Lines->Add(str.c_str());
	} else if (RadioGroup1->ItemIndex == 3) {
		string str = "";
		if (bitsIN.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (bitsIN[i].to_ulong());
			}
			str += ".. ..";
			for (int i = toprint; i < bitsIN.size(); i++) {
				str += (bitsIN[i].to_ulong());
			}
		} else {
			for (int i = 0; i < bitsIN.size(); i++) {
				str += bitsIN[i].to_ulong();
			}
		}
		Memo1->Lines->Add(str.c_str());
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioGroup2Click(TObject *Sender)
{
	Memo2->Lines->Clear();
	if (RadioGroup2->ItemIndex == 0) {
		string str = "";
		if (bitsKEY.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (bitsKEY[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsKEY.size(); i++) {
				str += (bitsKEY[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
		} else {
			for (int i = 0; i < bitsKEY.size(); i++) {
				str += (bitsKEY[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
		}
		Memo2->Lines->Add(str.c_str());
	} else if (RadioGroup2->ItemIndex == 1) {
		string str = "";
		if (bitsKEY.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += ToStr(bitsKEY[i].to_ulong()) + " ";
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsKEY.size(); i++) {
				str += ToStr(bitsKEY[i].to_ulong()) + " ";
			}
		} else {
			for (int i = 0; i < bitsKEY.size(); i++) {
				str += ToStr(bitsKEY[i].to_ulong()) + " ";
			}
		}
		Memo2->Lines->Add(str.c_str());
	} else if (RadioGroup2->ItemIndex == 2) {
		string str = "";
		if (bitsKEY.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (ToHex((unsigned __int16)bitsKEY[i].to_ulong()) + " ");
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsKEY.size(); i++) {
				str += (ToHex((unsigned __int16)bitsKEY[i].to_ulong()) + " ");
			}
		} else {
			for (int i = 0; i < bitsKEY.size(); i++) {
				str += (ToHex((unsigned __int16)bitsKEY[i].to_ulong()) + " ");
			}
		}
		Memo2->Lines->Add(str.c_str());
	} else if (RadioGroup2->ItemIndex == 3) {
		string str = "";
		if (bitsKEY.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (bitsKEY[i].to_ulong());
			}
			str += ".. ..";
			for (int i = toprint; i < bitsKEY.size(); i++) {
				str += (bitsKEY[i].to_ulong());
			}
		} else {
			for (int i = 0; i < bitsKEY.size(); i++) {
				str += bitsKEY[i].to_ulong();
			}
		}
		Memo2->Lines->Add(str.c_str());
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioGroup3Click(TObject *Sender)
{
	Memo3->Lines->Clear();
	if (RadioGroup3->ItemIndex == 0) {
		string str = "";
		if (bitsOUT.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (bitsOUT[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsOUT.size(); i++) {
				str += (bitsOUT[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
		} else {
			for (int i = 0; i < bitsOUT.size(); i++) {
				str += (bitsOUT[i].to_string<char, std::string::traits_type,std::string::allocator_type >() + " ");
			}
		}
		Memo3->Lines->Add(str.c_str());
	} else if (RadioGroup3->ItemIndex == 1) {
		string str = "";
		if (bitsOUT.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += ToStr(bitsOUT[i].to_ulong()) + " ";
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsOUT.size(); i++) {
				str += ToStr(bitsOUT[i].to_ulong()) + " ";
			}
		} else {
			for (int i = 0; i < bitsOUT.size(); i++) {
				str += ToStr(bitsOUT[i].to_ulong()) + " ";
			}
		}
		Memo3->Lines->Add(str.c_str());
	} else if (RadioGroup3->ItemIndex == 2) {
		string str = "";
		if (bitsOUT.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (ToHex((unsigned __int16)bitsOUT[i].to_ulong()) + " ");
			}
			str[str.length() - 1] = '.';
			str += ". ..";
			for (int i = toprint; i < bitsOUT.size(); i++) {
				str += (ToHex((unsigned __int16)bitsOUT[i].to_ulong()) + " ");
			}
		} else {
			for (int i = 0; i < bitsOUT.size(); i++) {
				str += (ToHex((unsigned __int16)bitsOUT[i].to_ulong()) + " ");
			}
		}
		Memo3->Lines->Add(str.c_str());
	} else if (RadioGroup3->ItemIndex == 3) {
		string str = "";
		if (bitsOUT.size() == (toprint) * 2) {
			for (int i = 0; i < toprint; i++) {
				str += (bitsOUT[i].to_ulong());
			}
			str += ".. ..";
			for (int i = toprint; i < bitsOUT.size(); i++) {
				str += (bitsOUT[i].to_ulong());
			}
		} else {
			for (int i = 0; i < bitsOUT.size(); i++) {
				str += bitsOUT[i].to_ulong();
			}
		}
		Memo3->Lines->Add(str.c_str());
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
	EditKey->EditLabel->Caption = ("LFSR1 State (x^" + ToStr(LFSR1_MAX) + " + ... + 1)").c_str();
	EditKey->MaxLength = LFSR1_MAX;

	EditKey1->EditLabel->Caption = ("LFSR1 State (x^" + ToStr(LFSR1_MAX) + " + ... + 1)").c_str();
	EditKey1->MaxLength = LFSR1_MAX;

	EditKey2->EditLabel->Caption = ("LFSR2 State (x^" + ToStr(LFSR2_MAX) + " + ... + 1)").c_str();
	EditKey2->MaxLength = LFSR2_MAX;

	EditKey3->EditLabel->Caption = ("LFSR3 State (x^" + ToStr(LFSR3_MAX) + " + ... + 1)").c_str();
	EditKey3->MaxLength = LFSR3_MAX;

}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonInitRC4Click(TObject *Sender)
{
	string str = UnicodeToString(EditKeyRC4->Text);
	if (EditKeyRC4->Text.Length() > 0 && atoi(str.c_str()) < 256)
	{
		U.push_back((unsigned __int8)atoi(str.c_str()));
		EditKeyRC4->Text = "";
	}
	PrintU();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonDelRC4Click(TObject *Sender)
{
	U.pop_back();
	PrintU();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonProcessRC4Click(TObject *Sender)
{
	if (U.size() >= 5) {
		OutputClear();
		EncryptRC4();
	}
}
//---------------------------------------------------------------------------

