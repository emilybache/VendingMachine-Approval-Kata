#include <gtest/gtest.h>
#include <VendingMachine.h>

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

TEST_F(VendingMachineTest, InsertCoins) {
    ASSERT_EQ("INSERT COIN", machine->display);

    machine->insertCoin(coins->at("nickel"));

    ASSERT_EQ("$0.05", machine->display);
    ASSERT_EQ(5, machine->balance);
    vector<int> expected_coins = {5};
    ASSERT_EQ(expected_coins, *machine->coins);
}