#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include "VendingMachine.h"

using namespace std;

TEST_CASE ("VendingMachine") {
    VendingMachine machine;

    SECTION("insert coin") {
        REQUIRE(machine.display == "INSERT COIN");
    }
}


