#include <iostream>
#include "Header.h" //include the header file above
using namespace std;

void main() {
	matrix a(3, 3);
	a(0, 0) = 8;
	a(0, 1) = 4;
	a(0, 2) = 6;
	a(1, 0) = 4;
	a(1, 1) = 10;
	a(1, 2) = 8;
	a(2, 0) = 16;
	a(2, 1) = 16;
	a(2, 2) = 20;

	//for test 2
	/*	matrix a(4, 4);
	a(0, 0) = 6;
	a(0, 1) = -2;
	a(0, 2) = 2;
	a(0, 3) = 4;
	a(1, 0) = 12;
	a(1, 1) = -8;
	a(1, 2) = 6;
	a(1, 3) = 10;
	a(2, 0) = 3;
	a(2, 1) = -13;
	a(2, 2) = 9;
	a(2, 3) = 3;
	a(3, 0) = -6;
	a(3, 1) = 4;
	a(3, 2) = 1;
	a(3, 3) = -18;
	*/
	// display matrix A
	cout << "A=\n";
	for (int i = 0; i < a.getRow(); i++)
	{
		for (int j = 0; j < a.getCol(); j++)
		{
			cout << a(i, j) << "\t";
		}
		cout << "\n";
	}

	int size;
	if (a.getRow() == a.getCol())
		size = a.getRow();

	matrix L(size, size);
	matrix U(size, size);

	//initialize values in U to be a
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			U(i, j) = a(i, j);
		}
	}

	a.factor(a, U, L);
	a.findDet(U, L);

	matrix B(4, 1);
	B(0, 0) = 34;
	B(1, 0) = 48;
	B(2, 0) = 108;
	B(3, 0) = 20;

	a.solve(U, L, B);
	system("pause");
}
