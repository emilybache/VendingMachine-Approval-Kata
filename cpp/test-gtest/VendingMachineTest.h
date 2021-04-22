
#ifndef VENDINGMACHINEAPPROVALKATA_VENDINGMACHINETEST_H
#define VENDINGMACHINEAPPROVALKATA_VENDINGMACHINETEST_H

#include <gtest/gtest.h>
#include "VendingMachine.h"

using namespace std;

class VendingMachineTest : public ::testing::Test {
public:
    VendingMachine* machine;
    map<string, int>* coins;

    void SetUp() override {
        machine = new VendingMachine();
        coins = new map<string, int>();
        coins->insert({
                              {"penny", 1},
                              {"nickel", 5},
                              {"dime", 10},
                              {"quarter", 25},
                      });
    }

    void TearDown() override {
        delete coins;
        delete machine;
    }
};

#endif //VENDINGMACHINEAPPROVALKATA_VENDINGMACHINETEST_H
