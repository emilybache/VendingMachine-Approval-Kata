#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include <string>

extern "C"
{
#include "vending_machine_printer.h"
#include "vending_machine.h"
#include "coin.h"
}

using namespace std;

TEST_CASE ("VendingMachine") {
    auto machine = vending_machine_create();
    CHECK("INSERT COIN" == string(machine->display));

    SECTION("insert nickel") {
        insert_coin(machine, coin_with_name("nickel"));

        CHECK("$0.05" == string(machine->display));
        CHECK(5 == machine->balance);
        CHECK(1 == machine->coin_count);
        CHECK(5 == machine->coins[0]);
    }
}


