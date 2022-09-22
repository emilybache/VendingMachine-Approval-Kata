#include <gtest/gtest.h>
#include <VendingMachine.h>
#include <VendingMachinePrinter.h>
#include <ApprovalTests/Approvals.h>

#include "VendingMachineTest.h"

using namespace std;


TEST_F(VendingMachineTest, InsertCoins) {
    ASSERT_EQ("INSERT COIN", machine->display);

    machine->insertCoin(coins->at("nickel"));

    ASSERT_EQ("$0.05", machine->display);
    ASSERT_EQ(5, machine->balance);
    vector<int> expected_coins = {5};
    ASSERT_EQ(expected_coins, *machine->coins);

}

