
#ifndef VENDINGMACHINEAPPROVALKATA_VENDINGMACHINETEST_H
#define VENDINGMACHINEAPPROVALKATA_VENDINGMACHINETEST_H

#include <gtest/gtest.h>
#include "VendingMachine.h"

using namespace std;

class VendingMachineTest : public ::testing::Test {
public:
    VendingMachine* machine;
    map<string, int>* coins;
    VendingMachinePrinter* printer;

    void SetUp() override {
        machine = new VendingMachine();
        printer = new VendingMachinePrinter(machine);
        coins = new map<string, int>();
        coins->insert({
                              {"penny", 1},
                              {"nickel", 5},
                              {"dime", 10},
                              {"quarter", 25},
                      });
    }

    string insertCoin(const string& coinName) {
        string toApprove = "\nUser action: INSERT COIN '";
        toApprove +=  coinName + "'\n\n";

        machine->insertCoin(coins->at(coinName));
        return toApprove;
    }

    void TearDown() override {
        delete coins;
        delete machine;
    }
};

#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINETEST_H
