#include <gtest/gtest.h>
#include <VendingMachine.h>

#include "VendingMachineTest.h"

using namespace std;


TEST_F(VendingMachineTest, SelectProductToSeePrice) {
    machine->selectProduct("Cola");
    ASSERT_EQ(machine->display, "PRICE $1.00");
    machine->tick();
    ASSERT_EQ(machine->display, "INSERT COIN");
}

TEST_F(VendingMachineTest, BuyProduct) {
    machine->insertCoin(coins->at("quarter"));
    machine->insertCoin(coins->at("quarter"));
    machine->insertCoin(coins->at("quarter"));
    machine->insertCoin(coins->at("quarter"));

    machine->selectProduct("Cola");
    ASSERT_EQ(machine->display, "THANK YOU");
    machine->tick();
    ASSERT_EQ(machine->display, "INSERT COIN");
}
