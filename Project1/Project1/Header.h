#include <iostream>
#include <math.h>
using  namespace  std;

class matrix {
public:
	matrix();
	matrix(int m, int  n);
	int  getRow();
	int  getCol();
	void factor(matrix a, matrix U, matrix L);
	void findDet(matrix U, matrix L);
	void solve(matrix U, matrix L, matrix B);
	double& operator()(int, int);
	friend ostream& operator<< (ostream& os, matrix& m);
private:
	void  init(int, int);
	int  nrows, ncols;
	double  *data;
};

matrix::matrix() {
	init(1, 1);
}

matrix::matrix(int m, int n) {
	init(m, n);
}

void  matrix::init(int m, int n) {
	nrows = m;
	ncols = n;
	data = new double[m*n];
	for (int i = 0; i<m*n; i++)
		data[i] = 0;
}

int matrix::getRow() { return nrows; }
int matrix::getCol() { return ncols; }

void matrix::factor(matrix a, matrix U, matrix L)
{
	cout << "\n\n";
	int size = a.getRow();
	double coeff1[3] = { 0, 0, 0 };
	double coeff2[3] = { 0, 0, 0 };
	double coeff3[3] = { 0, 0, 0 };     	// can work for up to 4x4 matrix

	for (int i = 0; i < (size - 1); i++)
	{
		coeff1[i] = (U((i + 1), 0) / U(0, 0));
	}

	// first pivot row
	for (int i = 1; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			U(i, j) = U(i, j) - (coeff1[i - 1] * U(0, j));
		}
	}

	if (size > 2)
	{
		for (int i = 1; i < (size - 1); i++)
		{
			coeff2[i - 1] = (U((i + 1), 1) / U(1, 1));
		}
	}

	//second pivot row

	for (int i = 2; i < size; i++)
	{
		for (int j = 1; j < size; j++)
		{
			U(i, j) = U(i, j) - (coeff2[i - 2] * U(1, j));
		}
	}

	if (size > 3)
	{
		for (int i = 2; i < (size - 1); i++)
		{
			coeff3[i - 2] = (U((i + 1), 2) / U(2, 2));
		}
	}

	//third pivot row
	for (int i = 3; i < size; i++)
	{
		for (int j = 2; j < size; j++)
		{
			U(i, j) = U(i, j) - (coeff3[i - 3] * U(2, j));
		}
	}

	cout << "U=\n";
	for (int i = 0; i < L.getRow(); i++)
	{
		for (int j = 0; j < L.getCol(); j++)
		{
			cout << U(i, j) << "\t";
		}
		cout << "\n";
	}
	cout << "\n";

	//Lower Matrix
	//Putting the coefficients into the matrix
	for (int i = 0; i < size; i++)
	{
		int j = 0;
		L((i + 1), j) = coeff1[i];
	}

	if (size > 2)
	{
		for (int i = 0; i < (size - 2); i++)
		{
			int j = 0;
			L((i + 2), (j + 1)) = coeff2[i];
		}
	}
	if (size > 3)
	{
		for (int i = 0; i < (size - 3); i++)
		{
			int j = 0;
			L((i + 3), (j + 2)) = coeff3[i];
		}
	}

	for (int i = 0; i < L.getRow(); i++)
	{
		for (int j = 0; j < L.getCol(); j++)
		{
			if (i == j)
			{
				L(i, j) = 1;
			}
		}
	}

	cout << "L=\n";
	for (int i = 0; i < L.getRow(); i++)
	{
		for (int j = 0; j < L.getCol(); j++)
		{
			cout << L(i, j) << "\t";
		}
		cout << "\n";
	}
	cout << "\n";
}

void matrix::findDet(matrix U, matrix L)
{
	//Finds the determinant of the input matrix
	int size = U.getCol();
	double det = 1;

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i == j)
			{
				det = det* U(i, j) * L(i, j);
			}
		}
	}
	cout << "\nDeterminant: " << det << endl;
	cout << endl;
}

void matrix::solve(matrix U, matrix L, matrix B)
{
	int size = U.getRow();
	double s = 0;
	matrix z(size, 1);
	matrix x(size, 1);

	// solve for z in Lz=B
	for (int i = 0; i < size; i++)
	{
		s = 0;
		for (int j = 0; j < i; j++)
		{
			s = s + L(i, j)*z(j, 0);
		}
		z(i, 0) = (B(i, 0) - s) / L(i, i);
	}
	// solve for x in Ux=B
	for (int i = size - 1; i >= 0; i--)
	{
		s = 0;
		for (int j = size - 1; j >= i; j--)
		{
			s = s + U(i, j)*x(j, 0);
		}
		x(i, 0) = (z(i, 0) - s) / U(i, i);
	}
	cout << "x =\n";
	for (int i = 0; i < x.getRow(); i++)
	{
		for (int j = 0; j < x.getCol(); j++)
		{
			cout << x(i, j) << "\n";
		}
	}
	cout << endl;
}


double& matrix::operator() (int r, int c) {
	if (r < 0 || r> nrows) {
		cout << "Illegal Row Index:";
		return data[0];
	}
	else if (c < 0 || c> ncols) {
		cout << "Illegal Column Index:";
		return data[0];
	}
	else return data[r*ncols + c];
}

ostream& operator<<(ostream &os, matrix &m) {
	int mval = m.getRow();
	int nval = m.getCol();
	for (int i = 0; i<mval; i++) {
		for (int j = 0; j < nval; j++)
			os << m(i, j);
		os << endl;
	}
	return os;
}

