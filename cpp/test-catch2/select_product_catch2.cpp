#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include "VendingMachine.h"

using namespace std;

TEST_CASE ("SelectProduct") {
    VendingMachine machine;
    map<string, int> coins;
    coins.insert({
                         {"penny", 1},
                         {"nickel", 5},
                         {"dime", 10},
                         {"quarter", 25},
                 });

    SECTION("Select to see Price") {

        machine.selectProduct("Cola");
        CHECK(machine.display == "PRICE $1.00");
        machine.tick();
        CHECK(machine.display == "INSERT COIN");
    }

    SECTION("Pay then Select") {
        machine.insertCoin(coins.at("quarter"));
        machine.insertCoin(coins.at("quarter"));
        machine.insertCoin(coins.at("quarter"));
        machine.insertCoin(coins.at("quarter"));

        machine.selectProduct("Cola");
        CHECK(machine.display == "THANK YOU");
        CHECK(machine.dispensedProduct == "Cola");
        machine.tick();
        CHECK(machine.display == "INSERT COIN");
    }
}



