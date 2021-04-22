#include <gtest/gtest.h>

extern "C"
{
#include "sample.h"
#include "vending_machine.h"
#include "VendingMachineTest.h"
}

using namespace std;

TEST_F(VendingMachineTest, InsertCoins) {
    ASSERT_EQ("INSERT COIN", string(machine->display));

    insert_coin(machine, coin_with_name("nickel"));

    ASSERT_EQ("$0.05", string(machine->display));
    ASSERT_EQ(5, machine->balance);
    vector<int> expected_coins = {5};
    ASSERT_EQ(expected_coins, vector<int>(*machine->coins));

}