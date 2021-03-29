
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
    selectedProduct = "";
    dispensedProduct = "";
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
        updateDisplay();

    } else {
        returns->push_back(value);
    }
}

VendingMachine::~VendingMachine() {
    delete coins;
}

void VendingMachine::tick() {
    if (display.find("PRICE") != std::string::npos) {
        updateDisplay();
    } else if (display.find("THANK YOU") != std::string::npos) {
        updateDisplay();
        dispensedProduct = "";
        delete returns;
        returns = new std::vector<int>(0, 0);
    } else if (!selectedProduct.empty() && (balance > priceOf(selectedProduct))) {
        dispenseProduct();
    }
}

void VendingMachine::updateDisplay() {
    if (balance > 0)
    {
        double dollars = (double)balance/100.0;
        display = "$" + getFormattedNumberAsString(dollars, 2);
    } else
    {
        display = "INSERT COIN";
    }
}

void VendingMachine::selectProduct(std::string name) {
    selectedProduct = name;
    if (balance >= priceOf(name)) {
        dispenseProduct();
    } else {
        double dollars = (double)priceOf(name)/100.0;
        display = "PRICE $" + getFormattedNumberAsString(dollars, 2);
    }
}

long VendingMachine::priceOf(const std::string& name) {
    if (name.find("Cola") != std::string::npos)
        return 100;

    return 0;
}

void VendingMachine::dispenseProduct() {
    display = "THANK YOU";
    balance -= priceOf(selectedProduct);
    delete coins;
    coins = new std::vector<int>(0, 0);
    dispensedProduct = selectedProduct;
    selectedProduct = "";

}

