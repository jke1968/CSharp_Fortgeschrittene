// 07_01C++CLIBasissyntax.cpp: Hauptprojektdatei.
// Hinweis : 
// damit mmscoree.lib vom Linker gefunden wird, muss der Pfad 
// C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Lib
// über Eigenschaften=>Linker=>Allgemein=>Zusätzliche Bibliotheksverzeichnisse
// hinzugefügt werden
#include "stdafx.h"
#include <stdio.h>
#include <string.h>

// Was ist C++/CLI (CLI = Common Language Infrastructure) ?
// -> ist MS-spezifischer C++ Dialekt zum Zugriff auf das .NET Framework

using namespace System;
// int main (char* argv[], int argc)
int main(array<System::String^>^ args)
{
	// herkömmlicher C++ Pointer
	char* unmanaged = new char[10];
	strcpy_s(unmanaged, 10, "TODAY");
	// Pointer auf den managed Heap : ^
	// C# DateTime managed = new DateTime;
	// gcnew = "garbage collected new"
	DateTime^ managed = gcnew DateTime();
	printf("%s \n",unmanaged);
	Console::WriteLine(managed->Now); // in C# Console.WriteLine(managed.Now)
	delete[] unmanaged;
	// kein delete nötig für das "managed" Objekt, wg. Garbage Collector  
	return 0;
}
