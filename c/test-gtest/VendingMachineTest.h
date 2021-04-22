

#ifndef VENDINGMACHINE_VENDINGMACHINETEST_H
#define VENDINGMACHINE_VENDINGMACHINETEST_H

#include "vending_machine.h"

typedef struct coin {
   char name[10];
   int value;
} coin;

class VendingMachineTest : public ::testing::Test {
public:
    struct vending_machine* machine;

    void SetUp() override {
        machine = vending_machine_create();
    }

    int coin_with_name(std::string name) {
        if (name == "penny") {
            return 1;
        }
        if (name == "nickel") {
            return 5;
        }
        if (name == "dime") {
            return 10;
        }
        if (name == "quarter") {
            return 25;
        }
        return 0;
    }

    void TearDown() override {
        delete machine;
    }
};

#endif //VENDINGMACHINE_VENDINGMACHINETEST_H
