

#include "VendingMachineTest.h"

TEST_F(VendingMachineTest, ReturnCoins)
{
    machine->insertCoin(coins->at("dime"));
    machine->returnCoins();

    ASSERT_EQ("INSERT COIN", machine->display);
    ASSERT_EQ(0, machine->balance);
}
