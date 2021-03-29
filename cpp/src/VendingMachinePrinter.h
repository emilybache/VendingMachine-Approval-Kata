#ifndef VENDINGMACHINEAPPROVALKATA_VENDINGMACHINEPRINTER_H
#define VENDINGMACHINEAPPROVALKATA_VENDINGMACHINEPRINTER_H


#include "VendingMachine.h"

class VendingMachinePrinter {
public:
    explicit VendingMachinePrinter(VendingMachine* machine);

    virtual ~VendingMachinePrinter();

    std::string print();
    std::string formatLine(std::string key, std::string value);
private:
    VendingMachine* machine;
    int columns;
};


#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINEPRINTER_H
