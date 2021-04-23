

#ifndef VENDINGMACHINE_VENDINGMACHINETEST_H
#define VENDINGMACHINE_VENDINGMACHINETEST_H

#include "vending_machine.h"

class VendingMachineTest : public ::testing::Test {
public:
    struct vending_machine* machine;

    void SetUp() override {
        machine = vending_machine_create();
    }

    void TearDown() override {
        delete machine;
    }
};

#endif //VENDINGMACHINE_VENDINGMACHINETEST_H
