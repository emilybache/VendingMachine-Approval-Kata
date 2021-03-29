#ifndef VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H
#define VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H

#include <string>
#include <vector>

class VendingMachine {
public:
    VendingMachine();
    virtual ~VendingMachine();

    std::string display;
    long balance; // in cents
    std::vector<int>* coins;
    std::vector<int>* returns;

    void insertCoin(int value);
    void returnCoins();

private:
    void updateDisplay();
    std::vector<int>* acceptedCoins;
};


#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H
