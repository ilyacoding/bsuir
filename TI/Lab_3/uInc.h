#include <sstream>
#include <bitset>
#include <fstream>
#include <string>
#include <iostream>
#include <stdio.h>
#include <tchar.h>
#include <iomanip>
#include <vector>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <time.h>
#include "boost/algorithm/string.hpp"

#define SSTR(x) static_cast< std::ostringstream & >((std::ostringstream() << std::dec << x)).str()

bool xor(bool a, bool b)
{
	return (a + b) % 2;
}

union ToInt32
{
		unsigned __int64 int64_val;
		unsigned __int32 int32_val[2];
} toInt32;

union ToShort
{
		unsigned __int32 int32_val;
		unsigned __int16 int16_val[2];
} toShort;

union ToByte
{
		unsigned __int16 int16_val;
		unsigned __int8 int8_val[2];
} toByte;




byte CharToBit(byte c)
{
	if (c == '1') return 1;
	if (c == '0') return 0;
	return 3;
}

byte BitToChar(byte b)
{
	if (b == 1) return '1';
	if (b == 0) return '0';
	return 3;
}






