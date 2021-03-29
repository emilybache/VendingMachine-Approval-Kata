#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include "VendingMachine.h"

using namespace std;

TEST_CASE ("ReturnCoins") {
    auto* machine = new VendingMachine();
    map<string, int> coins;
    coins.insert({
                         {"penny",   1},
                         {"nickel",  5},
                         {"dime",    10},
                         {"quarter", 25},
                 });

    SECTION("insert coin") {

        machine->insertCoin(coins.at("dime"));
        machine->returnCoins();

        CHECK(machine->display == "INSERT COIN");
        CHECK(machine->balance == 0);
    }
}