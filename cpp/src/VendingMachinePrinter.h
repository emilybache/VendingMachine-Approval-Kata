#ifndef VENDINGMACHINEAPPROVALKATA_VENDINGMACHINEPRINTER_H
#define VENDINGMACHINEAPPROVALKATA_VENDINGMACHINEPRINTER_H


#include "VendingMachine.h"

class VendingMachinePrinter {
public:
    explicit VendingMachinePrinter(VendingMachine* machine);

    virtual ~VendingMachinePrinter();

    std::string print();
    std::string formatLine(const std::string& key, const std::string& value) const;
    std::string printVector(const std::vector<int>* items) const;
private:
    VendingMachine* machine;

    int columns;
};


#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINEPRINTER_H
