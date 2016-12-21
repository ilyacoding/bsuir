// TK_Array.cpp : Defines the entry point for the console application.
//
#define _CRT_SECURE_NO_WARNINGS

#include "stdafx.h"
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

enum TOKEN {
	PROGRAM_DESC,

	PROGRAM_NAME,
	ID_LIST,

	PROGRAM_HEADER,
	DEFINE_BLOCK,
	OPERATOR_BLOCK,

	EXPRESSION,
	EXPRESSION_LIST,

	PROGRAM,
	USES,
	VAR,
	CONST,
	BEGIN,
	END,

	TYPE,

	ID,
	OPERATOR,
	DELIMETER,

	OPEN_BRACKET,
	CLOSE_BRACKET,
	E
};

struct lexem {
	lexem(char* str, TOKEN tk) : s(str), tok(tk) {}
	lexem(TOKEN tk) : tok(tk) {}
	char* s;
	TOKEN tok;
};

vector<string> TYPES, lexems, l;
vector<lexem> tokens;

string TokenToStr(TOKEN tok) 
{
	switch (tok)
	{
/*	PROGRAM_DESC,

	PROGRAM_HEADER,
	DEFINE_BLOCK,
	OPERATOR_BLOCK,*/
	case ID_LIST:
		return "ID_LIST";
		break;
	case PROGRAM_NAME:
		return "PROGRAM_NAME";
		break;
	case PROGRAM_DESC:
		return "PROGRAM_DESC";
		break;
	case PROGRAM_HEADER:
		return "PROGRAM_HEADER";
		break;
	case DEFINE_BLOCK:
		return "DEFINE_BLOCK";
		break;
	case OPERATOR_BLOCK:
		return "OPERATOR_BLOCK";
		break;
	case PROGRAM:
		return "PROGRAM";
		break;
	case USES:
		return "USES";
		break;
	case VAR:
		return "VAR";
		break;
	case CONST:
		return "CONST";
		break;
	case BEGIN:
		return "BEGIN";
		break;
	case END:
		return "END";
		break;
	case TYPE:
		return "TYPE";
		break;
	case ID:
		return "ID";
		break;
	case OPERATOR:
		return "OPERATOR";
		break;
	case DELIMETER:
		return "DELIMETER";
		break;
	case OPEN_BRACKET:
		return "OPEN_BRACKET";
		break;
	case CLOSE_BRACKET:
		return "CLOSE_BRACKET";
		break;
	case EXPRESSION_LIST:
		return "EXPRESSION_LIST";
		break;
	case EXPRESSION:
		return "EXPRESSION";
		break;
	case E:
		return "E";
		break;
	default:
		return "";
		break;
	}
}

bool IsTerminal(lexem tok)
{
	switch (tok.tok)
	{
	case PROGRAM:
	case PROGRAM_DESC: 
	case PROGRAM_HEADER: 
	case DEFINE_BLOCK: 
	case OPERATOR_BLOCK:
	case ID_LIST:
	case EXPRESSION:
	case EXPRESSION_LIST:
		return false;
		break;
	default:
		return true;
		break;
	}
}

// ------------------------------------------------------------------------
struct Tree {
	lexem term;
	Tree* Left;
	Tree* Center;
	Tree* Right;
};

void InitTree(Tree* & head, lexem t) {
	head = (Tree*)malloc(sizeof(Tree));
	head->term = t;
	head->Left = NULL;
	head->Right = NULL;
	head->Center = NULL;
}
	
void AddLeft(Tree* & head, lexem t)
{
	//head->Left = (Tree*)malloc(sizeof(Tree));
	InitTree(head->Left, t);
}

void AddCenter(Tree* & head, lexem t)
{
	//head->Center = (Tree*)malloc(sizeof(Tree));

	InitTree(head->Center, t);
}

void AddRight(Tree* & head, lexem t)
{
	//head->Right = (Tree*)malloc(sizeof(Tree));
	InitTree(head->Right, t);
}

void ProbPrint(Tree* & head, int n)
{
	if (head != NULL) {
		for (int i = 0; i < n; i++) printf(" ");
		if (!IsTerminal(head->term)) {
			cout << TokenToStr(head->term.tok) << endl;
		}
		else {
			cout << TokenToStr(head->term.tok) << endl;
			for (int i = 0; i < n + 2; i++) printf(" ");
			printf("-> %s \n", head->term.s);
		}
		
		ProbPrint(head->Left, n + 2);
		ProbPrint(head->Center, n + 2);
		ProbPrint(head->Right, n + 2);
	}
}

/*void AddLeft(Tree** head, Tree** right) {
	(*head)->Left = *right;
}

void AddRight(Tree** head, Tree** right) {
	(*head)->Right = *right;
}

void PrPrint(Tree** head)
{
	if (*head != NULL) {
		printf("%c", (*head)->info);
		PrPrint(&((*head)->Left));
		PrPrint(&((*head)->Right));
	}
}

void ObPrint(Tree** head)
{
	if (*head != NULL) {
		ObPrint(&((*head)->Left));
		ObPrint(&((*head)->Right));
		printf("%c", (*head)->info);
	}
}

void ProbPrint(Tree** head, int n)
{
	if (*head != NULL) {
		for (int i = 0; i < n; i++) printf(" ");
		printf("%c\n", (*head)->info);
		ProbPrint(&((*head)->Left), n + 1);
		ProbPrint(&((*head)->Right), n + 1);
	}
}

void SymPrint(Tree** head)
{
	if (*head != NULL) {
		SymPrint(&((*head)->Left));
		printf("%c", (*head)->info);
		SymPrint(&((*head)->Right));
	}
}


int IsBasic(Tree** head) {
	if (((*head)->Left == NULL) && ((*head)->Right == NULL))
		return 1;
	return 0;
}

Tree** TreeArr;
/*string s;
cin >> s;
	cout << endl;
	calc(s);
	char *str = new char[OutString.length() + 1];
	strcpy(str, OutString.c_str());

	// str with symbols

	TreeArr = (Tree**)malloc(sizeof(Tree*) * strlen(str));
	countEl = strlen(str);

	for (int i = 0; i < strlen(str); i++) {
		InitTree(&(TreeArr[i]), str[i]);
	}

	i = 0;

	while (countEl > 1) {
		while ((!IsBasic(&(TreeArr[i])) || isalpha((TreeArr[i])->info)) && (i < countEl)) i++;
		AddLeft(&(TreeArr[i]), &(TreeArr[i - 2]));
		AddRight(&(TreeArr[i]), &(TreeArr[i - 1]));
		for (int k = 0; k < 2; k++) {
			for (int j = i - 2; j < countEl - 1; j++) {
				TreeArr[j] = TreeArr[j + 1];
			}
			countEl--;
		}
		i = 0;
	}

	ProbPrint(&TreeArr[0], 0);

	puts("\n\nPre: ");
	PrPrint(&TreeArr[0]);
	puts("\nPost: ");
	ObPrint(&TreeArr[0]);
	puts("\nIn: ");
	SymPrint(&TreeArr[0]);
	puts("\n\n");
	system("pause");
	return 0;
}*/
// ------------------------------------------------------------------------


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
		if (!isalnum(str[i]) && (str[0] != '_')) return false;
	}
	return true;
}

bool isValidType(vector<string> gotLex)
{
	bool IsArray = true;
	vector<string> newLex;
	for (int i = 0; i < TYPES.size(); i++)
		if (TYPES[i] == gotLex[0])
			IsArray = false;
	if (IsArray) {
		int k = 1;
		while ((gotLex[k] != "of") && (k < gotLex.size() - 1))
			if (gotLex[k] == "array")
				return false;
			else
				k++;
		if (k == gotLex.size() - 1) return false;

		// Get new type
		for (int i = k + 1; i < gotLex.size(); i++)
			newLex.push_back(gotLex[i]);
		return isValidType(newLex);

	}
	else {
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
		while ((isalpha(str[j]) || (str[j] == '.' && (buf == ".")) || (str[j] == '_') || isdigit(str[j])) && str[j] != ';' && (j < str.length())) buf += str[j++];
		if (buf.length() > 0) {
			boost::algorithm::trim(buf);
			lexems.push_back(buf);
			buf = "";
		}
		if (str[j] == ';') {
			lexems.push_back(";");
			j++;
		}
		while ((!isspace(str[j]) && !isalpha(str[j]) && !isdigit(str[j])) && str[j] != ';' && (j < str.length())) buf += str[j++];
		if (buf.length() > 0) {
			boost::algorithm::trim(buf);
			lexems.push_back(buf);
			buf = "";
		}
		if (str[j] == ';') {
			lexems.push_back(";");
			j++;
		}
		if (isalpha(str[j]) || isdigit(str[j])) j--;
	}
	return lexems;
}

bool ParseTokens(vector<string> lex)
{
	for (int i = 0; i < lex.size(); i++)
	{
		char* cstr = new char[lex[i].length() + 1];
		strcpy(cstr, lex[i].c_str());
		if (lex[i] == "program")
			tokens.push_back(lexem(cstr, PROGRAM));

		else if (lex[i] == "begin")
			tokens.push_back(lexem(cstr, BEGIN));

		else if (lex[i] == "end")
			tokens.push_back(lexem(cstr, END));

		else if(lex[i] == "uses")
			tokens.push_back(lexem(cstr, USES));

		else if (lex[i] == "var")
			tokens.push_back(lexem(cstr, VAR));

		else if (lex[i] == "integer" || lex[i] == "real" || lex[i] == "int64")
			tokens.push_back(lexem(cstr, TYPE));

		else if (lex[i] == "+" || lex[i] == "-" || lex[i] == "*" || lex[i] == "/" || lex[i] == ":=" || lex[i] == ";" || lex[i] == "=")
			tokens.push_back(lexem(cstr, OPERATOR));

		else if (lex[i] == "." || lex[i] == "," || lex[i] == ":")
			tokens.push_back(lexem(cstr, DELIMETER));

		else if (isValidVar(lex[i]))
			tokens.push_back(lexem(cstr, ID));

		else if (lex[i] == "(")
			tokens.push_back(lexem(lex[i], OPEN_BRACKET));
		else if (lex[i] == ")")
			tokens.push_back(lexem(lex[i], CLOSE_BRACKET));

		else if (is_digits(lex[i]))
			tokens.push_back(lexem(cstr, CONST));
		else {
			cout << "Unknown symbol:  " << lex[i] << endl;
			return false;
		}
	}
	return true;
}

int main()
{
	setlocale(LC_ALL, "rus");
	Init();
	ifstream file;
	string s;
	vector <string> v;
	Tree* tree;
	char buf[500];
	file.open("file/file.txt", ios_base::in);
	file.imbue(std::locale(""));

	while (!file.eof()) {
		file.getline(buf, 500);
		v.push_back(buf);
	}
	for (int i = 0; i < v.size(); i++)
	{
		auto x = GetStrLexems(boost::algorithm::to_lower_copy(v[i]));
		for (int j = 0; j < x.size(); j++)
			l.push_back(x[j]);
	}
	file.close();

	cout << "Parsed text:" << endl;
	for (int i = 0; i < l.size(); i++)
	{
		cout << l[i];
		if (i < l.size() - 1) cout << "_";
	}
	cout << endl << endl << "Starting to parse lexems:" << endl;
	if (!ParseTokens(l))
	{
		cout << "Lexical error." << endl;
		cout << endl << endl;
		system("pause");
		return 0;
	}
	for (int i = 0; i < tokens.size(); i++)
	{
		printf("Lexem: %s %s \n", tokens[i].s, TokenToStr(tokens[i].tok).c_str());
	}
	cout << endl;
	
	InitTree(tree, lexem("program", PROGRAM));

	cout << endl << endl << "#=> Дерево: " << endl << endl;
	ProbPrint(tree, 0);
	cout << endl << endl;

	while (tokens.size() > 0)
	{
		if (tokens[0].tok == PROGRAM)
		{
			int i = 0;
			vector<lexem> s;
			while (tokens[i].tok != OPERATOR && i < tokens.size() - 1)
			{
				s.push_back(tokens[i]);
				tokens.erase(tokens.begin());
			}
			s.push_back(tokens[i]);
			tokens.erase(tokens.begin());
			/*for (int i = 0; i < s.size(); i++)
			{
				printf("Lexem2: %s %s \n", s[i].s, TokenToStr(s[i].tok).c_str());
			}*/
			if (s.size() < 3)
			{
				cout << "Parser error.";
				cout << endl << endl;
				system("pause");
				return 0;
			}
			if (isValidVar(s[i].s) && !strcmp(s[2].s, ";"))
			{
				AddLeft(tree, lexem("", PROGRAM_HEADER));
				AddLeft(tree->Left, lexem("program", PROGRAM_NAME));
				AddCenter(tree->Left, lexem(s[1].s, ID));
			}
			else {
				cout << "Parser error.";
				cout << endl << endl;
				system("pause");
				return 0;
			}
			cout << endl << endl << "#=> Дерево: " << endl << endl;
			ProbPrint(tree, 0);
			cout << endl;
			for (int i = 0; i < tokens.size(); i++)
			{
				printf("Lexem: %s %s \n", tokens[i].s, TokenToStr(tokens[i].tok).c_str());
			}
			cout << endl;
		}
		cout << endl;
		if (tokens[0].tok == VAR)
		{
			int i = 0;
			vector<lexem> s;
			while (strcmp(tokens[i].s, ";") && i < tokens.size() - 1)
			{
				s.push_back(tokens[i]);
				tokens.erase(tokens.begin());
			}
			s.push_back(tokens[i]);
			tokens.erase(tokens.begin());
			/*for (int i = 0; i < s.size(); i++)
			{
				printf("Lexem3: %s %s \n", s[i].s, TokenToStr(s[i].tok).c_str());
			}*/

			vector<string> type;
			vector<lexem> ids;
			string Stype = "";
			int j = 0;
			while (strcmp(s[j].s, ":") && j < s.size() - 1) j++;
			for (int k = 0; k < j && k < s.size(); k++)
				if (s[k].tok == ID)
					ids.push_back(s[k]);
	

			for (int k = j + 1; k < s.size() - 1; k++)
				type.push_back(s[k].s);

			for (int i = 0; i < type.size(); i++)
				Stype += type[i] + " ";
			char* cstr = new char[Stype.length() + 1];
			strcpy(cstr, Stype.c_str());

			if (isValidType(type) && !strcmp(s[s.size() - 1].s, ";"))
			{
				AddCenter(tree, lexem("", DEFINE_BLOCK));
				AddLeft(tree->Center, lexem("var", VAR));
				AddCenter(tree->Center, lexem("", ID_LIST));
				if (ids.size() < 4)
				{
					if (ids.size() == 1)
					{
						AddLeft(tree->Center->Center, ids[0]);
					} else if (ids.size() == 2)
					{
						AddLeft(tree->Center->Center, ids[0]);
						AddCenter(tree->Center->Center, ids[1]);
					} else if (ids.size() == 3)
					{
						AddLeft(tree->Center->Center, ids[0]);
						AddCenter(tree->Center->Center, ids[1]);
						AddRight(tree->Center->Center, ids[2]);
					}
				}
				AddRight(tree->Center, lexem(cstr, TYPE));
			} else {
				cout << "Parser error.";
				cout << endl << endl;
				system("pause");
				return 0;
			}
			cout << endl << endl << "#=> Дерево: " << endl << endl;
			ProbPrint(tree, 0);
			cout << endl;
			for (int i = 0; i < tokens.size(); i++)
			{
				printf("Lexem: %s %s \n", tokens[i].s, TokenToStr(tokens[i].tok).c_str());
			}
			cout << endl;
		}
		cout << endl;
		if (tokens[0].tok == BEGIN)
		{
			tokens.erase(tokens.begin());
			if (strcmp(tokens[tokens.size() - 1].s, ".") || tokens[tokens.size() - 2].tok != END)
			{
				cout << "Parser error.";
				cout << endl << endl;
				system("pause");
				return 0;
			}

			tokens.erase(tokens.begin() + tokens.size() - 1);
			tokens.erase(tokens.begin() + tokens.size() - 1);
			// deleted mycor

			/*for (int i = 0; i < tokens.size(); i++)
			{
				printf("Lexem4: %s %s \n", tokens[i].s, TokenToStr(tokens[i].tok).c_str());
			}*/

			AddRight(tree, lexem("", PROGRAM_DESC));

			while (tokens.size() > 0)
			{
				vector<lexem> l;
				while (strcmp(tokens[0].s, ";"))
				{
					l.push_back(tokens[0]);
					tokens.erase(tokens.begin());
				}
				tokens.erase(tokens.begin());
				/*for (int i = 0; i < l.size(); i++)
				{
					printf("Lexem5: %s %s \n", l[i].s, TokenToStr(l[i].tok).c_str());
				}*/
				if (l.size() < 3)
				{
					cout << "Parser error.";
					cout << endl << endl;
					system("pause");
					return 0;
				}
				if (tree->Right->Left) {
					if (tree->Right->Center) {
						AddRight(tree->Right, EXPRESSION);
						if (l[1].tok == OPERATOR)
						{
							AddLeft(tree->Right->Right, lexem(l[0].s, ID));
							AddCenter(tree->Right->Right, lexem(l[1].s, OPERATOR));
							AddRight(tree->Right->Right, EXPRESSION);
							l.erase(l.begin());
							l.erase(l.begin());
							if (l.size() == 1) {
								AddLeft(tree->Right->Right->Right, l[0]);
							}
							else if (l.size() == 2) {
								cout << "Parser error.";
								cout << endl << endl;
								system("pause");
								return 0;
							}
							else if (l.size() == 3) {
								AddLeft(tree->Right->Right->Right, l[0]);
								AddCenter(tree->Right->Right->Right, l[1]);
								AddRight(tree->Right->Right->Right, l[2]);
							}
						}
					} else {
						AddCenter(tree->Right, EXPRESSION);
						if (l[1].tok == OPERATOR)
						{
							AddLeft(tree->Right->Center, lexem(l[0].s, ID));
							AddCenter(tree->Right->Center, lexem(l[1].s, OPERATOR));
							AddRight(tree->Right->Center, EXPRESSION);
							l.erase(l.begin());
							l.erase(l.begin());
							if (l.size() == 1) {
								AddLeft(tree->Right->Center->Right, l[0]);
							}
							else if (l.size() == 2) {
								cout << "Parser error.";
								cout << endl << endl;
								system("pause");
								return 0;
							}
							else if (l.size() == 3) {
								AddLeft(tree->Right->Center->Right, l[0]);
								AddCenter(tree->Right->Center->Right, l[1]);
								AddRight(tree->Right->Center->Right, l[2]);
							}
						} else {
							cout << "Parser error.";
							cout << endl << endl;
							system("pause");
							return 0;
						}
					}
				} else {
					AddLeft(tree->Right, EXPRESSION);
					if (l[1].tok == OPERATOR)
					{
						AddLeft(tree->Right->Left, lexem(l[0].s, ID));
						AddCenter(tree->Right->Left, lexem(l[1].s, OPERATOR));
						AddRight(tree->Right->Left, EXPRESSION);
						l.erase(l.begin());
						l.erase(l.begin());
						if (l.size() == 1) {
							AddLeft(tree->Right->Left->Right, l[0]);
						} else if (l.size() == 2) {
							cout << "Parser error.";
							cout << endl << endl;
							system("pause");
							return 0;
						} else if (l.size() == 3) {
							AddLeft(tree->Right->Left->Right, l[0]);
							AddCenter(tree->Right->Left->Right, l[1]);
							AddRight(tree->Right->Left->Right, l[2]);
						}
					}
				}
			}
			cout << endl << endl << "#=> Дерево: " << endl << endl;
			ProbPrint(tree, 0);
			cout << endl;
			for (int i = 0; i < tokens.size(); i++)
			{
				printf("Lexem: %s %s \n", tokens[i].s, TokenToStr(tokens[i].tok).c_str());
			}
			cout << endl;
		}
		if (tokens.size() > 0)
			if (tokens[0].tok == ID) {
				cout << "Parser error.";
				cout << endl << endl;
				system("pause");
				return 0;
			}
	}

	cout << endl << endl << "###=> Результирующее дерево: " << endl << endl;
	ProbPrint(tree, 0);
	cout << endl << endl;
	system("pause");
    return 0;
}