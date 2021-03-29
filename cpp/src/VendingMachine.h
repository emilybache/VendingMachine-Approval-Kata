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
    std::string dispensedProduct;

    void insertCoin(int value);
    void selectProduct(std::string name);
    void tick();

private:
    void updateDisplay();
    void dispenseProduct();
    std::string selectedProduct;
    static long priceOf(const std::string& product);
    std::vector<int>* acceptedCoins;
};


#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINE_H
