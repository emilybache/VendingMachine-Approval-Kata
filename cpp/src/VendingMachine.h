#ifndef VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H
#define VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H

#include <string>
#include <vector>

class VendingMachine {
public:
    VendingMachine();

    std::string display;
    long balance; // in cents
    std::vector<int>* coins;

    void insertCoin(int value);

};


#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H
