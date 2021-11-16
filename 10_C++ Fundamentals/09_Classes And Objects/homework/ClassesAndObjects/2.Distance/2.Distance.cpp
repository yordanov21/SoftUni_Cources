#include <iostream>
#include <string>
#include <sstream>  
#include <utility>
#include <map>
#include <vector>
#include <algorithm>
#include <time.h>
#include <iomanip>

using namespace std;

class Distance
{
private:
	float x1;
	float y1;
	float x2;
	float y2;
public:
	Distance(float x1, float y1, float x2, float y2) {
		this->x1 = x1;
		this->y1 = y1;
		this->x2 = x2;
		this->y2 = y2;
	}

	void getEuclidean()
	{
		float X = x2 - x1;
		float Y = y2 - y1;

		float euclidean = mySqrt((X * X + Y * Y));
		cout << fixed << setprecision(3) << euclidean;
	}

	double mySqrt(double number)
	{
		double error = 0.00001; //define the precision of your result
		double s = number;

		while ((s - number / s) > error) //loop until precision satisfied 
		{
			s = (s + number / s) / 2;
		}
		return s;
	}
};

int main()
{
	float x1;
	float y1;
	float x2;
	float y2;
	cin >> x1 >> y1;
	cin >> x2 >> y2;

	Distance dist(x1, y1, x2, y2);

	dist.getEuclidean();
}