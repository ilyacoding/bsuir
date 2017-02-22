//---------------------------------------------------------------------------

#include <fmx.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.fmx"
TForm1 *Form1;

#include <stdio.h>
#include <iostream>
#include <string>
#include <cmath>
#include <cctype>
#include <vector>
#include <algorithm>
#include <iterator>
#include <fstream>
#include <boost/algorithm/string.hpp>

using namespace std;

vector<int> vKey;
vector<int> vLen;

char CryptCode(char p, char k)
{
	if (isupper(p)) {
		k = toupper(k);
		p -= 'A';
		k -= 'A';
		return ((p + k) % 26) + 'A';
	} else {
		p = tolower(p);
		k = tolower(k);
		p -= 'a';
		k -= 'a';
		return ((p + k) % 26) + 'a';
	}
}

char DecryptCode(char c, char k)
{
	if (isupper(c)) {
		k = toupper(k);
		c -= 'A';
		k -= 'A';
		return ((c - k + 26) % 26) + 'A';
	} else {
		c = tolower(c);
		k = tolower(k);
		c -= 'a';
		k -= 'a';
		return ((c - k + 26) % 26) + 'a';
	}
}

string OnlyAlpha(string str)
{
	string res = "";
	for (int i = 0; i < str.length(); i++) {
		if (isalpha(str[i])) {
			res += str[i];
		}
	}
	return res;
}

string GenKey(string M, string K)
{
	string res = "";
	M = OnlyAlpha(M);
	K = OnlyAlpha(K);
	for (int i = 0; (i < M.length()) && (i < K.length()); i++) {
		res += K[i];
	}

	for (int i = 0; res.length() < M.length(); i++) {
		res += M[i];
	}
	return res;
}

string Encrypt(string M, string K)
{
	string res = M;
	K = GenKey(M, K);
	int j = 0;
	for (int i = 0; i < M.length(); i++) {
		if (isalpha(M[i])) {
			res[i] = CryptCode(M[i], K[j++]);
		}
	}
	return res;
}

string Decrypt(string C, string K)
{
	string res = "";
	string partK;
	int j = 0;
	int i = 0;
	partK = OnlyAlpha(K);

	do {
		while ((i < partK.length()) && (j < C.length())) {
			if (isalpha(C[j])) {
				res += DecryptCode(C[j], partK[i]);
				partK += DecryptCode(C[j++], partK[i++]);
			} else {
				res += C[j];
				j++;
			}
		}
		i = 0;
	} while (j < C.length());
	return res;
}

int gcd(int a, int b)
{
	if (b == 0)
    	return a;
    else
    	return gcd (b, a % b);
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::ButtonCryptClick(TObject *Sender)
{
    MemoC->Lines->Clear();
    MemoC->Lines->Add(UnicodeString(Encrypt(AnsiString(MemoM->Lines[0].Text).c_str(), AnsiString(EditK->Text).c_str()).c_str()));
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonDecryptClick(TObject *Sender)
{
	MemoM->Lines->Clear();
    MemoM->Lines->Add(UnicodeString(Decrypt(AnsiString(MemoC->Lines[0].Text).c_str(), AnsiString(EditK->Text).c_str()).c_str()));
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormResize(TObject *Sender)
{
    MemoM->Width = Form1->Width/3;
	MemoC->Width = Form1->Width/3;
    MemoK->Width = Form1->Width/3;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonLoadMClick(TObject *Sender)
{
    if (OpenDialog1->Execute())
    	MemoM->Lines->LoadFromFile(OpenDialog1->FileName);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonLoadCClick(TObject *Sender)
{
    if (OpenDialog1->Execute())
    	MemoC->Lines->LoadFromFile(OpenDialog1->FileName);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonSaveMClick(TObject *Sender)
{
	if (SaveDialog1->Execute())
    	MemoM->Lines->SaveToFile(SaveDialog1->FileName);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonSaveCClick(TObject *Sender)
{
	if (SaveDialog1->Execute())
    	MemoC->Lines->SaveToFile(SaveDialog1->FileName);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonTestClick(TObject *Sender)
{
    MemoK->Lines->Clear();
    string str = OnlyAlpha(AnsiString(MemoC->Lines[0].Text).c_str());
    boost::algorithm::to_lower(str);
    if (str.length() <= 5) {
    	MemoK->Lines->Add("Слишком малая длина зашифрованного текста.");
        return;
    }

    MemoK->Lines->Add("Анализ: " + UnicodeString(str.c_str()));
	MemoK->Lines->Add("Длина: " + UnicodeString(str.size()));
    vector <int> Dist[3];
    int *Measure = new int[str.length()];

    for (int i = 0; i < str.length(); i++) {
        Measure[i] = 0;
    }

    for (int k = 0; k < 3; k++) {
    	for (int i = 0; i < str.length() - 2 - k; i++) {
    	    size_t pred = i, pos = i;
			string s_str = "";
            for (int j = 0; j < k + 3; j++)
			{
    	        s_str += str[i + j];
    	    }

            do {
    	        pos = str.find(s_str, pred + 1);
    	        if (pos == string::npos) {
    	            break;
    	        } else {
    	            if ((pos - pred > 0) && (pos < string::npos)) {
    	            	Dist[k].push_back(pos - pred);
                        Measure[pos - pred] += k + 1;
						MemoK->Lines->Add("Подстрока: " + UnicodeString(s_str.c_str()) + " на расстоянии " + UnicodeString(pos - pred));
					}
    	            pred = pos;
    	        }
   		    } while (pos != string::npos);
		}
    }
    int non = 0, maxPerc = 0, accLen = 0;
	bool IfHave = false;
    for (int i = 1; i < str.length(); i++)
        non += Measure[i];

    for (int i = 1; i < str.length(); i++) {
        if (Measure[i] > 0) {
            IfHave = true;
            MemoK->Lines->Add(UnicodeString(i) + " " + UnicodeString(floor((float) Measure[i] * 100 / non * 100)/100) + "% ");
            if (floor((float) Measure[i] * 100 / non * 100)/100 > maxPerc) {
                maxPerc = floor((float) Measure[i] * 100 / non * 100)/100;
                accLen = i;
            }
		}
    }
	string s = AnsiString(EditK->Text).c_str();
	vKey.push_back(s.length());

    if (!IfHave) {
    	MemoK->Lines->Add("Не удалось определить длину ключа.");
        vLen.push_back(0);
    } else {
        vLen.push_back(accLen);
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
    ifstream input("baseKey.txt");
	copy(std::istream_iterator<int> (input), std::istream_iterator<int> (), std::back_inserter(vKey) );
	copy(vKey.begin(), vKey.end(), std::ostream_iterator<int> (std::cout, " ") );
    input.close();

	ifstream inputLen("baseLen.txt");
	copy(std::istream_iterator<int> (inputLen), std::istream_iterator<int> (), std::back_inserter(vLen) );
	copy(vLen.begin(), vLen.end(), std::ostream_iterator<int> (std::cout, " ") );
    input.close();
}
//---------------------------------------------------------------------------



void __fastcall TForm1::FormCloseQuery(TObject *Sender, bool &CanClose)
{
    ofstream fileKey("baseKey.txt");
    copy(vKey.begin(), vKey.end(), ostream_iterator<int>(fileKey, " ") );
    fileKey.close();

    ofstream fileLen("baseLen.txt");
    copy(vLen.begin(), vLen.end(), ostream_iterator<int>(fileLen, " ") );
    fileLen.close();

    CanClose = true;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ButtonShowStatClick(TObject *Sender)
{
    MemoS->Visible = true;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SwitchStatSwitch(TObject *Sender)
{
    MemoS->Lines->Clear();
    MemoS->Visible = SwitchStat->IsChecked;

    for (int i = 0; i < vKey.size(); i++) {
        for (int j = i + 1; j < vKey.size(); j++) {
            if (vKey[i] > vKey[j]) {
                swap(vKey[i], vKey[j]);
                swap(vLen[i], vLen[j]);
            }
        }
    }

    for (int i = 0; i < vKey.size(); i++) {
        if (vKey[i] == vLen[i]) {
            MemoS->Lines->Add(UnicodeString(vKey[i]) + " - успешно.");
        } else {
            MemoS->Lines->Add(UnicodeString(vKey[i]) + " - провалено.");
        }
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::EditKKeyDown(TObject *Sender, WORD &Key, System::WideChar &KeyChar,
          TShiftState Shift)
{
    if (KeyChar == 8)
        return;
    if ((KeyChar < 'a') || (KeyChar > 'z'))
        KeyChar = 0;
}
//---------------------------------------------------------------------------

