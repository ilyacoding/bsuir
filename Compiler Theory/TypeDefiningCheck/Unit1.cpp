//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "iostream"
#include "fstream"
#include "string"
#include "vector"
#include <algorithm>
#include <functional>
#include <sstream>
#include <cctype>
#include <locale>
#include <iostream>
#include <iomanip>
#include "boost/algorithm/string.hpp"
using namespace std;
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

/*string UnicodeToString(UnicodeString us) {
	string result = AnsiString(us.t_str()).c_str();
	return result;
}      */

inline bool isInt(const std::string & s)
{
   if(s.empty() || ((!isdigit(s[0])) && (s[0] != '-') && (s[0] != '+'))) return false ;

   char * p ;
   strtol(s.c_str(), &p, 10) ;

   return (*p == 0) ;
}

vector<string> TYPES;

void Init()
{
	TYPES.push_back("integer");
	TYPES.push_back("byte");
	TYPES.push_back("word");
	TYPES.push_back("shortint");
	TYPES.push_back("longint");
	TYPES.push_back("real");
	TYPES.push_back("single");
	TYPES.push_back("double");
	TYPES.push_back("extended");
	TYPES.push_back("boolean");
	TYPES.push_back("char");
}

bool is_digits(const std::string &str)
{
	return str.find_first_not_of("0123456789") == std::string::npos;
}

bool isValidVar(string str)
{
	if (!isalpha(str[0]) && (str[0] != '_')) return false;
	for (int i = 0; i < str.length(); i++)
	{
		if (!isalnum(str[i]) && (str[i] != '_')) return false;
	}
	return true;
}

bool CheckIndex(vector<string> s)
{
	if (s[0] != "[") return false;
   	if (!(isValidVar(s[1])) && !isInt(s[1])) return false;
	if (s[2] != "]") return false;
	return true;
}

bool isValidType(vector<string> gotLex)
{
	bool IsArray = true;
	vector<string> newLex;
	for (int i = 0; i < TYPES.size(); i++)
		if (TYPES[i] == gotLex[0])
			IsArray = false;

	int k = 0;
	for (int i = 0; i < gotLex.size(); i++)
		if (gotLex[i] == "array")
			k++;
		else if (gotLex[i] == "of")
			k--;

	if (k != 0) return false;

	if ((gotLex[0] == "array") && (IsArray)) {
		if (gotLex[1] != "[") return false;
		int h = 2;
		while (gotLex[h] != "]" && h < gotLex.size() - 1) h++;
		vector<string> arrcheck;
		///
		int k = 1;
		while ((gotLex[k] != "]") && (k < gotLex.size() - 1)) k++;
		if (k == gotLex.size() - 1) return false;
		if (gotLex[++k] != "of") return false;

		// Get new type
		for (int i = k + 1; i < gotLex.size(); i++)
			newLex.push_back(gotLex[i]);
		for (int i = 0; i < newLex.size(); i++)
		{
			Form1->Memo1->Lines->Add(newLex[i].c_str());
		}
		Form1->Memo1->Lines->Add("------------------------------");
		//if(find(newLex.begin(), newLex.end(), "array") != newLex.end() && newLex.size() < 2)
		//	return false;

		return isValidType(newLex);

	} else if (IsArray) {
		return false;
	} else {
		if (gotLex.size() == 1)
			return true;
		else
			return false;
	}
}

vector<string> GetStrLexems(string str)
{
	string buf = "";
	boost::algorithm::trim(str);
	vector<string> lexems;

	for (int j = 0; j < str.length(); j++)
	{ /*|| (str[j] == '.' && is_digits(buf))*/
		while ((isalpha(str[j]) || (str[j] == '.' && (buf == ".")) || (str[j] == '_') || isdigit(str[j])) && (j < str.length()) && (buf != ";")) buf += str[j++];
		if (buf.length() > 0) {
			boost::algorithm::trim(buf);
			lexems.push_back(buf);
			buf = "";
		}

		while ((!isspace(str[j]) && !isalpha(str[j]) && !isdigit(str[j])) && (j < str.length()) && (buf != ";")) buf += str[j++];
		if (buf.length() > 0) {
			boost::algorithm::trim(buf);
			lexems.push_back(buf);
			buf = "";
		}
		if (isalpha(str[j]) || isdigit(str[j])) j--;
	}
	return lexems;
}

void Check()
{
	Form1->Memo1->Clear();
	Init();
	string s = AnsiString(Form1->Edit1->Text.t_str()).c_str();
	bool IsValid = false;
	IsValid = true;
	boost::algorithm::to_lower(s);
	vector<string> x = GetStrLexems(s);
	if (x.size() < 2) return;

	if (x[0] == "type") {
		// Объявление типа
		if (x[x.size() - 1] != ";")
			IsValid = false;
		int k = x.size() - 1;
		while (x[k] == ";")
		{
			x.pop_back();
			k--;
        }
		if (x[2] != "=")
			IsValid = false;
		if (!isValidVar(x[1]))
			IsValid = false;

		vector<string> type;
		for (int i = 3; i < x.size(); i++)
			type.push_back(x[i]);

		Form1->Memo1->Lines->Add(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
		for (int i = 0; i < type.size(); i++)
		{
			Form1->Memo1->Lines->Add(type[i].c_str());
		}
		Form1->Memo1->Lines->Add(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

		if (!isValidType(type))
			IsValid = false;
	} else {
		// Обращение к переменной
		for (int i = 0; i < x.size(); i++)
		{
			Form1->Memo1->Lines->Add(x[i].c_str());
		}
		Form1->Memo1->Lines->Add(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
		if (!isValidVar(x[0])) IsValid = false;
		vector<string> s;
		for (int i = 1; i < x.size(); i++)
		{
			s.push_back(x[i]);
		}
		if (!CheckIndex(s)) IsValid = false;    ///IsValid = true;
	}

	if (IsValid)
	{
		Form1->ProgressBar1->Position = 100;
	}
	else {
		Form1->ProgressBar1->Position = 0;
	}
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Edit1Change(TObject *Sender)
{
	ProgressBar1->Position = 0;
	Check();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormCreate(TObject *Sender)
{
	Check();
}
//---------------------------------------------------------------------------
