
#include "VendingMachine.h"
#include <sstream>
#include <iomanip>

VendingMachine::VendingMachine() :
        display("INSERT COIN"),
        balance(0L),
        coins(new std::vector<int>(0, 0)) {

}

static std::string getFormattedNumberAsString(double number, int precision)
{
    std::stringstream stream;
    stream << std::fixed << std::setprecision(precision) << number;
    return stream.str();
}

void VendingMachine::insertCoin(int value) {
    balance += value;
    coins->push_back(value);
    double dollars = (double)balance/100.0;
    display = "$" + getFormattedNumberAsString(dollars, 2);
}

VendingMachine::~VendingMachine() {
    delete coins;
}

