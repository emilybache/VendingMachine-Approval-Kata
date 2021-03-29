#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include "VendingMachine.h"
#include "VendingMachinePrinter.h"

using namespace std;

TEST_CASE ("VendingMachine") {
    auto* machine = new VendingMachine();
    map<string, int> coins;
    coins.insert({
            {"penny", 1},
            {"nickel", 5},
            {"dime", 10},
            {"quarter", 25},
            });

    SECTION("insert coin") {
        CHECK(machine->display == "INSERT COIN");

        machine->insertCoin(coins.at("nickel"));


        CHECK(machine->display == "$0.05");
        CHECK(machine->balance == 5);
        vector<int> expected_coins = {5};
        CHECK(*machine->coins == expected_coins);
    }

    delete machine;
}


