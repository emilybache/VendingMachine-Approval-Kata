
#include "VendingMachine.h"
#include <sstream>
#include <iomanip>
#include <algorithm>

VendingMachine::VendingMachine() :
        display("INSERT COIN"),
        balance(0L),
        coins(new std::vector<int>(0, 0)),
        returns(new std::vector<int>(0, 0)),
        acceptedCoins(new std::vector<int>(3, 0))
        {
    int temp[] = {5, 10, 25};
    std::copy ( temp, temp+3, acceptedCoins->begin() );
}

static std::string getFormattedNumberAsString(double number, int precision)
{
    std::stringstream stream;
    stream << std::fixed << std::setprecision(precision) << number;
    return stream.str();
}

void VendingMachine::insertCoin(int value) {
    if (std::find(acceptedCoins->begin(), acceptedCoins->end(), value) != acceptedCoins->end()) {
        balance += value;
        coins->push_back(value);
        double dollars = (double)balance/100.0;
        display = "$" + getFormattedNumberAsString(dollars, 2);

    } else {
        returns->push_back(value);
    }
}

VendingMachine::~VendingMachine() {
    delete coins;
    delete returns;
    delete acceptedCoins;
}

