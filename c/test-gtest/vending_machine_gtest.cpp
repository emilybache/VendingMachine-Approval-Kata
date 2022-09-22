#include <gtest/gtest.h>

using namespace std;

extern "C"
{
#include "vending_machine_printer.h"
#include "vending_machine.h"
#include "coin.h"
#include "VendingMachineTest.h"
}

TEST_F(VendingMachineTest, InsertCoins) {

    ASSERT_EQ("INSERT COIN", string(machine->display));

    insert_coin(machine, coin_with_name("nickel"));

    ASSERT_EQ("$0.05", string(machine->display));
    ASSERT_EQ(5, machine->balance);
    ASSERT_EQ(1, machine->coin_count);
    ASSERT_EQ(5, machine->coins[0]);

}